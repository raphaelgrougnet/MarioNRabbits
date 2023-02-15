using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;

namespace MarioNRabbit.Models
{
    public static class Utils
    {
        // Fonctions nécessaires à la trace
        // On doit retrouver ici une fonction qui permet l'initialisation du fichier de la trace.
        // On doit également retrouver une fonction qui permet d'écrire la trace, dans le fichier ainsi qu'à l'écran, tel que spécifié dans les consignes.
        /// <summary>
        /// Classe qui représente les coordonnées d'une case de la grille
        /// </summary>
        public class CoordonneesGrille
        {
            public int Y { get; set; }
            public int X { get; set; }

            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="pX"></param>
            /// <param name="pY"></param>
            public CoordonneesGrille(int pX, int pY)
            {
                Y = pY;
                X = pX;
            }


            public override bool Equals(object pObj)
            {
                if (pObj == null)
                    return false;
                if (!(pObj is CoordonneesGrille))
                    return false;
                return (this.Y == ((CoordonneesGrille)pObj).Y) && (this.X == ((CoordonneesGrille)pObj).X);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }


        /// <summary>
        /// Calculer la distance entre deux cases de la grille
        /// </summary>
        /// <param name="pSource">Coordonées de la case de départ</param>
        /// <param name="pDestination">Coordonée de la case de destination</param>
        /// <returns></returns>
        public static int CalculerDistance(CoordonneesGrille pSource, CoordonneesGrille pDestination)
        {
            return Math.Abs(pSource.X - pDestination.X) + Math.Abs(pSource.Y - pDestination.Y);
        }


        /// <summary>
        /// Initialiser le fichier de trace
        /// </summary>
        public static void InitialiserFichierTrace()
        {
            Stream leFichier = File.Create("FichierTrace.txt");
            TextWriterTraceListener leListener = new TextWriterTraceListener(leFichier);
            Trace.AutoFlush = true;
            Trace.Listeners.Add(leListener);

        }

        /// <summary>
        /// Tracer un message dans le fichier de trace et dans le contrôle TextBox
        /// </summary>
        /// <param name="pMsg">Messsage</param>
        /// <param name="pControle">Textbox dans le quel afficher le message</param>
        public static void Tracer(string pMsg, TextBox pControle)
        {
            Trace.WriteLine($"> {pMsg}");
            pControle.Text += "> " + pMsg + "\n";
            pControle.ScrollToEnd();
        }


    }
}
