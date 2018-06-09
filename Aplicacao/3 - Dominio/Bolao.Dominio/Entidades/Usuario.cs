using RecursosCompartilhados.Dominio.Entidades;

namespace Bolao.Dominio.Entidades
{
    public class Usuario : BaseEntidade
    {
        public Usuario(string apelido, string senha, int permissao)
        {
            Apelido = apelido;
            Senha = senha;
            Permissao = (Permissao)permissao;
        }

        public Usuario(string nome, string email, string apelido, string senha, int selecao)
        {
            Nome = nome;
            Email = email;
            Apelido = apelido;
            Senha = senha;
            SelecaoDoCoracao = (Equipe.Selecao)selecao;
            Permissao = Permissao.Visitante;
        }

        public Usuario() { }

        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public string Senha { get; private set; }
        public Permissao Permissao { get; private set; }
        public string Email { get; private set; }
        public Equipe.Selecao SelecaoDoCoracao { get; private set; }
    }

    public enum Permissao
    {
        Visitante = 0,
        Administrador = 99
    }
}