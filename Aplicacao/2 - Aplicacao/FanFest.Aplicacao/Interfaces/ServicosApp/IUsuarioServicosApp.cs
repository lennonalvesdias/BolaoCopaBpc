using FanFest.Aplicacao.ViewModels;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;

namespace FanFest.Aplicacao.Interfaces.ServicosApp
{
    public interface IUsuarioServicosApp : IBaseServicosApp<UsuarioViewModel>
    {
        object Login(UsuarioViewModel viewModel, Login login, Token token);
        void ReiniciarDatabase();

        void Reservar(ReservarAlbumViewModel viewModel);
    }
}