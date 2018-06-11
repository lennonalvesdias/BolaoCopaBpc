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
            _notificacoes = (GerenciadorDeNotificacoes)notificacoes;
        }

        public object Login(UsuarioLoginViewModel viewModel, Login login, Token token)
        {
            viewModel.Senha = CalculaHash(viewModel.Senha);
            var usuario = _mapper.Map<Usuario>(viewModel);
            var entrar = _servicos.Login(usuario);

            bool usuarioValido = entrar != null;

            if (usuarioValido)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(entrar.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, entrar.Email)
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

        public void Atualizar(UsuarioSendViewModel viewModel)
        {
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Atualizar(usuario);
        }

        public UsuarioReturnViewModel Buscar(Guid id)
        {
            var usuario = _servicos.Buscar(id);
            return _mapper.Map<UsuarioReturnViewModel>(usuario);
        }

        public void Dispose()
        {
            _servicos.Dispose();
        }

        public void Inserir(UsuarioSendViewModel viewModel)
        {
            var usuarioBase = GetByLogin(viewModel.Apelido);
            if (usuarioBase != null)
            {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Já existe um usuário com este apelido."));
                return;
            }

            usuarioBase = GetByEmail(viewModel.Email);
            if (usuarioBase != null)
            {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Já existe um usuário com este e-mail."));
                return;
            }

            viewModel.Senha = CalculaHash(viewModel.Senha);
            var usuario = _mapper.Map<Usuario>(viewModel);
            _servicos.Inserir(usuario);
        }

        public IList<UsuarioReturnViewModel> Listar()
        {
            var usuarios = _servicos.Listar();
            return _mapper.Map<IList<UsuarioReturnViewModel>>(usuarios);
        }

        public void Remover(Guid id)
        {
            _servicos.Remover(id);
        }

        public int Salvar()
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

        private Usuario GetByLogin(string apelido)
        {
            return _servicos.GetByLogin(apelido);
        }

        private Usuario GetByEmail(string email)
        {
            return _servicos.GetByEmail(email);
        }

        public void NovaSenha(UsuarioNovaSenhaViewModel viewModel)
        {
            if (viewModel.NovaSenha != viewModel.NovaSenhaConfirmacao)
            {
                _notificacoes.Adicionar(new NotificacaoDeDominio(string.Empty, "Sua senha e a confirmação devem ser iguais."));
                return;
            }

            var novaSenha = CalculaHash(viewModel.NovaSenha);

            var usuarioByEmail = _servicos.GetByEmail(viewModel.Email);

            var usuarioSend = new UsuarioSendViewModel
            {
                Apelido = usuarioByEmail.Apelido,
                DataAtualizacaoRegistro = usuarioByEmail.DataAtualizacaoRegistro,
                DataCriacaoRegistro = usuarioByEmail.DataCriacaoRegistro,
                Email = usuarioByEmail.Email,
                Id = usuarioByEmail.Id,
                Nome = usuarioByEmail.Nome,
                SelecaoDoCoracao = (int)usuarioByEmail.SelecaoDoCoracao,
                Senha = novaSenha
            };

            var usuario = _mapper.Map<Usuario>(usuarioSend);
            _servicos.Atualizar(usuario);
        }
    }
}