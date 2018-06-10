using Bolao.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Repositorios;
using System.Collections.Generic;

namespace Bolao.Dominio.Interfaces.Repositorios
{
    public interface IPalpiteRepositorio : IBaseRepositorio<Palpite>
    {
        IList<Palpite> ListarPorUsuario(string email);
        Palpite BuscarJogoPorUsuario(Palpite palpite);
        IList<Palpite> ListarPorJogo(Equipe.Selecao timeMandante, Equipe.Selecao timeVisitante);
    }
}
