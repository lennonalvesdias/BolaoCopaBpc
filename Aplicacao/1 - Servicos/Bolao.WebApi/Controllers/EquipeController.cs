using Bolao.Aplicacao.Interfaces.ServicosApp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace Bolao.WebApi.Controllers
{
    public class EquipeController : BaseController
    {
        private readonly IEquipeServicosApp _servicosApp;

        public EquipeController(IEquipeServicosApp servicosApp, INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("equipes")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }
    }
}
