using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;
using System;

namespace Bolao.WebApi.Controllers
{
    public class ResultadoController : BaseController
    {
        private readonly IResultadoServicosApp _servicosApp;

        public ResultadoController(IResultadoServicosApp servicosApp, INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        [Route("resultados")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }

        [HttpGet]
        [Route("resultados/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_servicosApp.Buscar(id));
        }

        [HttpPost]
        [Route("resultados")]
        public IActionResult Post([FromBody]ResultadoSendViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _servicosApp.Inserir(vm);

            return Response(vm);
        }

        [HttpPut]
        [Route("resultados")]
        public IActionResult Put([FromBody]ResultadoSendViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _servicosApp.Atualizar(vm);

            return Response(vm);
        }

        [HttpDelete]
        [Route("resultados/{id}")]
        public IActionResult Delete(Guid id)
        {
            _servicosApp.Remover(id);

            return Response();
        }
    }
}
