using MarioNRabbit.Models;
using Xunit;

namespace MarioNRabbitTest
{
    public class PersonnageTests
    {
        [Fact]
        public void Le_Nom_Du_Personnage_Ne_Doit_Pas_Etre_Nul_Ou_Vide()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("", 0, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1)));

        }


        // TODO Tests unitaires pour la classe Personnage
        //
        // 1. Le nom du personnage ne doit pas être nul ou vide
        // 2. Les positions X et Y ne doivent pas être inférieures à 0 et supérieure à 19 (car la grille est de 20 cases par 20 cases)
        // 3. Le nombre de cases de déplacement possible doit être supérieur à 0 et inférieur à 19
        // 4. Le nombre de points de vie doit être supérieur à 0

        [Fact]
        public void Les_Positions_X_Et_Y_Ne_Doivent_Pas_Etre_Inferieures_A_0_Et_Superieure_A_19()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("Mario", 20, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1)));
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("Mario", 0, -1, 1, 1, new ArmeAttaquer("Blaster", 1, 1)));
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("Mario", -1, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1)));
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("Mario", 0, 20, 1, 1, new ArmeAttaquer("Blaster", 1, 1)));
        }

        [Fact]
        public void Le_Nombre_De_Cases_De_Deplacement_Possible_Doit_Etre_Superieur_A_0_Et_Inferieur_A_19()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("Mario", 0, 0, -1, 1, new ArmeAttaquer("Blaster", 1, 1)));
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("Mario", 0, 0, 20, 1, new ArmeAttaquer("Blaster", 1, 1)));
        }

        [Fact]
        public void Le_Nombre_De_Points_De_Vie_Doit_Etre_Superieur_A_0()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<DonneePersonnageInvalide>(() => new Mario("Mario", 0, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1)));
        }
        
        
    }
}