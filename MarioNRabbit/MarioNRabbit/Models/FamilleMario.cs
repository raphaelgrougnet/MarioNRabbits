using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public abstract class FamilleMario : Heros
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        private bool _estCompetenceUtilisee;

        public bool EstCompetenceUtilisee
        {
            get { return _estCompetenceUtilisee; }
            set { _estCompetenceUtilisee = value; }
        }

        #endregion

        #region PROPRIÉTÉS

        #endregion

        #region CONSTRUCTEURS
        public FamilleMario(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme) { Arme = pArme; }
        #endregion

        #region MÉTHODES
        public virtual void ActiverCompetenceSpeciale(){}
        
        public virtual void DesactiverCompetenceSpeciale(){}
        #endregion

    }
}
