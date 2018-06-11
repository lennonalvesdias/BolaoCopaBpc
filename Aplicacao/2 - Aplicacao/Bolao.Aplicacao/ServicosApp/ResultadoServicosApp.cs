using System;
using System.Collections.Generic;
using AutoMapper;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Servicos;
using MediatR;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;

namespace Bolao.Aplicacao.ServicosApp
{
    public class ResultadoServicosApp : IResultadoServicosApp
    {
        private readonly GerenciadorDeNotificacoes _notificacoes;
        private readonly IResultadoServicos _servicos;
        private readonly IMapper _mapper;

        public ResultadoServicosApp(IResultadoServicos servicos, IMapper mapper, INotificationHandler<NotificacaoDeDominio> notificacoes)
        {
            _servicos = servicos;
            _mapper = mapper;
            _notificacoes = (GerenciadorDeNotificacoes)notificacoes;
        }

        public void Atualizar(ResultadoSendViewModel viewModel)
        {
            if (viewModel.MandantePlacar > viewModel.VisitantePlacar)
            {
                viewModel.MandanteVitoria = true;
                viewModel.VisitanteVitoria = false;
            }
            else if (viewModel.VisitantePlacar > viewModel.MandantePlacar)
            {
                viewModel.MandanteVitoria = false;
                viewModel.VisitanteVitoria = true;
            }
            else
            {
                viewModel.MandanteVitoria = false;
                viewModel.VisitanteVitoria = false;
            }

            var resultado = _mapper.Map<Resultado>(viewModel);
            _servicos.Atualizar(resultado);
        }

        public ResultadoReturnViewModel Buscar(Guid id)
        {
            var resultado = _servicos.Buscar(id);
            return _mapper.Map<ResultadoReturnViewModel>(resultado);
        }

        public void Dispose()
        {
            _servicos.Dispose();
        }

        public void Inserir(ResultadoSendViewModel viewModel)
        {
            if (viewModel.MandantePlacar > viewModel.VisitantePlacar)
            {
                viewModel.MandanteVitoria = true;
                viewModel.VisitanteVitoria = false;
            } else if (viewModel.VisitantePlacar > viewModel.MandantePlacar)
            {
                viewModel.MandanteVitoria = false;
                viewModel.VisitanteVitoria = true;
            } else
            {
                viewModel.MandanteVitoria = false;
                viewModel.VisitanteVitoria = false;
            }

            var resultado = _mapper.Map<Resultado>(viewModel);
            _servicos.Inserir(resultado);
        }

        public IList<ResultadoReturnViewModel> Listar()
        {
            var resultados = _servicos.Listar();
            return _mapper.Map<IList<ResultadoReturnViewModel>>(resultados);
        }

        public void Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        public int Salvar()
        {
            return _servicos.Salvar();
        }
    }
}
