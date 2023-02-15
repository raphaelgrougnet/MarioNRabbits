using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Peach : FamilleMario
    {


        #region CONSTANTES

        #endregion

        #region ATTRIBUTS
        /// <summary>
        /// Points de vie avant d'utiliser la compétence spéciale
        /// </summary>
        private int _ptVie = 0;
        #endregion

        #region PROPRIÉTÉS

        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Constructeur de la classe Peach
        /// </summary>
        /// <param name="pNom"></param>
        /// <param name="pPositionX"></param>
        /// <param name="pPositionY"></param>
        /// <param name="pNbCasesDeplacementMax"></param>
        /// <param name="pNbPointsVie"></param>
        /// <param name="pArme"></param>
        public Peach(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme)
        {
            Arme = pArme;
        }
        #endregion

        #region MÉTHODES
        /// <summary>
        /// Activer la compétence spéciale de Peach
        /// </summary>
        public override void ActiverCompetenceSpeciale()
        {
            EstCompetenceUtilisee = true;
            _ptVie = NbPointsVie;
            NbPointsVie += 5;
        }

        /// <summary>
        /// Désactiver la compétence spéciale de Peach
        /// </summary>
        public override void DesactiverCompetenceSpeciale()
        {
            if (NbPointsVie > _ptVie && EstCompetenceUtilisee)
            {
                NbPointsVie -= 5;
                EstCompetenceUtilisee = false;
            }
        }
        #endregion









    }
}
