using Bolao.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;

namespace Bolao.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
         Usuario Login(Usuario usuario);
    }
}