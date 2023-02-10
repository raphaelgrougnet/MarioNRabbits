using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Peach : FamilleMario
    {
        public Peach(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie, pArme)
        {
            Arme = pArme;
        }

        private bool compActivee = false;

        public override void ActiverCompetenceSpeciale()
        {
            compActivee = true;
            NbPointsVie += 5;
        }

        public override void DesactiverCompetenceSpeciale()
        {
            if (NbPointsVie > 5 && compActivee)
            {
                NbPointsVie -= 5;
                compActivee = false;
            }
        }
    }
}
