using RecursosCompartilhados.Dominio.Entidades;

namespace Bolao.Dominio.Entidades
{
    public class Resultado : BaseEntidade
    {
        public Resultado(int mPlacar, int mTime, bool mVitoria, int vPlacar, int vTime, bool vVitoria)
        {
            MandantePlacar = mPlacar;
            MandanteTime = (Equipe.Selecao)mTime;
            MandanteVitoria = mVitoria;
            VisitantePlacar = vPlacar;
            VisitanteTime = (Equipe.Selecao)vTime;
            VisitanteVitoria = vVitoria;
        }

        public Resultado() { }

        public int MandantePlacar { get; private set; }
        public Equipe.Selecao MandanteTime { get; private set; }
        public bool MandanteVitoria { get; private set; }
        public int VisitantePlacar { get; private set; }
        public Equipe.Selecao VisitanteTime { get; private set; }
        public bool VisitanteVitoria { get; private set; }
    }
}
