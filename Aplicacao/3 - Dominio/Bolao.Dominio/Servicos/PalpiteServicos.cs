using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Repositorios;
using Bolao.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Servicos;
using System.Collections.Generic;

namespace Bolao.Dominio.Servicos
{
    public class PalpiteServicos : BaseServicos<Palpite>, IPalpiteServicos
    {
        private readonly IPalpiteRepositorio _repositorio;

        public PalpiteServicos(IPalpiteRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IList<Palpite> ListarPorUsuario(string apelido)
        {
            return _repositorio.ListarPorUsuario(apelido);
        }

        public Palpite BuscarJogoPorUsuario(Palpite palpite)
        {
            return _repositorio.BuscarJogoPorUsuario(palpite);
        }

        public IList<Palpite> ListarPorJogo(Equipe.Selecao timeMandante, Equipe.Selecao timeVisitante)
        {
            return _repositorio.ListarPorJogo(timeMandante, timeVisitante);
        }
    }
}
