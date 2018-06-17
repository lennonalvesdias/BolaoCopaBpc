using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.Interfaces.ServicosExternos;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;

namespace Bolao.Aplicacao.ServicosApp
{
    public class TabelaServicosApp : ITabelaServicosApp
    {
        private readonly IFootballDataServicosExternos _footballData;

        public TabelaServicosApp(IFootballDataServicosExternos footballData)
        {
            _footballData = footballData;
        }

        public TabelaViewModel Listar()
        {
            return JsonConvert.DeserializeObject<TabelaViewModel>(_footballData.Get("/v1/competitions/467/leagueTable"));
        }
    }
}
