using Bolao.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;

namespace Bolao.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServicos : IBaseServicos<Usuario>
    {
         Usuario Login(Usuario usuario);
        Usuario GetByLogin(string apelido);
        Usuario GetByEmail(string email);
    }
}