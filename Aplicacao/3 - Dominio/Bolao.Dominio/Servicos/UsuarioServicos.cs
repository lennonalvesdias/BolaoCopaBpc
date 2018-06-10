using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Repositorios;
using Bolao.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Servicos;

namespace Bolao.Dominio.Servicos
{
    public class UsuarioServicos : BaseServicos<Usuario>, IUsuarioServicos
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioServicos(IUsuarioRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public Usuario Login(Usuario usuario)
        {
            return _repositorio.Login(usuario);
        }

        public Usuario GetByLogin(string apelido)
        {
            return _repositorio.GetByLogin(apelido);
        }

        public Usuario GetByEmail(string email)
        {
            return _repositorio.GetByEmail(email);
        }
    }
}