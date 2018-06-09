using RecursosCompartilhados.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bolao.Aplicacao.ViewModels
{
    public class PalpiteSendViewModel : BaseEntidade
    {
        [MinLength(2, ErrorMessage = "O apelido deve conter ao menos 2 letras.")]
        [MaxLength(50, ErrorMessage = "O apelido deve conter no máximo 50 letras.")]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        [DisplayName("Placar do Mandante")]
        public int MandantePlacar { get; set; }

        [DisplayName("Time Mandante")]
        public int MandanteTime { get; set; }

        [DisplayName("Placar do Visitante")]
        public int VisitantePlacar { get; set; }

        [DisplayName("Time Visitante")]
        public int VisitanteTime { get; set; }
    }

    public class PalpiteReturnViewModel : BaseEntidade
    {
        public string Apelido { get; set; }
        public int MandantePlacar { get; set; }
        public int MandanteTime { get; set; }
        public int VisitantePlacar { get; set; }
        public int VisitanteTime { get; set; }
    }
}
