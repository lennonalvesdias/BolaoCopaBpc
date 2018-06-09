using Bolao.Aplicacao.ViewModels;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;

namespace Bolao.Aplicacao.Interfaces.ServicosApp
{
    public interface IUsuarioServicosApp : IBaseServicosApp<UsuarioSendViewModel, UsuarioReturnViewModel>
    {
        object Login(UsuarioLoginViewModel viewModel, Login login, Token token);
    }
}