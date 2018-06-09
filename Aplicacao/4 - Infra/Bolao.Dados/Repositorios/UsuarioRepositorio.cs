using System.Linq;
using Bolao.Dados.Contexto;
using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Repositorios;
using MongoDB.Driver;

namespace Bolao.Dados.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        private BolaoContexto contexto = new BolaoContexto();

        public UsuarioRepositorio() {

        }

        public Usuario Login(Usuario usuario)
        {
            return contexto.Usuarios.Find(x => x.Apelido == usuario.Apelido && x.Senha == usuario.Senha).FirstOrDefault();
        }
    }
}