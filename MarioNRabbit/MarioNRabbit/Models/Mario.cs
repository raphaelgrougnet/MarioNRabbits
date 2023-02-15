using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Mario : FamilleMario
    {
        /// <summary>
        /// Constructeur de Mario
        /// </summary>
        /// <param name="pNom"></param>
        /// <param name="pPositionX"></param>
        /// <param name="pPositionY"></param>
        /// <param name="pNbCasesDeplacementMax"></param>
        /// <param name="pNbPointsVie"></param>
        /// <param name="pArme"></param>
        public Mario(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme) 
        {
            Arme = pArme;
        }


        /// <summary>
        /// Méthode qui permet d'activer la compétence spéciale de Mario
        /// </summary>
        public override void ActiverCompetenceSpeciale()
        {
            Arme.NbPointsDegat += 3;
            EstCompetenceUtilisee = true;
        }

        /// <summary>
        /// Méthode qui permet de désactiver la compétence spéciale de Mario
        /// </summary>
        public override void DesactiverCompetenceSpeciale()
        {
            if (EstCompetenceUtilisee)
            {
                Arme.NbPointsDegat -= 3;
                EstCompetenceUtilisee = false;
            }
            
        }
    }
}
