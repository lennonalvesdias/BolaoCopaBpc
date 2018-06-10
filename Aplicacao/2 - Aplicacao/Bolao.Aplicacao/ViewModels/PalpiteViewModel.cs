using RecursosCompartilhados.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bolao.Aplicacao.ViewModels
{
    public class PalpiteSendViewModel : BaseEntidade
    {
        [MinLength(2, ErrorMessage = "O e-mail deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O e-mail deve conter no máximo 50 letras.")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [RegularExpression(".+\\@bompracredito\\.com\\.br$", ErrorMessage = "O seu e-mail não é Bom pra Crédito.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Placar do Mandante")]
        [Required(ErrorMessage = "O placar do mandante é obrigatório.")]
        public int MandantePlacar { get; set; }

        [DisplayName("Time Mandante")]
        [Required(ErrorMessage = "O time mandante é obrigatório.")]
        public int MandanteTime { get; set; }

        [DisplayName("Placar do Visitante")]
        [Required(ErrorMessage = "O placar do visitante é obrigatório.")]
        public int VisitantePlacar { get; set; }

        [DisplayName("Time Visitante")]
        [Required(ErrorMessage = "O time visitante é obrigatório.")]
        public int VisitanteTime { get; set; }
    }

    public class PalpiteReturnViewModel : BaseEntidade
    {
        public string Email { get; set; }
        public int MandantePlacar { get; set; }
        public int MandanteTime { get; set; }
        public int VisitantePlacar { get; set; }
        public int VisitanteTime { get; set; }
    }
}
