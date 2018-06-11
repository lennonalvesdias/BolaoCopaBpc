﻿using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;
using RecursosCompartilhados.Aplicacao.ServicosExternos;
using System.Collections.Generic;

namespace Bolao.Aplicacao.ServicosApp
{
    public class ResultadoServicosApp : IResultadoServicosApp
    {
        public ResultadoServicosApp()
        { }

        public IList<FixtureViewModel> Listar()
        {
            var apiBase = "https://www.football-data.org";
            var resourceConfrontos = "/v1/competitions/467/fixtures";
            var post = RestSharpClient.Get(apiBase, resourceConfrontos);
            var confrontos = JsonConvert.DeserializeObject<ResultadoViewModel>(post.Content);
            return confrontos.Fixtures;
        }
    }
}
