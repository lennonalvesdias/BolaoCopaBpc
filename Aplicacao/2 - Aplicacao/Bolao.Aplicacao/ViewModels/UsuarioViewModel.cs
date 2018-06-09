using RecursosCompartilhados.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bolao.Aplicacao.ViewModels
{
    public class UsuarioSendViewModel : BaseEntidade
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

        [DisplayName("Permissão")]
        public int Permissao { get; set; }

        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }

    public class UsuarioReturnViewModel : BaseEntidade
    {
        [MinLength(2, ErrorMessage = "O nome deve conter ao menos 2 letras.")]
        [MaxLength(250, ErrorMessage = "O nome deve conter no máximo 250 letras.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [MinLength(2, ErrorMessage = "O apelido deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O apelido deve conter no máximo 50 letras.")]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [DisplayName("Permissão")]
        public int Permissao { get; set; }

        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }

    public class UsuarioLoginViewModel
    {
        [MinLength(2, ErrorMessage = "O apelido deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O apelido deve conter no máximo 50 letras.")]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [MinLength(2, ErrorMessage = "A senha deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "A senha deve conter no máximo 50 letras.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}