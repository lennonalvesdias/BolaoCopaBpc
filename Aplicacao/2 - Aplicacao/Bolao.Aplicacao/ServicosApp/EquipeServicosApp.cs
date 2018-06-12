using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;
using RecursosCompartilhados.Aplicacao.ServicosExternos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Aplicacao.ServicosApp
{
    public class EquipeServicosApp : IEquipeServicosApp
    {
        public EquipeServicosApp()
        { }

        public IList<TeamViewModel> Listar()
        {
            var apiBase = "https://www.football-data.org";
            var resourceConfrontos = "/v1/competitions/467/teams";
            var headers = new Dictionary<string, string> { { "X-Auth-Token", "5759e59c5cd44dfdbd72cfc074d8f8f2" } };
            var getEquipes = RestSharpClient.Get(apiBase, resourceConfrontos, headers: headers);
            var equipes = JsonConvert.DeserializeObject<TimesViewModel>(getEquipes.Content);
            return equipes.Teams;
        }

        public TeamViewModel Buscar(string codigoEquipe)
        {
            var apiBase = "https://www.football-data.org";
            var resourceConfrontos = "/v1/competitions/467/teams";
            var headers = new Dictionary<string, string> { { "X-Auth-Token", "5759e59c5cd44dfdbd72cfc074d8f8f2" } };
            var getEquipes = RestSharpClient.Get(apiBase, resourceConfrontos, headers: headers);
            var equipes = JsonConvert.DeserializeObject<TimesViewModel>(getEquipes.Content);
            return equipes.Teams.FirstOrDefault(x => x.Code == codigoEquipe);
        }

        public TeamViewModel Buscar(int codigoEquipe)
        {
            var apiBase = "https://www.football-data.org";
            var resourceConfrontos = "/v1/competitions/467/teams";
            var headers = new Dictionary<string, string> { { "X-Auth-Token", "5759e59c5cd44dfdbd72cfc074d8f8f2" } };
            var getEquipes = RestSharpClient.Get(apiBase, resourceConfrontos, headers: headers);
            var equipes = JsonConvert.DeserializeObject<TimesViewModel>(getEquipes.Content);
            return equipes.Teams.FirstOrDefault(x => getIdByHref(x.Links.Self.Href) == codigoEquipe);
        }

        private int getIdByHref(string href)
        {
            var lastIndexOfHref = href.LastIndexOf("/");
            var codigo = href.Substring(lastIndexOfHref + 1, 3);
            return Convert.ToInt32(codigo);
        }
    }
}
