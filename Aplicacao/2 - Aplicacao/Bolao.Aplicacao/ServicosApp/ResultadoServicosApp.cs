using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.Interfaces.ServicosExternos;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Aplicacao.ServicosApp
{
    public class ResultadoServicosApp : IResultadoServicosApp
    {
        private readonly IFootballDataServicosExternos _footballData;

        public ResultadoServicosApp(IFootballDataServicosExternos footballData)
        {
            _footballData = footballData;
        }

        public FixtureViewModel AoVivo()
        {
            var resultados = JsonConvert.DeserializeObject<ResultadoViewModel>(_footballData.Get("/v1/competitions/467/fixtures")).Fixtures;
            return resultados.FirstOrDefault(x => x.Status.ToUpper().Equals("IN_PLAY"));
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
    }
}
