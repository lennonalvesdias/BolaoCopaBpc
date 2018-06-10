using Bolao.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace Bolao.Aplicacao.Interfaces.ServicosApp
{
    public interface IRankingServicosApp
    {
        List<RankingViewModel> Calcular();
    }
}
