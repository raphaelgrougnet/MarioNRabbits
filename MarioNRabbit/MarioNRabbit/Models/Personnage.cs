using System;

namespace MarioNRabbit.Models
{

    public class DonneePersonnageInvalide : Exception
    {
        public DonneePersonnageInvalide(string pMessage) : base(message:pMessage)
        {
            
        }
    }
    
    public abstract class Personnage
    {
        // Classe Personnage
        //
        // Ajouter ici tout ce qui est nécessaire à la classe Personnage.
        // Les modificateurs d'accès peuvent être modifiés.
        // L'enum TypePersonnage sera nécessaire lors de l'exécution du programme; il faut donc bien le gérer dans la classe Personnage.

        #region CONSTANTES et ENUMS
        public enum TypePersonnage
        {
            HEROS,
            ENNEMI,
            ALLIE
        }
        const int POSITION_MIN_DEPLACEMENT = 0;

        const int POSITION_MAX_DEPLACEMENT = 19;

        #endregion

        #region ATTRIBUTS
        
        private string _nom;

        private int _positionX;

        private int _positionY;

        private int _nbCasesDeplacementMax;

        private int _nbPointsVie;

        

        #endregion

        #region PROPRIÉTÉS
        public string Nom
        {
            get { return _nom; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DonneePersonnageInvalide("Le nom ne peut pas être nulle ou vide");
                }
                _nom = value;
            }
        }
        public int PositionX
        {
            get { return _positionX; }
            set 
            {
                if (value <= POSITION_MIN_DEPLACEMENT || value > POSITION_MAX_DEPLACEMENT)
                {
                    throw new DonneePersonnageInvalide($"La position X du personnage doit être comprise en {POSITION_MIN_DEPLACEMENT} et {POSITION_MAX_DEPLACEMENT}");
                }
                _positionX = value; 
            }
        }
        public int PositionY
        {
            get { return _positionY; }
            set 
            {
                if (value <= POSITION_MIN_DEPLACEMENT || value > POSITION_MAX_DEPLACEMENT)
                {
                    throw new DonneePersonnageInvalide($"La position Y du personnage doit être comprise en {POSITION_MIN_DEPLACEMENT} et {POSITION_MAX_DEPLACEMENT}");
                }
                _positionY = value;
            }
        }
        public int NbCasesDeplacementMax
        {
            get { return _nbCasesDeplacementMax; }
            set
            {
                if (value <= POSITION_MIN_DEPLACEMENT || value > POSITION_MAX_DEPLACEMENT)
                {
                    throw new DonneePersonnageInvalide($"Le nombre de cases de déplacement du personnage doit être compris en {POSITION_MIN_DEPLACEMENT} et {POSITION_MAX_DEPLACEMENT}");
                }
                _nbCasesDeplacementMax = value; 
            }
        }
        public int NbPointsVie
        {
            get { return _nbPointsVie; }
            set 
            {
                if (value <= 0)
                {
                    throw new DonneePersonnageInvalide("La vie du personnage ne peut pas être inférieur à 0");
                }
                _nbPointsVie = value; 
            }
        }
        #endregion

        #region CONSTRUCTEURS

        public Personnage(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie)
        {
            Nom = pNom;
            PositionX = pPositionX;
            PositionY = pPositionY;
            NbCasesDeplacementMax = pNbCasesDeplacementMax;
            NbPointsVie = pNbPointsVie;
        }

        #endregion

        #region MÉTHODES
        public void SeDeplacer(int pPositionX, int pPositionY)
        {
            PositionX = pPositionX;
            PositionY = pPositionY;

        }
        #endregion


        // TODO Tests unitaires pour la classe Personnage
        //
        // 1. Le nom du personnage ne doit pas être nul ou vide
        // 2. Les positions X et Y ne doivent pas être inférieures à 0 et supérieure à 19 (car la grille est de 20 cases par 20 cases)
        // 3. Le nombre de cases de déplacement possible doit être supérieur à 0 et inférieur à 19
        // 4. Le nombre de points de vie doit être supérieur à 0
    }
}
