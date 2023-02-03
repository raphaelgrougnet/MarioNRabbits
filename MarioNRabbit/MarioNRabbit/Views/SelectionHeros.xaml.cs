using System.Windows;

namespace BattleKingdom
{

    public partial class SelectionHeros : Window
    {
        // TODO Gestion de la sélection des héros
        //
        // Dans cette classe, il faut gérer deux concepts: le nombre de héros, ainsi qu'une liste de string contenant le nom des héros.
        //
        // Le nombre de héros se gère par incrémentation et décrémentation.
        // Pour la liste de noms des héros, il faut utiliser la propriété Name retournée dans le contexte de BoutonSelectionHeros.

        public SelectionHeros(string pInitiales)
        {
            InitializeComponent();

            // On peut mettre cette ligne en commentaire... ;)
            trameSonore.Play();
        }

        private void Ajout(object pSender, RoutedEventArgs pEvent)
        {
            // TODO Sélection d'un héros
        }

        private void Retrait(object pSender, RoutedEventArgs pEvent)
        {
            // TODO Retrait d'un héros
        }

        private void DemarrerJeu(object pSender, RoutedEventArgs pEvent)
        {
            // TODO Gérer la sélection des héros
            //
            // Lorsque 3 et seulement 3 héros sont sélectionnés, on appelle la fenêtre Jeu en lui passant en paramètre les initiales ainsi que la liste de noms des héros.
        }
    }
}
