using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.Interfaces.ServicosExternos;
using Bolao.Aplicacao.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Aplicacao.ServicosApp
{
    public class EquipeServicosApp : IEquipeServicosApp
    {
        private readonly IFootballDataServicosExternos _footballData;

        public EquipeServicosApp(IFootballDataServicosExternos footballData)
        {
            _footballData = footballData;
        }

        public IList<TeamViewModel> Listar()
        {
            return JsonConvert.DeserializeObject<TimesViewModel>(_footballData.Get("/v1/competitions/467/teams")).Teams;
        }

        public TeamViewModel Buscar(string codigoEquipe)
        {
            var equipes = JsonConvert.DeserializeObject<TimesViewModel>(_footballData.Get("/v1/competitions/467/teams")).Teams;
            if (equipes == null) return null;
            return equipes.FirstOrDefault(x => x.Code == codigoEquipe);
        }

        public TeamViewModel Buscar(int codigoEquipe)
        {
            var equipes = JsonConvert.DeserializeObject<TimesViewModel>(_footballData.Get("/v1/competitions/467/teams")).Teams;
            if (equipes == null) return null;
            return equipes.FirstOrDefault(x => Helpers.GetIdByHref(x.Links.Self.Href) == codigoEquipe);
        }
    }
}
