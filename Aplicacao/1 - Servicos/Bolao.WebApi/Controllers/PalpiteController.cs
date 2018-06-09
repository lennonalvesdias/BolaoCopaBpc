using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;
using System;

namespace Bolao.WebApi.Controllers
{
    public class PalpiteController : BaseController
    {
        public readonly IPalpiteServicosApp _servicosApp;

        public PalpiteController(IPalpiteServicosApp servicosApp, INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("palpites")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("palpites/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_servicosApp.Buscar(id));
        }

        [HttpPost]
        [Route("palpites")]
        public IActionResult Post([FromBody]PalpiteSendViewModel vm)
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
        [Route("palpites")]
        public IActionResult Put([FromBody]PalpiteSendViewModel vm)
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
        [Route("palpites/{id}")]
        public IActionResult Delete(Guid id)
        {
            _servicosApp.Remover(id);

            return Response();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("palpites/usuario/{apelido}")]
        public IActionResult GetByUser(string apelido)
        {
            return Response(_servicosApp.ListarPorUsuario(apelido));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("palpites/jogo/{mandante:int}/{visitante:int}")]
        public IActionResult Get(int mandante, int visitante)
        {
            return Response(_servicosApp.ListarPorJogo(mandante, visitante));
        }
    }
}
