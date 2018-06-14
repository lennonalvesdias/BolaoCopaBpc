using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Interfaces.Servicos;
using MediatR;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;
using System;
using System.Collections.Generic;

namespace Bolao.Aplicacao.ServicosApp
{
    public class AuditoriaServicosApp : IAuditoriaServicosApp
    {
        private readonly GerenciadorDeNotificacoes _notificacoes;
        private readonly IPalpiteServicosApp _palpiteServicosApp;
        private readonly IUsuarioServicos _usuarioServicos;

        public AuditoriaServicosApp(IPalpiteServicosApp palpiteServicosApp, IUsuarioServicos usuarioServicos, INotificationHandler<NotificacaoDeDominio> notificacoes)
        {
            _palpiteServicosApp = palpiteServicosApp;
            _notificacoes = (GerenciadorDeNotificacoes)notificacoes;
            _usuarioServicos = usuarioServicos;
        }

        public IList<PalpiteReturnViewModel> Auditoria(string email)
        {
            var usuario = ExisteUsuario(email);
            if (usuario == false)
            {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Não existe usuário cadastrado com este e-mail."));
                return null;
            }

            //var horarioValido = HorarioValido();
            //if (horarioValido == false)
            //{
            //    _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Auditoria liberada a partir das 12h de 14/06/2018."));
            //    return null;
            //}

            return _palpiteServicosApp.ListarPorUsuario(email);
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

        private bool HorarioValido()
        {
            if (DateTime.Now <= new DateTime(2018, 06, 14, 15, 00, 00))
            {
                return false;
            }

            return true;
        }

        private DateTime HorarioDeBrasilia(DateTime data)
        {
            return TimeZoneInfo.ConvertTime(data, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }
    }
}
