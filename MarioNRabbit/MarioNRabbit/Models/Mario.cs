using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Mario : FamilleMario
    {
        
        public Mario(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme) 
        {
            Arme = pArme;
        }


        private bool compActivee = false;
        public override void ActiverCompetenceSpeciale()
        {
            Arme.NbPointsDegat += 3;
            compActivee = true;
        }

        public override void DesactiverCompetenceSpeciale()
        {
            if (compActivee)
            {
                Arme.NbPointsDegat -= 3;
                compActivee = false;
            }
            
        }
    }
}
