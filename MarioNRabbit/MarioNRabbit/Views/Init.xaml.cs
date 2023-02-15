using MarioNRabbit.Models;
using System.Windows;

namespace MarioNRabbit.Views
{
    public partial class Init : Window
    {
        const byte LONGUEUR_INITIALES = 2;

        /// <summary>
        /// Constructeur de la fenêtre Init
        /// </summary>
        public Init()
        {
            // Appel de l'initialisation du fichier de la trace
            //
            // Le fichier de trace doit être initialisé ici.
            Utils.InitialiserFichierTrace();
            

            InitializeComponent();
        }              

        /// <summary>
        /// Méthode permetant de valider les initiales du joueur
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void Confirmer(object pSender, RoutedEventArgs pEvent)
        {
            // Valider les initiales
            //
            // Les initiales doivent se conformer à ce qui est spécifié dans les consignes.
            // En cas d'erreur, un message doit être affiché dans les contrôles txtInitiales et txtMessage de la fenêtre.

            if (txtInitiales.Text.Length > LONGUEUR_INITIALES || txtInitiales.Text.Length < LONGUEUR_INITIALES || string.IsNullOrWhiteSpace(txtInitiales.Text) || txtInitiales.Text != txtInitiales.Text.ToUpper())
            {
                txtMessage.Text = "Les initiales doivent être composées de 2 lettres majuscules.";
                
            }
            else
            {
                // Lorsque les initiales sont valides, la fenêtre SelectionHeros est appelée en lui passant les initiales en paramètres.
                SelectionHeros selectionHeros = new SelectionHeros(txtInitiales.Text);

                selectionHeros.Show();
                Close();
            }

            
        }
    }
}
