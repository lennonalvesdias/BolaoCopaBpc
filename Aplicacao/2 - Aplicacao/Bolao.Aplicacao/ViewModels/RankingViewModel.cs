using System.Collections.Generic;

namespace Bolao.Aplicacao.ViewModels
{
    public class RankingViewModel
    {
        public int Pontos { get; set; }
        public UsuarioReturnViewModel Usuario { get; set; }
        public IList<PalpiteReturnViewModel> Palpites { get; set; }
    }
}
