using RecursosCompartilhados.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FanFest.Aplicacao.ViewModels
{
    public class UsuarioViewModel : BaseEntidade
    {
        [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 letras.")]
        [MaxLength(250, ErrorMessage = "O nome deve conter no máximo 250 letras.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [MinLength(2, ErrorMessage = "O apelido deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O apelido deve conter no máximo 50 letras.")]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [MinLength(2, ErrorMessage = "A senha deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 letras.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [DisplayName("Endereço")]
        public EnderecoViewModel Endereco { get; set; }

        [DisplayName("Permissão")]
        public int Permissao { get; set; }

        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        public TelefoneViewModel Telefone { get; set; }

        [StringLength(11, ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
    }

    public class EnderecoViewModel
    {
        [DisplayName("Rua")]
        public string Rua { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("Estado")]
        public string Estado { get; set; }
    }

    public class TelefoneViewModel
    {
        [StringLength(2, ErrorMessage = "O código de área deve conter exatamente 2 dígitos.")]
        [DisplayName("Código de Área")]
        public string CodigoArea { get; set; }

        [MinLength(8, ErrorMessage = "O telefone deve conter no mínimo 8 dígitos.")]
        [MaxLength(9, ErrorMessage = "O telefone deve conter no máximo 9 dígitos.")]
        [DisplayName("Número")]
        public string Numero { get; set; }
    }

    // MODELS ESPECIFICAS DE USUARIO

    public class ReservarAlbumViewModel
    {
        [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 letras.")]
        [MaxLength(250, ErrorMessage = "O nome deve conter no máximo 250 letras.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Endereço")]
        public EnderecoViewModel Endereco { get; set; }

        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        public TelefoneViewModel Telefone { get; set; }

        [StringLength(11, ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
    }
}