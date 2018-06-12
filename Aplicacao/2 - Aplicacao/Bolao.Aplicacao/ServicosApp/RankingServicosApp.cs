using AutoMapper;
using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Entidades;
using Bolao.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Aplicacao.ServicosApp
{
    public class RankingServicosApp : IRankingServicosApp
    {
        private readonly IResultadoServicosApp _resultadoServicosApp;
        private readonly IUsuarioServicos _usuarioServicos;
        private readonly IPalpiteServicos _palpiteServicos;
        private readonly IMapper _mapper;

        public RankingServicosApp(IResultadoServicosApp resultadoServicosApp, IUsuarioServicos usuarioServicos, IPalpiteServicos palpiteServicos, IMapper mapper)
        {
            _resultadoServicosApp = resultadoServicosApp;
            _usuarioServicos = usuarioServicos;
            _palpiteServicos = palpiteServicos;
            _mapper = mapper;
        }

        public List<RankingViewModel> Calcular()
        {
            var resultados = _resultadoServicosApp.Listar();

            var placar = new Dictionary<string, int>();

            foreach (var resultado in resultados)
            {
                if (resultado.Result.GoalsHomeTeam == null || resultado.Result.GoalsAwayTeam == null) continue;

                // 0 = MANDANTE // 1 = VISITANTE // 2 = EMPATE
                var resultadoJogo = resultado.Result.GoalsHomeTeam > resultado.Result.GoalsAwayTeam ? 0 : resultado.Result.GoalsHomeTeam < resultado.Result.GoalsAwayTeam ? 1 : 2;

                var mandanteTime = resultado.Links.HomeTeam.Href;
                var lastIndexMandante = mandanteTime.LastIndexOf("/");
                var mandanteCodigo = mandanteTime.Substring(lastIndexMandante + 1, 3);

                var visitanteTime = resultado.Links.AwayTeam.Href;
                var lastIndexVisitante = visitanteTime.LastIndexOf("/");
                var visitanteCodigo = visitanteTime.Substring(lastIndexVisitante + 1, 3);

                var palpitesJogo = _palpiteServicos.ListarPorJogo((Equipe.Selecao)Convert.ToInt32(mandanteCodigo), (Equipe.Selecao)Convert.ToInt32(visitanteCodigo));
                foreach (var palpite in palpitesJogo)
                {
                    var pontosPalpite = 0;

                    if (palpite.MandantePlacar == resultado.Result.GoalsHomeTeam && palpite.VisitantePlacar == resultado.Result.GoalsAwayTeam)
                    {
                        pontosPalpite = 10;
                    }
                    else if (palpite.MandanteVitoria == true && resultadoJogo == 0 || palpite.VisitanteVitoria == true && resultadoJogo == 1
                        || palpite.MandanteVitoria == false && palpite.VisitanteVitoria == false && resultadoJogo == 2)
                    {
                        pontosPalpite = 3;
                    }

                    if (!placar.ContainsKey(palpite.Email))
                    {
                        placar.Add(palpite.Email, pontosPalpite);
                    }
                    else
                    {
                        placar[palpite.Email] += pontosPalpite;
                    }
                }
            }

            var rankingGeral = new List<RankingViewModel>();

            foreach (var p in placar)
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
