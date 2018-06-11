using Microsoft.AspNetCore.Mvc;
using RecursosCompartilhados.Dominio.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bolao.Aplicacao.ViewModels
{
    public class ResultadoSendViewModel : BaseEntidade
    {
        [DisplayName("Placar do Mandante")]
        [Required(ErrorMessage = "O placar do mandante é obrigatório.")]
        public int MandantePlacar { get; set; }

        [DisplayName("Time Mandante")]
        [Required(ErrorMessage = "O time mandante é obrigatório.")]
        public int MandanteTime { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool MandanteVitoria { get; set; }

        [DisplayName("Placar do Visitante")]
        [Required(ErrorMessage = "O placar do visitante é obrigatório.")]
        public int VisitantePlacar { get; set; }

        [DisplayName("Time Visitante")]
        [Required(ErrorMessage = "O time visitante é obrigatório.")]
        public int VisitanteTime { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool VisitanteVitoria { get; set; }
    }

    public class ResultadoReturnViewModel : BaseEntidade
    {
        public int MandantePlacar { get; private set; }
        public int MandanteTime { get; private set; }
        public int VisitantePlacar { get; private set; }
        public int VisitanteTime { get; private set; }
    }
}
