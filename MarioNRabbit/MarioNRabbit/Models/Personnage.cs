namespace BattleKingdom.Models
{
    public class Personnage
    {
        // TODO Classe Personnage
        //
        // Ajouter ici tout ce qui est nécessaire à la classe Personnage.
        // Les modificateurs d'accès peuvent être modifiés.
        // L'enum TypePersonnage sera nécessaire lors de l'exécution du programme; il faut donc bien le gérer dans la classe Personnage.
        public enum TypePersonnage
        {
            HEROS,
            ENNEMI,
            ALLIE
        }

        // TODO Tests unitaires pour la classe Personnage
        //
        // 1. Le nom du personnage ne doit pas être nul ou vide
        // 2. Les positions X et Y ne doivent pas être inférieures à 0 et supérieure à 19 (car la grille est de 20 cases par 20 cases)
        // 3. Le nombre de cases de déplacement possible doit être supérieur à 0 et inférieur à 19
        // 4. Le nombre de points de vie doit être supérieur à 0
    }
}
