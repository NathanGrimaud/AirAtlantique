using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AirAtlantique.DAO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirAtlantique.Pages.Session
{
    /// <summary>
    /// Logique d'interaction pour AjouterSession.xaml
    /// </summary>
    public partial class AjouterSession : UserControl
    {
        public AjouterSession()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Ajouter une session";
            ShowData();

        }

        //On affiche les formations disponibles
        private void ShowData()
        {
            foreach (var formations in FormationDAO.ListerFormations())
            {
                CB_listeFormations.Items.Add(formations.nom);
            }
        }

        private void RefreshData()
        {
            TB_NomSession.Clear();
            DP_date_debut.SelectedDate = null;
            DP_date_fin.SelectedDate = null;
            LB_employés.SelectedItems.Clear();
            TB_NomSession.Focus();
        }

        private void listeFormations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_listeFormations != null)
            {
                SelectEmploye(CB_listeFormations.SelectedItem.ToString());
            }

        }

        private void SelectEmploye(string formation)
        {
            foreach (var employes in EmployéDAO.MétierEmployéFormation(formation))
            {
                LB_employés.Items.Add(employes.prenom + " " + employes.nom);
            }
        }


        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home.Home());
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {

            List<string> employé = new List<string>();
            foreach (var item in LB_employés.SelectedItems)
            {
                employé.Add(item.ToString());
            }
            SessionDAO.AjouterSession(TB_NomSession.Text, DP_date_debut.SelectedDate.Value, DP_date_fin.SelectedDate.Value, CB_listeFormations.Text, employé);
            RefreshData();
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home.Home());
        }
    }
}
