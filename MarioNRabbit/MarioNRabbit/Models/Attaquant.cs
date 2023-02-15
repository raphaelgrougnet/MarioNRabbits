using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public abstract class Attaquant : Personnage
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        
        /// <summary>
        /// Arme de l'attaquant
        /// </summary>
        private ArmeAttaquer _arme;


        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Arme de l'attaquant
        /// </summary>
        public ArmeAttaquer Arme
        {
            get { return _arme; }
            set { _arme = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructeur de la classe Attaquant
        /// </summary>
        /// <param name="pNom">Nom de l'attaquant</param>
        /// <param name="pPositionX">Coordonnée X de l'attaquant</param>
        /// <param name="pPositionY">Coordonnée Y de l'attaquant</param>
        /// <param name="pNbCasesDeplacementMax">Nombre de case de déplacement max de l'attaquant</param>
        /// <param name="pNbPointsVie">Nombre de points de vie de l'attaquant</param>
        /// <param name="pArme">Arme de l'attaquant</param>
        public Attaquant(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie)
        {
            Arme = pArme;
        }
        #endregion

        #region MÉTHODES
        
        /// <summary>
        /// Methode permettant d'attaquer
        /// </summary>
        /// <param name="pPersoAttaquant">Personnage qui inflige les dégats</param>
        /// <param name="pPersoCible">Personnage qui subit les dégats</param>
        /// <returns></returns>
        public bool Attaquer(Personnage pPersoAttaquant, Personnage pPersoCible)
        {
            if (pPersoAttaquant is Attaquant)
            {

                Attaquant attaquant = pPersoAttaquant as Attaquant;
                pPersoCible.NbPointsVie -= attaquant.Arme.NbPointsDegat;
                return true;
            }
            return false;

        }
        #endregion










    }
}
