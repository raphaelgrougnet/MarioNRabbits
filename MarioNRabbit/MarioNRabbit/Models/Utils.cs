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

        public class CoordonneesGrille
        {
            public int Y { get; set; }
            public int X { get; set; }

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

        public static int CalculerDistance(CoordonneesGrille pSource, CoordonneesGrille pDestination)
        {
            return Math.Abs(pSource.X - pDestination.X) + Math.Abs(pSource.Y - pDestination.Y);
        }

        public static void InitialiserFichierTrace()
        {
            Stream leFichier = File.Create("FichierTrace.txt");
            TextWriterTraceListener leListener = new TextWriterTraceListener(leFichier);
            Trace.AutoFlush = true;
            Trace.Listeners.Add(leListener);

        }

        public static void Tracer(string pMsg, TextBox pControle)
        {
            Trace.WriteLine($"> {pMsg}");
            pControle.Text += "> " + pMsg + "\n";
            pControle.ScrollToEnd();
        }


    }
}
