using Bolao.Aplicacao.Interfaces.ServicosApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

namespace Bolao.WebApi.Controllers
{
    public class RankingController : BaseController
    {
        private readonly IRankingServicosApp _servicosApp;

        public RankingController(IRankingServicosApp servicosApp, INotificationHandler<NotificacaoDeDominio> notificacoes) : base(notificacoes)
        {
            _servicosApp = servicosApp;
        }

        [HttpGet]
        [Route("ranking")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Calcular());
        }
    }
}
