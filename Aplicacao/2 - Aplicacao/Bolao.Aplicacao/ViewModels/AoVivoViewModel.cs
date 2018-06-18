using System.Collections.Generic;

namespace Bolao.Aplicacao.ViewModels
{
    public class AoVivoViewModel
    {
        public FixtureViewModel Jogo { get; set; }
        public IList<PalpiteReturnViewModel> Palpites { get; set; }
    }
}
