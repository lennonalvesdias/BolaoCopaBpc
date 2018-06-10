using System.Linq;
using Bolao.Dados.Contexto;
using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Repositorios;
using MongoDB.Driver;

namespace Bolao.Dados.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        private BolaoContexto bolaoContexto = new BolaoContexto();

        public Usuario Login(Usuario usuario)
        {
            return bolaoContexto.Usuarios.Find(x => x.Apelido == usuario.Apelido && x.Senha == usuario.Senha)?.FirstOrDefault();
        }

        public Usuario GetByLogin(string apelido)
        {
            return bolaoContexto.Usuarios.Find(x => x.Apelido == apelido)?.FirstOrDefault();
        }

        public Usuario GetByEmail(string email)
        {
            return bolaoContexto.Usuarios.Find(x => x.Email == email)?.FirstOrDefault();
        }
    }
}