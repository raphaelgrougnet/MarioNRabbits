using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Ennemi : Personnage, IAttaquer
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private ArmeAttaquer _armeAttaque { get; set; }

        #endregion

        #region PROPRIÉTÉS
        public ArmeAttaquer ArmeAttaque
        {
            get { return _armeAttaque; }
            set { _armeAttaque = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Ennemi(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie)
        {
            ArmeAttaque = pArme;
        }
        
        #endregion

        #region MÉTHODES

        #endregion





        
    }
}
