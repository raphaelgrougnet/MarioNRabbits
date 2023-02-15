using System;

namespace MarioNRabbit.Models
{
    /// <summary>
    /// Exception levée lorsqu'une donnée du personnage est invalide
    /// </summary>
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
        /// <summary>
        /// Enumération des types de personnages
        /// </summary>
        public enum TypePersonnage
        {
            HEROS,
            ENNEMI,
            ALLIE
        }
        /// <summary>
        /// Position minimale et maximale de déplacement d'un personnage
        /// </summary>
        const int POSITION_MIN_DEPLACEMENT = 0;

        /// <summary>
        /// Position minimale et maximale de déplacement d'un personnage
        /// </summary>
        const int POSITION_MAX_DEPLACEMENT = 19;

        #endregion

        #region ATTRIBUTS
        /// <summary>
        /// Nom du personnage
        /// </summary>
        private string _nom;
        /// <summary>
        /// Position X du personnage
        /// </summary>
        private int _positionX;
        /// <summary>
        /// Position Y du personnage
        /// </summary>
        private int _positionY;
        /// <summary>
        /// Nombre de cases de déplacement maximum du personnage
        /// </summary>
        private int _nbCasesDeplacementMax;
        /// <summary>
        /// Nombre de points de vie du personnage
        /// </summary>
        private int _nbPointsVie;



        #endregion

        #region PROPRIÉTÉS
        /// <summary>
        /// Nom du personnage
        /// </summary>
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
        /// <summary>
        /// Position X du personnage
        /// </summary>
        public int PositionX
        {
            get { return _positionX; }
            set 
            {
                if (value < POSITION_MIN_DEPLACEMENT || value > POSITION_MAX_DEPLACEMENT)
                {
                    throw new DonneePersonnageInvalide($"La position X du personnage doit être comprise en {POSITION_MIN_DEPLACEMENT} et {POSITION_MAX_DEPLACEMENT}");
                }
                _positionX = value; 
            }
        }

        /// <summary>
        /// Position Y du personnage
        /// </summary>
        public int PositionY
        {
            get { return _positionY; }
            set 
            {
                if (value < POSITION_MIN_DEPLACEMENT || value > POSITION_MAX_DEPLACEMENT)
                {
                    throw new DonneePersonnageInvalide($"La position Y du personnage doit être comprise en {POSITION_MIN_DEPLACEMENT} et {POSITION_MAX_DEPLACEMENT}");
                }
                _positionY = value;
            }
        }

        /// <summary>
        /// Nombre de cases de déplacement maximum du personnage
        /// </summary>
        public int NbCasesDeplacementMax
        {
            get { return _nbCasesDeplacementMax; }
            set
            {
                if (value < POSITION_MIN_DEPLACEMENT || value > POSITION_MAX_DEPLACEMENT)
                {
                    throw new DonneePersonnageInvalide($"Le nombre de cases de déplacement du personnage doit être compris en {POSITION_MIN_DEPLACEMENT} et {POSITION_MAX_DEPLACEMENT}");
                }
                _nbCasesDeplacementMax = value; 
            }
        }

        /// <summary>
        /// Nombre de points de vie
        /// </summary>
        public int NbPointsVie
        {
            get { return _nbPointsVie; }
            set 
            {
                if (value < 0)
                {
                    throw new DonneePersonnageInvalide("La vie du personnage ne peut pas être inférieur à 0");
                }
                _nbPointsVie = value; 
            }
        }
        #endregion

        #region CONSTRUCTEURS

        /// <summary>
        /// Constructeur de Personnage
        /// </summary>
        /// <param name="pNom"></param>
        /// <param name="pPositionX"></param>
        /// <param name="pPositionY"></param>
        /// <param name="pNbCasesDeplacementMax"></param>
        /// <param name="pNbPointsVie"></param>
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


        /// <summary>
        /// Méthode permetant de se déplacer
        /// </summary>
        /// <param name="pPositionX">Coordonnée X</param>
        /// <param name="pPositionY">Coordonnée Y</param>
        public void SeDeplacer(int pPositionX, int pPositionY)
        {
            PositionX = pPositionX;
            PositionY = pPositionY;

        }
        #endregion


        // Tests unitaires pour la classe Personnage
        //
        // 1. Le nom du personnage ne doit pas être nul ou vide
        // 2. Les positions X et Y ne doivent pas être inférieures à 0 et supérieure à 19 (car la grille est de 20 cases par 20 cases)
        // 3. Le nombre de cases de déplacement possible doit être supérieur à 0 et inférieur à 19
        // 4. Le nombre de points de vie doit être supérieur à 0
    }
}
