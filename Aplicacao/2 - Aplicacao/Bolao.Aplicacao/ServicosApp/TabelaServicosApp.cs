using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;
using RecursosCompartilhados.Aplicacao.ServicosExternos;

namespace Bolao.Aplicacao.ServicosApp
{
    public class TabelaServicosApp : ITabelaServicosApp
    {
        public TabelaServicosApp()
        { }

        public TabelaViewModel Listar()
        {
            var apiBase = "https://www.football-data.org";
            var resourceConfrontos = "/v1/competitions/467/leagueTable";
            var post = RestSharpClient.Get(apiBase, resourceConfrontos);
            var tabela = JsonConvert.DeserializeObject<TabelaViewModel>(post.Content);
            return tabela;
        }
    }
}
