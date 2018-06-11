using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Repositorios;
using Bolao.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Servicos;

namespace Bolao.Dominio.Servicos
{
    public class ResultadoServicos : BaseServicos<Resultado>, IResultadoServicos
    {
        private readonly IResultadoRepositorio _repositorio;

        public ResultadoServicos(IResultadoRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
