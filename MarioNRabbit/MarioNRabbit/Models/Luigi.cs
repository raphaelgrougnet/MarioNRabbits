using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Luigi : FamilleMario
    {
        public Luigi(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme) { Arme = pArme; }


        public override void ActiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax += 2;
            EstCompetenceUtilisee = true;
        }

        public override void DesactiverCompetenceSpeciale()
        {
            if (EstCompetenceUtilisee)
            {
                NbCasesDeplacementMax -= 2;
                EstCompetenceUtilisee = false;
            }
            
        }
    }
}
