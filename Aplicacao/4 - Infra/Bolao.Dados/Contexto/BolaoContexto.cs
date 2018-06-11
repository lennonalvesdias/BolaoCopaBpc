using MongoDB.Driver;
using Bolao.Dominio.Entidades;

namespace Bolao.Dados.Contexto
{
    public class BolaoContexto : BaseContexto
    {
        public IMongoCollection<Usuario> Usuarios
        {
            get
            {
                return _database.GetCollection<Usuario>("Usuarios");
            }
        }

        public IMongoCollection<Palpite> Palpites
        {
            get
            {
                return _database.GetCollection<Palpite>("Palpites");
            }
        }
    }
}