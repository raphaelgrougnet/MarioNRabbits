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
        

        public bool Attaquer(Personnage pPersoCible, Personnage pPersoAttaquant)
        {
            if (pPersoAttaquant is Attaquant)
            {
                Attaquant attaquant = pPersoAttaquant as Attaquant;
                pPersoCible.NbPointsVie -= attaquant.Arme.NbPointsDegat;
                return true;
            }
            return false;

        }
        
            
    }
}
