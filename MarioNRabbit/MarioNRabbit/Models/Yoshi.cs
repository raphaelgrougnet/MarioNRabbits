using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Yoshi : FamilleMario
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS

        #endregion

        #region PROPRIÉTÉS

        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructeur de Yoshi
        /// </summary>
        /// <param name="pNom"></param>
        /// <param name="pPositionX"></param>
        /// <param name="pPositionY"></param>
        /// <param name="pNbCasesDeplacementMax"></param>
        /// <param name="pNbPointsVie"></param>
        /// <param name="pArme"></param>
        public Yoshi(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme)
        {
            Arme = pArme;
        }
        #endregion

        #region MÉTHODES
        /// <summary>
        /// Méthode qui permet d'activer la compétence spéciale de Yoshi
        /// </summary>
        public override void ActiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax += 2;
            EstCompetenceUtilisee = true;
        }

        /// <summary>
        /// Méthode qui permet de désactiver la compétence spéciale deYoshi
        /// </summary>
        public override void DesactiverCompetenceSpeciale()
        {
            if (EstCompetenceUtilisee)
            {
                NbCasesDeplacementMax -= 2;
                EstCompetenceUtilisee = false;
            }

        }
        #endregion




    }
}
