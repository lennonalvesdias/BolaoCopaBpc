using Bolao.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace Bolao.Dominio.Interfaces.Servicos
{
    public interface IPalpiteServicos : IBaseServicos<Palpite>
    {
        IList<Palpite> ListarPorUsuario(string email);
        Palpite BuscarJogoPorUsuario(Palpite palpite);
        IList<Palpite> ListarPorJogo(Equipe.Selecao timeMandante, Equipe.Selecao timeVisitante);
    }
}
