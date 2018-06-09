using FanFest.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;

namespace FanFest.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServicos : IBaseServicos<Usuario>
    {
         Usuario Login(Usuario usuario);
         void ReiniciarDatabase();
         bool ExisteCpf(string cpf);
    }
}