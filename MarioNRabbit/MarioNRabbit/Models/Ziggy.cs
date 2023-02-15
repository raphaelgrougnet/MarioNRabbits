using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{

    #region CONSTANTES

    #endregion

    #region ATTRIBUTS

    #endregion

    #region PROPRIÉTÉS

    #endregion

    #region CONSTRUCTEURS
    /// <summary>
    /// Constructeur de Ziggy
    /// </summary>
    public class Ziggy : Ennemi
    {
        public Ziggy(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme) { Arme = pArme; }
    }
    #endregion

    #region MÉTHODES

    #endregion


}
