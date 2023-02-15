using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class ArmeAttaquer
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private string _nom;

        private int _nbPointsDegat;

        private int _nbCasesDistanceMax;

        #endregion

        #region PROPRIÉTÉS
        /// <summary>
        /// Nom de l'arme
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Nombre de points de dégâts infligés par l'arme
        /// </summary>
        public int NbPointsDegat
        {
            get { return _nbPointsDegat; }
            set { _nbPointsDegat = value; }
        }

        /// <summary>
        /// Nombre de cases de distance maximum pour attaquer avec l'arme
        /// </summary>
        public int NbCasesDistanceMax
        {
            get { return _nbCasesDistanceMax; }
            set { _nbCasesDistanceMax = value; }
        }


        #endregion

        /// <summary>
        /// Constructeur de l'arme
        /// </summary>
        /// <param name="pNom">Nom de l'arme</param>
        /// <param name="pNbPointsDegat">Nombre de points de dégâts infligés par l'arme</param>
        /// <param name="pNbCasesDistanceMax">Nombre de cases de distance maximum pour attaquer avec l'arme</param>
        #region CONSTRUCTEURS
        public ArmeAttaquer(string pNom, int pNbPointsDegat, int pNbCasesDistanceMax)
        {
            Nom = pNom;
            NbPointsDegat = pNbPointsDegat;
            NbCasesDistanceMax = pNbCasesDistanceMax;
        }
        #endregion

        #region MÉTHODES

        #endregion

    }
}
