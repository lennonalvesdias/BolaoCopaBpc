using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using FanFest.Aplicacao.Interfaces.ServicosApp;
using FanFest.Aplicacao.ViewModels;
using FanFest.Dominio.Entidades;
using FanFest.Dominio.Interfaces.Servicos;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;

namespace FanFest.Aplicacao.ServicosApp
{
    public class UsuarioServicosApp : IUsuarioServicosApp
    {
        private readonly GerenciadorDeNotificacoes _notificacoes;
        private readonly IUsuarioServicos _servicos;
        private readonly IMapper _mapper;

        public UsuarioServicosApp(IUsuarioServicos servicos, IMapper mapper, INotificationHandler<NotificacaoDeDominio> notificacoes)
        {
            _servicos = servicos;
            _mapper = mapper;
            _notificacoes = (GerenciadorDeNotificacoes) notificacoes;    
        }

        object IUsuarioServicosApp.Login(UsuarioViewModel viewModel, Login login, Token token)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            var entrar = _servicos.Login(usuario);

            bool usuarioValido = entrar != null;

            if (usuarioValido)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(entrar.Apelido, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, entrar.Apelido)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(token.Segundos);

                var handler = new JwtSecurityTokenHandler();
                var secutityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = token.Emissor,
                    Audience = token.Publico,
                    SigningCredentials = login.Credenciais,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });

                var accesstoken = handler.WriteToken(secutityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = accesstoken,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        void IBaseServicosApp<UsuarioViewModel>.Atualizar(UsuarioViewModel viewModel)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Atualizar(usuario);
        }

        UsuarioViewModel IBaseServicosApp<UsuarioViewModel>.Buscar(Guid id)
        {
            var usuario = _servicos.Buscar(id);
            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<UsuarioViewModel>.Inserir(UsuarioViewModel viewModel)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Inserir(usuario);
        }

        IList<UsuarioViewModel> IBaseServicosApp<UsuarioViewModel>.Listar()
        {
            var usuarios = _servicos.Listar();
            return _mapper.Map<IList<UsuarioViewModel>>(usuarios);
        }

        void IBaseServicosApp<UsuarioViewModel>.Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        int IBaseServicosApp<UsuarioViewModel>.Salvar()
        {
            return _servicos.Salvar();
        }

        public void ReiniciarDatabase()
        {
            _servicos.ReiniciarDatabase();
        }

        public void Reservar(ReservarAlbumViewModel viewModel)
        {
            if (!ValidaCpf(viewModel.Cpf)) {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Cpf inválido."));
                return;
            }
            if (_servicos.ExisteCpf(viewModel.Cpf)) {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Este cpf já está cadastrado em nossa base."));
                return;
            }
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Inserir(usuario);
        }

        public bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}