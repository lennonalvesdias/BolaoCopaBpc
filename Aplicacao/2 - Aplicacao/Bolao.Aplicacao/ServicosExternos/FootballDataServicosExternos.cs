using Bolao.Aplicacao.Interfaces.ServicosExternos;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosExternos;
using System.Collections.Generic;

namespace Bolao.Aplicacao.ServicosExternos
{
    public class FootballDataServicosExternos : IFootballDataServicosExternos
    {
        private readonly string _urlBase = "https://www.football-data.org";

        private readonly IRestSharpClient _restSharp;

        public FootballDataServicosExternos(IRestSharpClient restSharp)
        {
            _restSharp = restSharp;
        }

        public string Get(string resource)
        {            
            var headers = new Dictionary<string, string> { { "X-Auth-Token", "5759e59c5cd44dfdbd72cfc074d8f8f2" } };
            return _restSharp.Get(_urlBase, resource, headers: headers).Content;
        }
    }
}
