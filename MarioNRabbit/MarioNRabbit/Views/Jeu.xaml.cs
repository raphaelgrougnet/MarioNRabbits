using MarioNRabbit.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MarioNRabbit.Views
{
    public partial class Jeu : Window
    {
        private MoteurJeu _moteurJeu;
        private string _initialesJoueur;
        private bool finLancee = false;

        /// <summary>
        /// Constructeur de la fenêtre Jeu
        /// </summary>
        /// <param name="pInitiales"></param>
        /// <param name="pNomHerosSelectionnes"></param>
        public Jeu(string pInitiales, List<string> pNomHerosSelectionnes)
        {
            InitializeComponent();

            // Initialisation du moteur de jeu
            //
            // On doit initialiser ici la classe Moteur. Cette classe prend en paramètre la liste de noms des héros sélectionnés.
            _moteurJeu = new MoteurJeu(pNomHerosSelectionnes);
            _initialesJoueur = pInitiales;
            CreationGrilleTerrain();
            CreationPanneau();
            CreationPersonnages();

            DemarrerJeu();
        }

        /// <summary>
        /// Méthode permettant de creer le terrain
        /// </summary>
        private void CreationGrilleTerrain()
        {
            for (int i = 0; i < MoteurJeu.LARGEUR_GRILLE; i++)
            {
                grilleTerrain.RowDefinitions.Add(new RowDefinition());
                grilleTerrain.ColumnDefinitions.Add(new ColumnDefinition());

                for (int j = 0; j < MoteurJeu.LARGEUR_GRILLE; j++)
                {
                    Button boutonCase = new Button();

                    boutonCase.Click += new RoutedEventHandler(SelectionCase);

                    Grid.SetRow(boutonCase, i);
                    Grid.SetColumn(boutonCase, j);

                    grilleTerrain.Children.Add(boutonCase);
                }
            }
        }

        /// <summary>
        /// Méthode permettant de creer le panneau de selection
        /// </summary>
        private void CreationPanneau()
        {
            for (int i = 0; i < MoteurJeu.NB_HEROS; i++)
            {
                Grid ligneControle = new Grid();
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());

                Grid.SetRow(ligneControle, i);

                Image heros = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom + "xPersonnage",
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/" + _moteurJeu.ListePersonnages[i].Nom + ".png", UriKind.Relative)),
                    ToolTip = _moteurJeu.ListePersonnages[i].Nom
                };
                RegisterName(heros.Name, heros);
                Grid.SetColumn(heros, 0);
                ligneControle.Children.Add(heros);

                Image attaque = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.ATTAQUE.ToString(),
                    ToolTip = MoteurJeu.TypeAction.ATTAQUE.ToString(),
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/Attaque.png", UriKind.Relative))
                };
                RegisterName(attaque.Name, attaque);
                attaque.MouseDown += new MouseButtonEventHandler(SelectionAction);
                Grid.SetColumn(attaque, 1);
                ligneControle.Children.Add(attaque);

                Image deplacement = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.DEPLACEMENT.ToString(),
                    ToolTip = MoteurJeu.TypeAction.DEPLACEMENT.ToString(),
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/Deplacement.png", UriKind.Relative))
                };
                RegisterName(deplacement.Name, deplacement);
                deplacement.MouseDown += new MouseButtonEventHandler(SelectionAction);
                Grid.SetColumn(deplacement, 2);
                ligneControle.Children.Add(deplacement);

                if (_moteurJeu.ListePersonnages[i] is FamilleMario)
                {
                    Image competence = new Image
                    {
                        Name = _moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.COMPETENCE.ToString(),
                        ToolTip = MoteurJeu.TypeAction.COMPETENCE.ToString(),
                        Uid = i.ToString(),
                        Source = new BitmapImage(new Uri("/Resources/Images/Competence.png", UriKind.Relative))
                    };
                    RegisterName(competence.Name, competence);
                    competence.MouseDown += new MouseButtonEventHandler(SelectionAction);
                    Grid.SetColumn(competence, 3);
                    ligneControle.Children.Add(competence);
                }

                grilleControles.Children.Add(ligneControle);
            }
        }

        /// <summary>
        /// Méthode permettant de creer les personnages
        /// </summary>
        private void CreationPersonnages()
        {
            for (int i = 0; i < _moteurJeu.ListePersonnages.Count; i++)
            {
                Image personnage = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom,
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/" + _moteurJeu.ListePersonnages[i].Nom + ".png", UriKind.Relative)),
                    ToolTip = FormattageInfoBulle(i)
                };

                // Pour permettre la recherche du contrôle avec FindName
                RegisterName(personnage.Name, personnage);

                if (_moteurJeu.ListePersonnages[i] is Ennemi)
                    personnage.MouseDown += new MouseButtonEventHandler(SelectionEnnemi);

                Grid.SetColumn(personnage, _moteurJeu.ListePersonnages[i].PositionX);
                Grid.SetRow(personnage, _moteurJeu.ListePersonnages[i].PositionY);

                grilleTerrain.Children.Add(personnage);
            }
        }

        /// <summary>
        /// Méthode permettant de formater les informations de l'infobulle
        /// </summary>
        /// <param name="pIndexPersonnage">Numéro du personnage</param>
        /// <returns>Un string formaté avec toutes les informations du personnage</returns>
        private string FormattageInfoBulle(int pIndexPersonnage)
        {
            // Retourner les informations du personnage
            //
            // Cette méthode doit retourner les informations courantes du personnage afin d'être affichée dans une infobulle.
            // Toutes les informations pertinentes au personnage doivent être affichées, comme son nom, son déplacement, les informations sur ses armes.
            string infos = "";
            Attaquant personnage = (Attaquant)_moteurJeu.ListePersonnages[pIndexPersonnage];
            infos += personnage.Nom + "\n\n";
            infos += "Déplacement : " + personnage.NbCasesDeplacementMax +"\n";
            infos += "Points de vie restant : " + personnage.NbPointsVie + "\n\n";
            
            infos += "Arme : " + personnage.Arme.Nom + "\n";
            infos += "Dégat d'arme : " + personnage.Arme.NbPointsDegat + "\n";
            infos += "Portée d'arme : " + personnage.Arme.NbCasesDistanceMax;


            return infos;
        }

        /// <summary>
        /// Méthode permettant de sélectionner une action
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void SelectionAction(object pSender, RoutedEventArgs pEvent)
        {
            _moteurJeu.HerosCourant = _moteurJeu.ListePersonnages[int.Parse((pSender as Image).Uid)];
            _moteurJeu.ActionCourante = (MoteurJeu.TypeAction)Enum.Parse(typeof(MoteurJeu.TypeAction), (pSender as Image).Name.Substring((pSender as Image).Name.IndexOf("x") + 1));
            if (_moteurJeu.ActionCourante != MoteurJeu.TypeAction.COMPETENCE)
            {
                Utils.Tracer($"{_initialesJoueur} sélectionne l'action {_moteurJeu.ActionCourante} du héros {_moteurJeu.HerosCourant.Nom}\n", txtTrace);

            }
            if (_moteurJeu.ActionCourante == MoteurJeu.TypeAction.COMPETENCE && _moteurJeu.EstCompetencePossible())
            {
                (_moteurJeu.HerosCourant as FamilleMario).ActiverCompetenceSpeciale();
                Utils.Tracer($"{_moteurJeu.HerosCourant.Nom} a utilisé sa compétence\n", txtTrace);
                ActionCompletee();
                Utils.Tracer($"Tours restants pour le héros {_initialesJoueur} : {_moteurJeu.NbActionRestante}", txtTrace);
            }
                
                
        }

        /// <summary>
        /// Méthode permettant de sélectionner un ennemi
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void SelectionEnnemi(object pSender, RoutedEventArgs pEvent)
        {
            _moteurJeu.EnnemiCourant = _moteurJeu.ListePersonnages[int.Parse((pSender as Image).Uid)];

            if (_moteurJeu.ActionCourante == MoteurJeu.TypeAction.ATTAQUE && _moteurJeu.EstAttaquePossible())
            {
                (_moteurJeu.HerosCourant as Attaquant).Attaquer(_moteurJeu.HerosCourant, _moteurJeu.EnnemiCourant);
                Utils.Tracer($"{_moteurJeu.HerosCourant.Nom} a attaqué {_moteurJeu.EnnemiCourant.Nom}\n", txtTrace);
                ActionCompletee();
                Utils.Tracer($"Tours restants pour le héros {_initialesJoueur} : {_moteurJeu.NbActionRestante}", txtTrace);
            }
                
        }

        /// <summary>
        /// Méthode permettant de sélectionner une case
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void SelectionCase(object pSender, RoutedEventArgs pEvent)
        {
            int positionX = int.Parse((pSender as Button).GetValue(Grid.ColumnProperty).ToString());
            int positionY = int.Parse((pSender as Button).GetValue(Grid.RowProperty).ToString());

            if (_moteurJeu.ActionCourante == MoteurJeu.TypeAction.DEPLACEMENT && _moteurJeu.EstDeplacementPossible(positionX, positionY))
            {
                _moteurJeu.HerosCourant.SeDeplacer(positionX, positionY);
                Utils.Tracer($"{_moteurJeu.HerosCourant.Nom} s'est déplacer vers la case {positionX},{positionY}\n", txtTrace);
                ActionCompletee();
                Utils.Tracer($"Tours restants pour le héros {_initialesJoueur} : {_moteurJeu.NbActionRestante}", txtTrace);
            }
                
        }

        /// <summary>
        /// Méthode permettant de démarrer le jeu
        /// </summary>
        private void DemarrerJeu()
        {
            Utils.Tracer("Démarrage du jeu\n", txtTrace);
            TourHeros();
        }

        /// <summary>
        /// Méthode permettant de compléter une action
        /// </summary>
        private void ActionCompletee()
        {
            _moteurJeu.ActionCompletee();

            EvaluerSantePersonnages();

            // Si on est rendu là, c'est qu'il n'y a toujours pas de gagnant ou de perdant
            for (int i = 0; i < _moteurJeu.ListePersonnages.Count; i++)
            {
                // Désactivation des contrôles utilisés
                if (_moteurJeu.HerosCourant != null && _moteurJeu.ListePersonnages[i].Nom == _moteurJeu.HerosCourant.Nom)
                {
                    Image controleUtilise = FindName(_moteurJeu.HerosCourant.Nom + "x" + _moteurJeu.ActionCourante.ToString()) as Image;
                    controleUtilise.IsEnabled = false;
                    controleUtilise.Opacity = 0.5;
                }

                // Rafraîchissement des tooltips et retrait des contrôles des personnages morts
                if (_moteurJeu.ListePersonnages[i].NbPointsVie > 0)
                {
                    Grid.SetColumn(FindName(_moteurJeu.ListePersonnages[i].Nom) as Image, _moteurJeu.ListePersonnages[i].PositionX);
                    Grid.SetRow(FindName(_moteurJeu.ListePersonnages[i].Nom) as Image, _moteurJeu.ListePersonnages[i].PositionY);

                    (FindName(_moteurJeu.ListePersonnages[i].Nom) as Image).ToolTip = FormattageInfoBulle(i);
                }
                else
                {
                    grilleTerrain.Children.Remove(FindName(_moteurJeu.ListePersonnages[i].Nom) as Image);

                    // Lorsqu'un héros est mort, on désactive ses contrôles
                    if (_moteurJeu.ListePersonnages[i] is Heros)
                    {
                        (FindName(_moteurJeu.ListePersonnages[i].Nom + "xPersonnage") as Image).IsEnabled = false;
                        (FindName(_moteurJeu.ListePersonnages[i].Nom + "xPersonnage") as Image).Opacity = 0.5;

                        (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.ATTAQUE.ToString()) as Image).IsEnabled = false;
                        (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.ATTAQUE.ToString()) as Image).Opacity = 0.5;

                        (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.DEPLACEMENT.ToString()) as Image).IsEnabled = false;
                        (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.DEPLACEMENT.ToString()) as Image).Opacity = 0.5;

                        if (_moteurJeu.ListePersonnages[i] is FamilleMario)
                        {
                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.COMPETENCE.ToString()) as Image).IsEnabled = false;
                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.COMPETENCE.ToString()) as Image).Opacity = 0.5;
                        }
                    }
                }
            }

            // Lorsqu'un tour (3 actions) est complété
            if (_moteurJeu.HerosCourant != null)
            {
                // Tour des héros complété
                if (_moteurJeu.NbActionRestante == 0)
                {
                    ReactiverControlesHeros();
                    
                    TourEnnemi();
                }
            }
            else
            {
                if (_moteurJeu.NbActionRestante == 0)
                    TourHeros();
            }

            _moteurJeu.HerosCourant = null;
            _moteurJeu.EnnemiCourant = null;
            _moteurJeu.ActionCourante = MoteurJeu.TypeAction.AUCUNE;
        }

        /// <summary>
        /// Méthode permettant d'évaluer la santé des personnages
        /// </summary>
        private void EvaluerSantePersonnages()
        {
            // Évaluation de la santé des personnages
            //
            // Cette méthode doit procéder à l'évaluation de la santé des personnages et si nécessaire, passer à la fenêtre Fin lorsque la partie est terminée.
            // La partie est terminée lorsque soit le héros gagne (tous les ennemis sont morts) ou que l'ennemi gagne (tous les héros sont morts).
            // Un personnage est mort lorsqu'il n'a plus de point de vie.
            // La fenêtre Fin doit être appelées avec deux paramètres, soient un booléen qui indique si le héros gagne et l'autre, les initiales du joueurs.

            // Vérification si le héros a gagné
            if (!finLancee)
            {
                if (_moteurJeu.ListePersonnages.FindAll(p => p is Ennemi && p.NbPointsVie > 0).Count == 0)
                {

                    Fin fin = new Fin(true, _initialesJoueur);

                    Close();

                    fin.Show();
                    finLancee = true;

                }

                else if (_moteurJeu.ListePersonnages.FindAll(p => p is Heros && p.NbPointsVie > 0).Count == 0)
                {

                    Fin fin = new Fin(false, _initialesJoueur);

                    Close();

                    fin.Show();
                    finLancee = true;


                }
            }
            

        }

        /// <summary>
        /// Méthode permettant d'activer le tour du héro
        /// </summary>
        private void TourHeros()
        {
            _moteurJeu.NbActionRestante = 3;

            _moteurJeu.HerosCourant = null;
            _moteurJeu.EnnemiCourant = null;
            _moteurJeu.ActionCourante = MoteurJeu.TypeAction.AUCUNE;

            Utils.Tracer($"***** C'est au tour du héros {_initialesJoueur} *****", txtTrace);
            
        }


        /// <summary>
        /// Méthode permetant de réactiver les controles du héros
        /// </summary>
        private void ReactiverControlesHeros()
        {

            // Réactivation des contrôles des héros
            foreach (Personnage personnage in _moteurJeu.ListePersonnages.FindAll(p => p is Heros && p.NbPointsVie > 0))
            {
                Image controleAttaque = (Image)FindName(personnage.Nom + "x" + MoteurJeu.TypeAction.ATTAQUE.ToString());
                controleAttaque.IsEnabled = true;
                controleAttaque.Opacity = 1;

                Image controleDeplacement = (Image)FindName(personnage.Nom + "x" + MoteurJeu.TypeAction.DEPLACEMENT.ToString());
                controleDeplacement.IsEnabled = true;
                controleDeplacement.Opacity = 1;

                if (personnage is FamilleMario)
                {
                    Image controleCompetence = (Image)FindName(personnage.Nom + "x" + MoteurJeu.TypeAction.COMPETENCE.ToString());
                    controleCompetence.IsEnabled = true;
                    controleCompetence.Opacity = 1;
                }
            }
        }

        /// <summary>
        /// Méthode permetant de passer le tour du héros
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void PasserTourHeros(object pSender, RoutedEventArgs pEvent)
        {
            txtTrace.Text += $"Le héros {_initialesJoueur} passe son tour\n\n";

            ReactiverControlesHeros();
            TourEnnemi();
        }

        /// <summary>
        /// Méthode permettant d'activer le tour des ennemies
        /// </summary>
        private void TourEnnemi()
        {
            _moteurJeu.NbActionRestante = 3;

            _moteurJeu.HerosCourant = null;
            _moteurJeu.EnnemiCourant = null;
            _moteurJeu.ActionCourante = MoteurJeu.TypeAction.AUCUNE;
            Utils.Tracer($"***** C'est au tour des ennemies *****", txtTrace);
            Utils.Tracer($"Tours restants pour l'ennemi : {_moteurJeu.NbActionRestante}", txtTrace);
            foreach (Personnage ennemi in _moteurJeu.ListePersonnages.FindAll(p => p is Ennemi && p.NbPointsVie > 0))
            {
                Personnage herosPlusProche = _moteurJeu.TrouverHerosPlusProche(ennemi);
                if (herosPlusProche == null)
                {
                    EvaluerSantePersonnages();
                    break;
                }
                else
                {
                    _moteurJeu.DeplacerVersHerosPlusProche(ennemi, herosPlusProche);
                    Utils.Tracer($"Déplacement de {ennemi.Nom} vers {herosPlusProche.Nom}\n", txtTrace);
                    ActionCompletee();

                    // Si le nombre d'action est à 3, c'est qu'on est rendu au Héros
                    if (_moteurJeu.NbActionRestante == 3)
                        return;

                    if ((ennemi as Attaquant).Attaquer(ennemi, herosPlusProche))
                    {
                        Utils.Tracer($"{ennemi.Nom} à attaqué {herosPlusProche.Nom}\n", txtTrace);
                        ActionCompletee();

                        // Si le nombre d'action est à 3, c'est qu'on est rendu au Héros
                        if (_moteurJeu.NbActionRestante == 3)
                            return;
                    }
                }
            }
        }
    }
}
