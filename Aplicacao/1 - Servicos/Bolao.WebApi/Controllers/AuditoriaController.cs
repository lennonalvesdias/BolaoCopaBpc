using Bolao.Aplicacao.Interfaces.ServicosApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace Bolao.WebApi.Controllers
{
    public class AuditoriaController : BaseController
    {
        private readonly IAuditoriaServicosApp _servicosApp;

        public AuditoriaController(IAuditoriaServicosApp servicosApp, INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpGet]
        [Route("auditoria/{email}")]
        public IActionResult Auditoria(string email)
        {
            return Response(_servicosApp.Auditoria(email));
        }
    }
}
