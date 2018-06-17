using Bolao.Aplicacao.Interfaces.ServicosApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace Bolao.WebApi.Controllers
{
    public class TabelaController : BaseController
    {
        private readonly ITabelaServicosApp _servicosApp;

        public TabelaController(ITabelaServicosApp servicosApp, INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        [Route("tabela")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }
    }
}
