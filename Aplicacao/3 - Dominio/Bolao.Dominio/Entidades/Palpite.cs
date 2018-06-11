using RecursosCompartilhados.Dominio.Entidades;

namespace Bolao.Dominio.Entidades
{
    public class Palpite : BaseEntidade
    {
        public Palpite(string email, int mPlacar, int mTime, bool mVitoria, int vPlacar, int vTime, bool vVitoria)
        {
            Email = email;
            MandantePlacar = mPlacar;
            MandanteTime = (Equipe.Selecao)mTime;
            MandanteVitoria = mVitoria;
            VisitantePlacar = vPlacar;
            VisitanteTime = (Equipe.Selecao)vTime;
            VisitanteVitoria = vVitoria;
        }

        public Palpite() { }

        public string Email { get; set; }
        public int MandantePlacar { get; private set; }
        public Equipe.Selecao MandanteTime { get; private set; }
        public bool MandanteVitoria { get; private set; }
        public int VisitantePlacar { get; private set; }
        public Equipe.Selecao VisitanteTime { get; private set; }
        public bool VisitanteVitoria { get; private set; }
    }
}
