using System;
using System.Windows;

namespace BattleKingdom.Views
{
    public partial class Fin : Window
    {
        public Fin(bool pSuccesHeros, string pInitiales)
        {
            InitializeComponent();

            if (pSuccesHeros)
            {
                mediaVideo.Source = new Uri("Resources/Videos/Victoire.mp4", UriKind.Relative);
                txtMessage.Text = $"Succès du héros {pInitiales}!";
            }
            else
            {
                mediaVideo.Source = new Uri("Resources/Videos/Defaite.mp4", UriKind.Relative);
                txtMessage.Text = $"Défaite du héros {pInitiales}!";
            }
        }
    }
}
