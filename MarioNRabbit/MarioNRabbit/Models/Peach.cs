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
        
        private int _ptVie = 0;

        public override void ActiverCompetenceSpeciale()
        {
            EstCompetenceUtilisee = true;
            _ptVie = NbPointsVie;
            NbPointsVie += 5;
        }

        public override void DesactiverCompetenceSpeciale()
        {
            if (NbPointsVie > _ptVie  && EstCompetenceUtilisee)
            {
                NbPointsVie -= 5;
                EstCompetenceUtilisee = false;
            }
        }
    }
}
