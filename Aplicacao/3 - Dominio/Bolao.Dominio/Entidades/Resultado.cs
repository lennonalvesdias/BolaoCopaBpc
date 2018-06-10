using RecursosCompartilhados.Dominio.Entidades;

namespace Bolao.Dominio.Entidades
{
    public class Resultado : BaseEntidade
    {
        public Resultado(int mPlacar, int mTime, int vPlacar, int vTime)
        {
            MandantePlacar = mPlacar;
            MandanteTime = (Equipe.Selecao)mTime;
            VisitantePlacar = vPlacar;
            VisitanteTime = (Equipe.Selecao)vTime;
        }

        public Resultado() { }

        public int MandantePlacar { get; private set; }
        public Equipe.Selecao MandanteTime { get; private set; }
        public int VisitantePlacar { get; private set; }
        public Equipe.Selecao VisitanteTime { get; private set; }
    }
}
