using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;
using RecursosCompartilhados.Aplicacao.ServicosExternos;
using System.Collections.Generic;

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
            var post = RestSharpClient.Get(apiBase, resourceConfrontos);
            var equipes = JsonConvert.DeserializeObject<TimesViewModel>(post.Content);
            return equipes.Teams;
        }
    }
}
