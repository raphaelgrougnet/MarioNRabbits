using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public abstract class ArmeAttaquer
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private string _nom;

        private int _nbPointsDegat;

        private int _nbCasesDistanceMax;

        #endregion

        #region PROPRIÉTÉS
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int NbPointsDegat
        {
            get { return _nbPointsDegat; }
            set { _nbPointsDegat = value; }
        }
        public int NbCasesDistanceMax
        {
            get { return _nbCasesDistanceMax; }
            set { _nbCasesDistanceMax = value; }
        }


        #endregion

        #region CONSTRUCTEURS
        protected ArmeAttaquer(string nom, int nbPointsDegat, int nbCasesDistanceMax)
        {
            Nom = nom;
            NbPointsDegat = nbPointsDegat;
            NbCasesDistanceMax = nbCasesDistanceMax;
        }
        #endregion

        #region MÉTHODES

        #endregion

    }
}
