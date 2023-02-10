using MarioNRabbit.Views;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace MarioNRabbit
{

    public partial class SelectionHeros : Window
    {
        // Gestion de la sélection des héros
        //
        // Dans cette classe, il faut gérer deux concepts: le nombre de héros, ainsi qu'une liste de string contenant le nom des héros.
        //
        // Le nombre de héros se gère par incrémentation et décrémentation.
        // Pour la liste de noms des héros, il faut utiliser la propriété Name retournée dans le contexte de BoutonSelectionHeros.
        List<Control> listeBoutons = new List<Control>();
        private string _initialesJoueur;

        public SelectionHeros(string pInitiales)
        {
            InitializeComponent();

            // On peut mettre cette ligne en commentaire... ;)
            //trameSonore.Play();
            string InitialesJoueur = pInitiales;

        }

        private void Ajout(object pSender, RoutedEventArgs pEvent)
        {
            // Sélection d'un héros
            Control boutton = (Control)pSender;
            
            
            int nbHeros = int.Parse(txtNbHerosSelectionne.Text.Substring(0, 1));


            nbHeros++;
            listeBoutons.Add(boutton);

            txtNbHerosSelectionne.Text = $"{nbHeros}/3";
        }

        private void Retrait(object pSender, RoutedEventArgs pEvent)
        {
            // Retrait d'un héros
            Control boutton = (Control)pSender;
            int nbHeros = int.Parse(txtNbHerosSelectionne.Text.Substring(0, 1));

            nbHeros--;
            listeBoutons.Remove(boutton);

            txtNbHerosSelectionne.Text = $"{nbHeros}/3";
        }

        private void DemarrerJeu(object pSender, RoutedEventArgs pEvent)
        {
            if (int.Parse(txtNbHerosSelectionne.Text.Substring(0, 1)) == 3)
            {
                List<string> listeNoms = new List<string>();
                foreach (Control bouton in listeBoutons)
                {
                    listeNoms.Add(bouton.Name);
                }
                Jeu jeu = new Jeu(_initialesJoueur, listeNoms);
                jeu.Show();
                Close();

            }
            // Gérer la sélection des héros
            //
            // Lorsque 3 et seulement 3 héros sont sélectionnés, on appelle la fenêtre Jeu en lui passant en paramètre les initiales ainsi que la liste de noms des héros.
        }
    }
}
