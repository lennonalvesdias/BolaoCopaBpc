using Bolao.Dados.Contexto;
using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Repositorios;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Bolao.Dados.Repositorios
{
    public class PalpiteRepositorio : BaseRepositorio<Palpite>, IPalpiteRepositorio
    {
        private BolaoContexto bolaoContexto = new BolaoContexto();

        public IList<Palpite> ListarPorUsuario(string email)
        {
            return bolaoContexto.Palpites.Find(x => x.Email == email).ToList();
        }

        public Palpite BuscarJogoPorUsuario(Palpite palpite)
        {
            return bolaoContexto.Palpites.Find(x => x.Email == palpite.Email && x.MandanteTime == palpite.MandanteTime && x.VisitanteTime == palpite.VisitanteTime)?.FirstOrDefault();
        }

        public IList<Palpite> ListarPorJogo(Equipe.Selecao timeMandante, Equipe.Selecao timeVisitante)
        {
            return bolaoContexto.Palpites.Find(x => x.MandanteTime == timeMandante && x.VisitanteTime == timeVisitante)?.ToList();
        }
    }
}
