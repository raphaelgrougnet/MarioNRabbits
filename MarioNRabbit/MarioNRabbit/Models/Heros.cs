using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public abstract class Heros : Attaquant
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        
        
        #endregion

        #region PROPRIÉTÉS

        #endregion

        #region CONSTRUCTEURS
        public Heros(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme)
        {
            Arme = pArme;
        }
        #endregion

        #region MÉTHODES

        #endregion

    }
}
