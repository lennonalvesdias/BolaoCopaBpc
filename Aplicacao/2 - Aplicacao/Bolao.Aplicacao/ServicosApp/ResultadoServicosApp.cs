using Bolao.Aplicacao.Interfaces.ServicosApp;
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
            var headers = new Dictionary<string, string> { { "X-Auth-Token", "5759e59c5cd44dfdbd72cfc074d8f8f2" } };
            var getConfrontos = RestSharpClient.Get(apiBase, resourceConfrontos, headers: headers);
            var confrontos = JsonConvert.DeserializeObject<ResultadoViewModel>(getConfrontos.Content);
            return confrontos.Fixtures;
        }
    }
}
