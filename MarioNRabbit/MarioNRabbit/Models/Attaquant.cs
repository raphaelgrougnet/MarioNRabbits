using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    internal class Attaquant : Personnage
    {
        public Attaquant(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie)
        {
        }

        public bool Attaquer(Personnage pPersoAttaquant, Personnage pPersoCible)
        {
            return true;
        }
            
    }
}
