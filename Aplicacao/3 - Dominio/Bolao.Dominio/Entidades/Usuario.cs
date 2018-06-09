using RecursosCompartilhados.Dominio.Entidades;

namespace Bolao.Dominio.Entidades
{
    public class Usuario : BaseEntidade
    {
        public Usuario(string apelido, string senha, int permissao)
        {
            Apelido = apelido;
            Senha = senha;
            Permissao = (Permissao) permissao;
        }

        public Usuario(string nome, Endereco endereco, string email, Telefone telefone, string cpf)
        {
            Nome = nome;
            Permissao = Permissao.Visitante;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
        }

        public Usuario() {}

        public string Nome {get; private set;}
        public string Apelido {get; private set;}
        public string Senha {get; private set;}
        public Permissao Permissao {get; private set;}
        public Endereco Endereco {get; private set;}
        public string Email {get; private set;}
        public Telefone Telefone {get; private set;}
        public string Cpf {get; private set;}
    }

    public enum Permissao {
        Administrador = 0,
        Visitante = 1
    }

    public class Endereco
    {
        public string Rua {get; private set;}
        public string Numero {get; private set;}        
        public string Complemento {get; private set;}
        public string Bairro {get; private set;}
        public string Cidade {get; private set;}
        public string Estado {get; private set;}
    }

    public class Telefone
    {
        public string CodigoArea {get; private set;}
        public string Numero {get; private set;}
    }
}