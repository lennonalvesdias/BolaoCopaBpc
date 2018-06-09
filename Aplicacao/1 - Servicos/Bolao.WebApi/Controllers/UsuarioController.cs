using System;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace Bolao.WebApi.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioServicosApp _servicosApp;

        public UsuarioController(IUsuarioServicosApp servicosApp, INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("usuarios/login")]
        public object Login(
            [FromBody]UsuarioLoginViewModel usuario, [FromServices]Login login, [FromServices]Token token)
        {
            if (!ModelState.IsValid)
            {
                NotificarErros();
                return Response(usuario);
            }

            return _servicosApp.Login(usuario, login, token);
        }

        [HttpGet]
        [Route("usuarios")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }

        [HttpGet]
        [Route("usuarios/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_servicosApp.Buscar(id));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("usuarios")]
        public IActionResult Post([FromBody]UsuarioSendViewModel vm)
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
        [Route("usuarios")]
        public IActionResult Put([FromBody]UsuarioSendViewModel vm)
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
        [Route("usuarios/{id}")]
        public IActionResult Delete(Guid id)
        {
            _servicosApp.Remover(id);

            return Response();
        }
    }
}