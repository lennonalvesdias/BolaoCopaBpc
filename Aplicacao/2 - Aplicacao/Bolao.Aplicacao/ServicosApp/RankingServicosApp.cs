using AutoMapper;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Aplicacao.ServicosApp
{
    public class RankingServicosApp : IRankingServicosApp
    {
        private readonly IUsuarioServicos _usuarioServicos;
        private readonly IPalpiteServicos _palpiteServicos;
        private readonly IResultadoServicos _resultadoServicos;
        private readonly IMapper _mapper;

        public RankingServicosApp(IUsuarioServicos usuarioServicos, IPalpiteServicos palpiteServicos, IResultadoServicos resultadoServicos, IMapper mapper)
        {
            _usuarioServicos = usuarioServicos;
            _palpiteServicos = palpiteServicos;
            _resultadoServicos = resultadoServicos;
            _mapper = mapper;
        }

        public List<RankingViewModel> Calcular()
        {
            var resultados = _resultadoServicos.Listar();

            var placar = new Dictionary<string, int>();

            foreach (var resultado in resultados)
            {
                var palpitesJogo = _palpiteServicos.ListarPorJogo(resultado.MandanteTime, resultado.VisitanteTime);
                foreach (var palpite in palpitesJogo)
                {
                    var pontosPalpite = 0;

                    if (palpite.MandantePlacar == resultado.MandantePlacar && palpite.VisitantePlacar == resultado.VisitantePlacar)
                    {
                        pontosPalpite = 10;
                    }
                    else if (palpite.MandanteVitoria == resultado.MandanteVitoria && palpite.VisitanteVitoria == resultado.VisitanteVitoria)
                    {
                        pontosPalpite = 3;
                    }

                    if (!placar.ContainsKey(palpite.Email))
                    {
                        placar.Add(palpite.Email, pontosPalpite);
                    } else
                    {
                        placar[palpite.Email] += pontosPalpite;
                    }
                }
            }

            var rankingGeral = new List<RankingViewModel>();

            foreach(var p in placar)
            {
                var palpitesUsuario = _palpiteServicos.ListarPorUsuario(p.Key);
                var palpitesUsuarioVm = _mapper.Map<IList<PalpiteReturnViewModel>>(palpitesUsuario);

                var usuario = _usuarioServicos.GetByEmail(p.Key);
                var usuarioVm = _mapper.Map<UsuarioReturnViewModel>(usuario);

                var ranking = new RankingViewModel
                {
                    Usuario = usuarioVm,
                    Palpites = palpitesUsuarioVm,
                    Pontos = p.Value
                };

                rankingGeral.Add(ranking);
            }

            return rankingGeral.OrderByDescending(x => x.Pontos).ToList();
        }
    }
}
