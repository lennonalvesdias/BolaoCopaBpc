using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using AutoMapper;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Servicos;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using RecursosCompartilhados.Aplicacao.Interfaces.ServicosApp;
using RecursosCompartilhados.Dominio.Entidades;
using RecursosCompartilhados.Dominio.Notificacoes;

namespace Bolao.Aplicacao.ServicosApp
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

        object IUsuarioServicosApp.Login(UsuarioLoginViewModel viewModel, Login login, Token token)
        {
            viewModel.Senha = CalculaHash(viewModel.Senha);
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

        void IBaseServicosApp<UsuarioSendViewModel, UsuarioReturnViewModel>.Atualizar(UsuarioSendViewModel viewModel)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Atualizar(usuario);
        }

        UsuarioReturnViewModel IBaseServicosApp<UsuarioSendViewModel, UsuarioReturnViewModel>.Buscar(Guid id)
        {
            var usuario = _servicos.Buscar(id);
            return _mapper.Map<UsuarioReturnViewModel>(usuario);
        }

        void IDisposable.Dispose()
        {
            _servicos.Dispose();
        }

        void IBaseServicosApp<UsuarioSendViewModel, UsuarioReturnViewModel>.Inserir(UsuarioSendViewModel viewModel)
        {
            viewModel.Senha = CalculaHash(viewModel.Senha);
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Inserir(usuario);
        }

        IList<UsuarioReturnViewModel> IBaseServicosApp<UsuarioSendViewModel, UsuarioReturnViewModel>.Listar()
        {
            var usuarios = _servicos.Listar();
            return _mapper.Map<IList<UsuarioReturnViewModel>>(usuarios);
        }

        void IBaseServicosApp<UsuarioSendViewModel, UsuarioReturnViewModel>.Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        int IBaseServicosApp<UsuarioSendViewModel, UsuarioReturnViewModel>.Salvar()
        {
            return _servicos.Salvar();
        }

        private static string CalculaHash(string senha)
        {
            try
            {
                var md5 = System.Security.Cryptography.MD5.Create();
                var inputBytes = Encoding.ASCII.GetBytes(senha);
                var hash = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                foreach (var t in hash)
                {
                    sb.Append(t.ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}