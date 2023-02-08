
using System;
using System.Collections.Generic;
using static MarioNRabbit.Models.Personnage;

namespace MarioNRabbit.Models
{
    public class MoteurJeu
    {
        public enum TypeAction
        {
            AUCUNE,
            ATTAQUE,
            DEPLACEMENT,
            COMPETENCE
        }

        public const int NB_HEROS = 3;
        public const int NB_ENNEMIS = 3;
        public const int LARGEUR_GRILLE = 20;

        public List<Personnage> ListePersonnages { get; set; }
        public Personnage HerosCourant { get; set; }
        public Personnage EnnemiCourant { get; set; }
        public TypeAction ActionCourante { get; set; }

        public int NbActionRestante { get; set; }

        public MoteurJeu(List<string> pNomHerosSelectionnes)
        {
            ListePersonnages = new List<Personnage>();

            Utils.CoordonneesGrille positionPersonnage;

            // TODO Instanciation des personnages
            //
            // Vu que les héros sont choisis par le joueur (FamilleMario ou FamilleLapin) et que des ennemis doivent également être gérés, on doit procéder à une instanciation de classe dynamique.
            //
            // La position du personnage doit être déterminée de façon aléatoire. Pour ce faire, on utilise la méthode GenererPositionHasardPersonnage avec l'enum TypePersonnage.
            //
            // On doit ajouter l'instance du personnage à la liste ListePersonnages, qui sera utilisée par MoteurJeu.
            // 
            // Afin de créer dynamiquement l'instance du personnage, on peut utiliser Activator.CreateInstance.
            // Le premier paramètre prend le type de la classe et les autres paramètres sont ceux du constructeur de la classe.
            //
            // La méthode DefinirClasseHeros est fournie. En paramètre, le nom du Héros (ou le nom de la classe). Cette méthode retournera
            // le type de la classe à utiliser avec Activator.CreateInstance.
            //
            // Voici un exemple d'ajout à une liste d'une instance de classe créée dynamiquement:
            // ListePersonnages.Add(Activator.CreateInstance(DefinirClasseHeros("Nom du héros"), Paramètres du Constructeur) as Personnage);

            ActionCourante = TypeAction.AUCUNE;
            NbActionRestante = 3;
        }

        private Type DefinirClasseHeros(string pHeros)
        {
            List<string> familleMario = new List<string> { "Mario", "Luigi", "Yoshi", "Peach" };

            if (familleMario.Contains(pHeros))
                return Type.GetType($"BattleKingdom.Models.{pHeros}, BattleKingdom");
            else
                return Type.GetType("BattleKingdom.Models.FamilleLapin, BattleKingdom");
        }

        private Utils.CoordonneesGrille GenererPositionHasardPersonnage(List<Personnage> pListePersonnages, TypePersonnage pTypePersonnage)
        {
            int X;
            int Y;

            Utils.CoordonneesGrille coordonnees;

            do
            {
                X = new Random().Next(LARGEUR_GRILLE);

                switch (pTypePersonnage)
                {
                    case TypePersonnage.HEROS:
                        Y = LARGEUR_GRILLE - 1 - new Random().Next(3);
                        break;
                    case TypePersonnage.ENNEMI:
                        Y = new Random().Next(3);
                        break;
                    case TypePersonnage.ALLIE:
                        Y = LARGEUR_GRILLE - 1;
                        break;
                    default:
                        Y = LARGEUR_GRILLE - 1;
                        break;
                }

                coordonnees = new Utils.CoordonneesGrille(X, Y);
            } while (EstCollisionDetectee(pListePersonnages, coordonnees));

            return coordonnees;
        }

        private bool EstCollisionDetectee(List<Personnage> pListePersonnages, Utils.CoordonneesGrille pCoordonnees)
        {
            // TODO Détecter une collision entre personnages
            //
            // Cette méthode doit retourner:
            // - true, si la coordonnée reçue en paramètre est en collision avec la position d'un personnage
            // - false, si aucune collision n'est détectée

            return true;
        }

        public bool EstAttaquePossible()
        {
            // TODO Vérifier si une attaque est possible
            //
            // À partir du héros courant (HerosCourant) et de l'ennemi courant (EnnemiCourant), cette méthode doit retourner:
            // - true, si l'attaque est possible
            // - false, si l'attaque est impossible

            return true;
        }

        public bool EstDeplacementPossible(int pPositionX, int pPositionY)
        {
            // TODO Vérifier si un déplacement est possible
            //
            // Pour le héros courant (HerosCourant) et à partir des positions passées en paramètres, cette méthode doit retourner:
            // - true, si le déplacement est possible
            // - false, si le déplacement est impossible

            return true;
        }

        public bool EstCompetencePossible()
        {
            // TODO Vérifier si la compétence spéciale peut être activée
            //
            // Pour le héros courant (HerosCourant), cette méthode doit retourner:
            // - true, si une compétence spéciale peut être activée
            // - false, si une compétence spéciale ne peut pas être activée

            return true;
        }

        public void ActionCompletee()
        {
            NbActionRestante--;

            // Tour terminé
            if (NbActionRestante == 0)
            {
                foreach (Personnage personnage in ListePersonnages.FindAll(p => p is FamilleMario && p.NbPointsVie > 0))
                {
                    (personnage as FamilleMario).DesactiverCompetenceSpeciale();
                }
            }
        }

        public Personnage TrouverHerosPlusProche(Personnage pEnnemi)
        {
            Personnage herosPlusProche = null;
            int distancePlusProche = LARGEUR_GRILLE;

            foreach (Personnage heros in ListePersonnages.FindAll(p => p is Heros && p.NbPointsVie > 0))
            {
                int distance = Utils.CalculerDistance(new Utils.CoordonneesGrille(pEnnemi.PositionX, pEnnemi.PositionY), new Utils.CoordonneesGrille(heros.PositionX, heros.PositionY));

                if (distance < distancePlusProche || herosPlusProche is null)
                {
                    herosPlusProche = heros;
                    distancePlusProche = distance;
                }
            }

            return herosPlusProche;
        }

        public void DeplacerVersHerosPlusProche(Personnage pEnnemi, Personnage pHerosPlusProche)
        {
            int distance = Utils.CalculerDistance(new Utils.CoordonneesGrille(pEnnemi.PositionX, pEnnemi.PositionY), new Utils.CoordonneesGrille(pHerosPlusProche.PositionX, pHerosPlusProche.PositionY));
            int distanceRestante;

            int nouvellePositionX = pEnnemi.PositionX;
            int nouvellePositionY = pEnnemi.PositionY;

            // Si la distance entre le héros et l'ennemi est moins grande que ce que l'ennemi peut faire au maximum
            if (distance >= pEnnemi.NbCasesDeplacementMax)
                distanceRestante = pEnnemi.NbCasesDeplacementMax;
            else
                distanceRestante = distance - 1;

            while (distanceRestante > 0)
            {
                if (distanceRestante > 0 && nouvellePositionX < pHerosPlusProche.PositionX)
                {
                    nouvellePositionX++;
                    distanceRestante--;
                }
                else if (distanceRestante > 0 && nouvellePositionX > pHerosPlusProche.PositionX)
                {
                    nouvellePositionX--;
                    distanceRestante--;
                }

                if (distanceRestante > 0 && nouvellePositionY < pHerosPlusProche.PositionY)
                {
                    nouvellePositionY++;
                    distanceRestante--;
                }
                else if (distanceRestante > 0 && nouvellePositionY > pHerosPlusProche.PositionY)
                {
                    nouvellePositionY--;
                    distanceRestante--;
                }
            }

            pEnnemi.SeDeplacer(nouvellePositionX, nouvellePositionY);
        }
    }
}
