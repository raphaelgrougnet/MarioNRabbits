using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Yoshi : FamilleMario
    {
        public Yoshi(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme)
        {
            Arme = pArme;
        }
        private bool compActivee = false;
        public override void ActiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax += 2;
        }

        public override void DesactiverCompetenceSpeciale()
        {
            if (compActivee)
            {
                NbCasesDeplacementMax -= 2;
                compActivee = false;
            }
            
        }
    }
}
