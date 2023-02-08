using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public abstract class Attaquant : Personnage
    {
        public Attaquant(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie, ArmeAttaquer pArme) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie)
        {
            Arme = pArme;
        }

        private ArmeAttaquer _arme;

        public ArmeAttaquer Arme
        {
            get { return _arme; }
            set { _arme = value; }
        }


        public bool Attaquer(Personnage pPersoAttaquant, Personnage pPersoCible)
        {
            return true;
        }
            
    }
}
