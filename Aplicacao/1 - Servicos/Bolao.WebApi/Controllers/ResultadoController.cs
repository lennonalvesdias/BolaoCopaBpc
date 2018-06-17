using Bolao.Aplicacao.Interfaces.ServicosApp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.WebApi.Controllers;

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
        [Route("resultados/aovivo")]
        public IActionResult Live()
        {
            return Response(_servicosApp.AoVivo());
        }

        [HttpGet]
        [Route("resultados/finalizados")]
        public IActionResult Finished()
        {
            return Response(_servicosApp.Finalizados());
        }
    }
}
