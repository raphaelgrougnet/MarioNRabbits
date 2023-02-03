using System.Windows;

namespace BattleKingdom.Views
{
    public partial class Init : Window
    {
        public Init()
        {
            // TODO Appel de l'initialisation du fichier de la trace
            //
            // Le fichier de trace doit être initialisé ici.

            InitializeComponent();
        }              

        private void Confirmer(object pSender, RoutedEventArgs pEvent)
        {
            // TODO Valider les initiales
            //
            // Les initiales doivent se conformer à ce qui est spécifié dans les consignes.
            // En cas d'erreur, un message doit être affiché dans les contrôles txtInitiales et txtMessage de la fenêtre.

            // Lorsque les initiales sont valides, la fenêtre SelectionHeros est appelée en lui passant les initiales en paramètres.
            SelectionHeros selectionHeros = new SelectionHeros(txtInitiales.Text);

            selectionHeros.Show();
            Close();
        }
    }
}
