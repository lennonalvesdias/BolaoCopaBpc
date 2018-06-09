using System.Linq;
using FanFest.Dados.Contexto;
using FanFest.Dominio.Entidades;
using FanFest.Dominio.Interfaces.Repositorios;
using MongoDB.Driver;

namespace FanFest.Dados.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        private FanFestContexto contexto = new FanFestContexto();

        public UsuarioRepositorio() {

        }

        public Usuario Login(Usuario usuario)
        {
            return contexto.Usuarios.Find(x => x.Apelido == usuario.Apelido && x.Senha == usuario.Senha).FirstOrDefault();
        }

        public bool ExisteCpf(string cpf) {
            var existe = contexto.Usuarios.Find(x => x.Cpf == cpf).FirstOrDefault();
            return existe != null;
        }

        public void ReiniciarDatabase()
        {
            contexto.Usuarios.DeleteMany(x => true);
            var admin = new Usuario("lennonalvesdias", "FanFestMarilia@2006", 0);
            contexto.Usuarios.InsertOne(admin);
        }
    }
}