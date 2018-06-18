using Bolao.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace Bolao.Aplicacao.Interfaces.ServicosApp
{
    public interface IResultadoServicosApp
    {
        IList<FixtureViewModel> Listar();
        AoVivoViewModel AoVivo();
        IList<FixtureViewModel> Finalizados();
    }
}
