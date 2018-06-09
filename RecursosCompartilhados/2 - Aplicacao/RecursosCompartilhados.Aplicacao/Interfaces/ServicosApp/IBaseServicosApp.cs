using RecursosCompartilhados.Dominio.Interfaces.Entidades;
using System;
using System.Collections.Generic;

namespace RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp
{
    public interface IBaseServicosApp<TEntidade> : IDisposable where TEntidade : IBaseEntidade
    {
        void Inserir(TEntidade viewModel);
        TEntidade Buscar(Guid id);
        IList<TEntidade> Listar();
        void Atualizar(TEntidade viewModel);
        void Remover(Guid id);
        int Salvar();
    }
}