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
        /// <summary>
        /// Attribut qui permet de savoir si la compétence spéciale de la famille Mario est utilisée ou non
        /// </summary>
        private bool _estCompetenceUtilisee;

        /// <summary>
        /// Attribut qui permet de savoir si la compétence spéciale de la famille Mario est utilisée ou non
        /// </summary>
        public bool EstCompetenceUtilisee
        {
            get { return _estCompetenceUtilisee; }
            set { _estCompetenceUtilisee = value; }
        }

        #endregion

        #region PROPRIÉTÉS

        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructeur de FamilleMario
        /// </summary>
        /// <param name="pNom"></param>
        /// <param name="pPositionX"></param>
        /// <param name="pPositionY"></param>
        /// <param name="pNbCasesDeplacementMax"></param>
        /// <param name="pNbPointsVie"></param>
        /// <param name="pArme"></param>
        public FamilleMario(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme) { Arme = pArme; }
        #endregion

        #region MÉTHODES
        /// <summary>
        /// Méthode qui permet d'activer la compétence spéciale de la famille Mario
        /// </summary>
        public virtual void ActiverCompetenceSpeciale(){}

        /// <summary>
        /// Méthode qui permet de désactiver la compétence spéciale de la famille Mario
        /// </summary>
        public virtual void DesactiverCompetenceSpeciale(){}
        #endregion

    }
}
