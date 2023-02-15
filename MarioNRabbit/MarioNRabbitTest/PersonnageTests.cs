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
            Personnage personnage = new Mario("Mario", 0, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1));
            // Act
            // Assert
            Assert.False(string.IsNullOrEmpty(personnage.Nom));
            
        }


        // TODO Tests unitaires pour la classe Personnage
        //
        // 1. Le nom du personnage ne doit pas �tre nul ou vide
        // 2. Les positions X et Y ne doivent pas �tre inf�rieures � 0 et sup�rieure � 19 (car la grille est de 20 cases par 20 cases)
        // 3. Le nombre de cases de d�placement possible doit �tre sup�rieur � 0 et inf�rieur � 19
        // 4. Le nombre de points de vie doit �tre sup�rieur � 0

        [Fact]
        public void Les_Positions_X_Et_Y_Ne_Doivent_Pas_Etre_Inferieures_A_0_Et_Superieure_A_19()
        {
            // Arrange
            Personnage personnage = new Mario("Mario", 0, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1));
            // Act
            // Assert
            Assert.True(personnage.PositionX >= 0 && personnage.PositionX <= 19);
            Assert.True(personnage.PositionY >= 0 && personnage.PositionY <= 19);
        }

        [Fact]
        public void Le_Nombre_De_Cases_De_Deplacement_Possible_Doit_Etre_Superieur_A_0_Et_Inferieur_A_19()
        {
            // Arrange
            Personnage personnage = new Mario("Mario", 0, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1));
            // Act
            // Assert
            Assert.True(personnage.NbCasesDeplacementMax > 0 && personnage.NbCasesDeplacementMax < 19);
        }

        [Fact]
        public void Le_Nombre_De_Points_De_Vie_Doit_Etre_Superieur_A_0()
        {
            // Arrange
            Personnage personnage = new Mario("Mario", 0, 0, 1, 1, new ArmeAttaquer("Blaster", 1, 1));
            // Act
            // Assert
            Assert.True(personnage.NbPointsVie > 0);
        }
        
        
    }
}