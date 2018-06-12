using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using MediatR;
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

        [HttpGet]
        [Route("palpites")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }

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

        [HttpGet]
        [Route("palpites/usuario/{email}")]
        public IActionResult GetByUser(string email)
        {
            return Response(_servicosApp.ListarPorUsuario(email));
        }

        [HttpGet]
        [Route("palpites/jogo/{mandante:int}/{visitante:int}")]
        public IActionResult Get(int mandante, int visitante)
        {
            return Response(_servicosApp.ListarPorJogo(mandante, visitante));
        }

        [HttpPost]
        [Route("palpites/palpitar")]
        public IActionResult PostOrUpdate([FromBody]PalpiteSendViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(vm);
            }

            _servicosApp.CriarOuAtualizarPalpite(vm);

            return Response(vm);
        }
    }
}
