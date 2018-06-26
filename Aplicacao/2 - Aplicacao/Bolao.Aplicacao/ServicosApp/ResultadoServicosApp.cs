﻿using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.Interfaces.ServicosExternos;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Aplicacao.ServicosApp
{
    public class ResultadoServicosApp : IResultadoServicosApp
    {
        private readonly IFootballDataServicosExternos _footballData;
        private readonly IPalpiteServicosApp _palpitesServicosApp;

        public ResultadoServicosApp(IFootballDataServicosExternos footballData, IPalpiteServicosApp palpitesServicosApp)
        {
            _footballData = footballData;
            _palpitesServicosApp = palpitesServicosApp;
        }

        public IList<AoVivoViewModel> AoVivo()
        {
            var resultados = JsonConvert.DeserializeObject<ResultadoViewModel>(_footballData.Get("/v1/competitions/467/fixtures")).Fixtures;
            var resultadosAoVivo = resultados.Where(x => x.Status.ToUpper().Equals("IN_PLAY"));
            if (!resultadosAoVivo.Any()) return null;
            var jogos = new List<AoVivoViewModel>();
            foreach (var resultado in resultadosAoVivo)
            {
                var palpitesDoJogo = _palpitesServicosApp.ListarPorJogo(Helpers.GetIdByHref(resultado.Links.HomeTeam.Href), Helpers.GetIdByHref(resultado.Links.AwayTeam.Href)).OrderBy(x => x.Email).ToList();
                var jogo = new AoVivoViewModel { Jogo = resultado, Palpites = palpitesDoJogo };
                jogos.Add(jogo);
            }
            return jogos;
        }

        public IList<FixtureViewModel> Listar()
        {
            return JsonConvert.DeserializeObject<ResultadoViewModel>(_footballData.Get("/v1/competitions/467/fixtures")).Fixtures;
        }

        public IList<FixtureViewModel> Finalizados()
        {
            var resultados = JsonConvert.DeserializeObject<ResultadoViewModel>(_footballData.Get("/v1/competitions/467/fixtures")).Fixtures;
            if (resultados == null) return null;
            return resultados.Where(x => x.Status.ToUpper().Equals("FINISHED")).ToList();
        }
    }
}
