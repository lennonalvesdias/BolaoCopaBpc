using FanFest.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;

namespace FanFest.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
         Usuario Login(Usuario usuario);
         void ReiniciarDatabase();
         bool ExisteCpf(string cpf);
    }
}