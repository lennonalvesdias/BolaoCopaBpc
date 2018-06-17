using Bolao.Aplicacao.Interfaces.ServicosApp;
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

        public AoVivoViewModel AoVivo()
        {
            var resultados = JsonConvert.DeserializeObject<ResultadoViewModel>(_footballData.Get("/v1/competitions/467/fixtures")).Fixtures;
            var resultadoAoVivo = resultados.FirstOrDefault(x => x.Status.ToUpper().Equals("IN_PLAY"));
            var palpitesDoJogo = _palpitesServicosApp.ListarPorJogo(GetIdByHref(resultadoAoVivo.Links.HomeTeam.Href), GetIdByHref(resultadoAoVivo.Links.AwayTeam.Href)).OrderBy(x => x.Email).ToList();
            return new AoVivoViewModel { Jogo = resultadoAoVivo, Palpites = palpitesDoJogo };
        }

        public IList<FixtureViewModel> Listar()
        {
            return JsonConvert.DeserializeObject<ResultadoViewModel>(_footballData.Get("/v1/competitions/467/fixtures")).Fixtures;
        }

        public IList<FixtureViewModel> Finalizados()
        {
            var resultados = JsonConvert.DeserializeObject<ResultadoViewModel>(_footballData.Get("/v1/competitions/467/fixtures")).Fixtures;
            return resultados.Where(x => x.Status.ToUpper().Equals("FINISHED")).ToList();
        }

        private int GetIdByHref(string href)
        {
            var lastIndexOfHref = href.LastIndexOf("/");
            var codigo = href.Substring(lastIndexOfHref + 1, 3);
            return Convert.ToInt32(codigo);
        }
    }
}
