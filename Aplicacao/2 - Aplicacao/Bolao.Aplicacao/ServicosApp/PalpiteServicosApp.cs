using System;
using System.Collections.Generic;
using AutoMapper;
using MediatR;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Interfaces.Servicos;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;
using Bolao.Dominio.Entidades;

namespace Bolao.Aplicacao.ServicosApp
{
    public class PalpiteServicosApp : IPalpiteServicosApp
    {
        private readonly GerenciadorDeNotificacoes _notificacoes;
        private readonly IPalpiteServicos _servicos;
        private readonly IUsuarioServicos _usuarioServicos;
        private readonly IMapper _mapper;

        public PalpiteServicosApp(IPalpiteServicos servicos, IUsuarioServicos usuarioServicos, IMapper mapper, INotificationHandler<NotificacaoDeDominio> notificacoes)
        {
            _servicos = servicos;
            _usuarioServicos = usuarioServicos;
            _mapper = mapper;
            _notificacoes = (GerenciadorDeNotificacoes)notificacoes;
        }

        public void Atualizar(PalpiteSendViewModel viewModel)
        {
            var palpite = _mapper.Map<Palpite>(viewModel);
            _servicos.Atualizar(palpite);
        }

        public PalpiteReturnViewModel Buscar(Guid id)
        {
            var palpite = _servicos.Buscar(id);
            return _mapper.Map<PalpiteReturnViewModel>(palpite);
        }

        public void Dispose()
        {
            _servicos.Dispose();
        }

        public void Inserir(PalpiteSendViewModel viewModel)
        {
            var usuario = ExisteUsuario(viewModel.Email);
            if (usuario == false)
            {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Não existe usuário cadastrado com este apelido."));
                return;
            }

            var palpiteValido = PalpiteValido(viewModel);
            if (palpiteValido == false)
            {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "O usuário já tem um palpite para este jogo."));
                return;
            }

            var palpite = _mapper.Map<Palpite>(viewModel);
            _servicos.Inserir(palpite);
        }

        public IList<PalpiteReturnViewModel> Listar()
        {
            var palpites = _servicos.Listar();
            return _mapper.Map<IList<PalpiteReturnViewModel>>(palpites);
        }

        public void Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        public int Salvar()
        {
            return _servicos.Salvar();
        }

        public IList<PalpiteReturnViewModel> ListarPorUsuario(string email)
        {
            var palpites = _servicos.ListarPorUsuario(email);
            return _mapper.Map<IList<PalpiteReturnViewModel>>(palpites);
        }

        public IList<PalpiteReturnViewModel> ListarPorJogo(int mandante, int visitante)
        {
            var timeMandante = (Equipe.Selecao)mandante;
            var timeVisitante = (Equipe.Selecao)visitante;
            var palpites = _servicos.ListarPorJogo(timeMandante, timeVisitante);
            return _mapper.Map<IList<PalpiteReturnViewModel>>(palpites);
        }

        private bool PalpiteValido(PalpiteSendViewModel viewModel)
        {
            var palpite = _mapper.Map<Palpite>(viewModel);
            var temPalpite = _servicos.BuscarJogoPorUsuario(palpite);

            if (temPalpite == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ExisteUsuario(string email)
        {
            var usuario = _usuarioServicos.GetByEmail(email);

            if (usuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
