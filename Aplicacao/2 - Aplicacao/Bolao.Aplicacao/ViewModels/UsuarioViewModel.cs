using RecursosCompartilhados.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bolao.Aplicacao.ViewModels
{
    public class UsuarioSendViewModel : BaseEntidade
    {
        [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 letras.")]
        [MaxLength(250, ErrorMessage = "O nome deve conter no máximo 250 letras.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [MinLength(2, ErrorMessage = "O apelido deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O apelido deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "O apelido é obrigatório.")]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [MinLength(2, ErrorMessage = "A senha deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [RegularExpression(".+\\@bompracredito\\.com\\.br$", ErrorMessage = "O seu e-mail não é Bom pra Crédito.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Seleção do Coração")]
        public int SelecaoDoCoracao { get; set; }
    }

    public class UsuarioReturnViewModel : BaseEntidade
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public int Permissao { get; set; }
        public string Email { get; set; }
        public int SelecaoDoCoracao { get; set; }
    }

    public class UsuarioLoginViewModel
    {
        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [RegularExpression(".+\\@bompracredito\\.com\\.br$", ErrorMessage = "O seu e-mail não é Bom pra Crédito.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [MinLength(2, ErrorMessage = "A senha deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }

    public class UsuarioNovaSenhaViewModel
    {
        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [RegularExpression(".+\\@bompracredito\\.com\\.br$", ErrorMessage = "O seu e-mail não é Bom pra Crédito.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [MinLength(2, ErrorMessage = "A senha deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DisplayName("Nova Senha")]
        public string NovaSenha { get; set; }

        [MinLength(2, ErrorMessage = "A senha deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DisplayName("Confirmacao Nova Senha")]
        public string NovaSenhaConfirmacao { get; set; }
    }
}