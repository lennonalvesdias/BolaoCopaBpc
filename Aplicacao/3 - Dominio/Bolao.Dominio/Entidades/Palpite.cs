﻿using RecursosCompartilhados.Dominio.Entidades;

namespace Bolao.Dominio.Entidades
{
    public class Palpite : BaseEntidade
    {
        public Palpite(string email, int mPlacar, int mTime, int vPlacar, int vTime)
        {
            Email = email;
            MandantePlacar = mPlacar;
            MandanteTime = (Equipe.Selecao)mTime;
            VisitantePlacar = vPlacar;
            VisitanteTime = (Equipe.Selecao)vTime;
        }

        public Palpite() { }

        public string Email { get; set; }
        public int MandantePlacar { get; private set; }
        public Equipe.Selecao MandanteTime { get; private set; }
        public int VisitantePlacar { get; private set; }
        public Equipe.Selecao VisitanteTime { get; private set; }
    }
}
