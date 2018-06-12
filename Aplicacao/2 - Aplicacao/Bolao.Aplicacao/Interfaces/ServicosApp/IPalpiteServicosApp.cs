using Bolao.Aplicacao.ViewModels;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using System.Collections.Generic;

namespace Bolao.Aplicacao.Interfaces.ServicosApp
{
    public interface IPalpiteServicosApp : IBaseServicosApp<PalpiteSendViewModel, PalpiteReturnViewModel>
    {
        IList<PalpiteReturnViewModel> ListarPorUsuario(string apelido);
        IList<PalpiteReturnViewModel> ListarPorJogo(int mandante, int visitante);
        void CriarOuAtualizarPalpite(PalpiteSendViewModel viewModel);
    }
}
