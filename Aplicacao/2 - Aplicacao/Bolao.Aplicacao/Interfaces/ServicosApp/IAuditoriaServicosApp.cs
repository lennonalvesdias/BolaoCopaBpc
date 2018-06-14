using Bolao.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace Bolao.Aplicacao.Interfaces.ServicosApp
{
    public interface IAuditoriaServicosApp
    {
        IList<PalpiteReturnViewModel> Auditoria(string email);
    }
}
