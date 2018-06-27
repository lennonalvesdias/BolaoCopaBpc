using Bolao.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace Bolao.Aplicacao.Interfaces.ServicosApp
{
    public interface IResultadoServicosApp
    {
        IList<AoVivoViewModel> AoVivo();
        IList<FixtureViewModel> Listar();
        IList<FixtureViewModel> Finalizados();
        IList<FixtureViewModel> PrimeiraFase();
        IList<FixtureViewModel> Oitavas();
        IList<FixtureViewModel> Quartas();
        IList<FixtureViewModel> Semifinal();
        IList<FixtureViewModel> TerceiroQuarto();
        IList<FixtureViewModel> Final();
    }
}
