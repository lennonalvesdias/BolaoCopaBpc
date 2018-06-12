using Bolao.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace Bolao.Aplicacao.Interfaces.ServicosApp
{
    public interface IEquipeServicosApp
    {
        IList<TeamViewModel> Listar();
        TeamViewModel Buscar(string codigoEquipe);
        TeamViewModel Buscar(int codigoEquipe);
    }
}
