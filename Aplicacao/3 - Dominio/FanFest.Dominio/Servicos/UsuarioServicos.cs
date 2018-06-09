using FanFest.Dominio.Entidades;
using FanFest.Dominio.Interfaces.Repositorios;
using FanFest.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Servicos;

namespace FanFest.Dominio.Servicos
{
    public class UsuarioServicos : BaseServicos<Usuario>, IUsuarioServicos
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioServicos(IUsuarioRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public bool ExisteCpf(string cpf)
        {
            return _repositorio.ExisteCpf(cpf);
        }

        public void ReiniciarDatabase()
        {
            _repositorio.ReiniciarDatabase();
        }

        Usuario IUsuarioServicos.Login(Usuario usuario)
        {
            return _repositorio.Login(usuario);
        }
    }
}