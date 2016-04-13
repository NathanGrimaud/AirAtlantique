using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace AirAtlantique.Pages
{
    /// <summary>
    /// Logique d'interaction pour GérerEmployé.xaml
    /// </summary>
    public partial class GérerEmployé : UserControl
    {
        public GérerEmployé()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Gestion des employés";
            foreach (var employé in LiaisonBDD.ListerEmployé())
            {
                LB_liste_employé.Items.Add(employé.prenom + " " + employé.nom);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new HomeEmployés());
        }


        private void LB_liste_employé_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LB_metiers_Employe.Items.Clear();
            LB_Sessions.Items.Clear();

            Model.Employe clicEmploye = LiaisonBDD.SelectUniqueEmployé(LB_liste_employé.SelectedItem.ToString());
            TB_Nom.Text = clicEmploye.nom;
            TB_Prénom.Text = clicEmploye.prenom;
            TB_Mail.Text = clicEmploye.email;

            Model.Metier metiers = LiaisonBDD.SelectMetierEmploye(clicEmploye);
            LB_metiers_Employe.Items.Add(metiers.nom);

            //Model.Formation formations = LiaisonBDD.SelectFormationEmploye(clicEmploye);
            //LB_Formations.Items.Add(formations.nom);

            List<Model.Formation> sessions = LiaisonBDD.SelectFormationEmploye(clicEmploye);
            foreach (var item in sessions)
            {
                LB_Sessions.Items.Add(item.nom);
            }

        }
    }
}
