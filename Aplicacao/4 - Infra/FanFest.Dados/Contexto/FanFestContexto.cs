using MongoDB.Driver;
using FanFest.Dominio.Entidades;

namespace FanFest.Dados.Contexto
{
    public class FanFestContexto : BaseContexto
    {
        public IMongoCollection<Usuario> Usuarios
        {
            get
            {
                return _database.GetCollection<Usuario>("Usuarios");
            }
        }
    }
}