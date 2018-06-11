﻿using Bolao.Aplicacao.Interfaces.ServicosApp;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpGet]
        [Route("resultados")]
        public IActionResult Get()
        {
            return Response(_servicosApp.Listar());
        }
    }
}
