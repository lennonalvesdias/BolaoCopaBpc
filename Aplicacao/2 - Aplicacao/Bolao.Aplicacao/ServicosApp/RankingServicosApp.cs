using Bolao.Aplicacao.Interfaces.ServicosApp;
using Bolao.Aplicacao.ViewModels;
using Bolao.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace Bolao.Aplicacao.ServicosApp
{
    public class RankingServicosApp : IRankingServicosApp
    {
        private readonly IUsuarioServicos _usuarioServicos;
        private readonly IPalpiteServicos _palpiteServicos;

        public RankingServicosApp(IUsuarioServicos usuarioServicos, IPalpiteServicos palpiteServicos)
        {
            _usuarioServicos = usuarioServicos;
            _palpiteServicos = palpiteServicos;
        }

        public List<RankingViewModel> Calcular()
        {
            var usuarios = _usuarioServicos.Listar();
            return null;
        }
    }
}
