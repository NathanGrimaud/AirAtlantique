using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirAtlantique.Pages
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

        private void ShowData()
        {
            foreach (var formations in LiaisonBDD.ListerFormations())
            {
                CB_listeFormations.Items.Add(formations.nom);
            }
        }

        private void RefreshData()
        {
            TB_NomSession.Clear();
            DP_date_debut.SelectedDate = null;
            DP_date_fin.SelectedDate = null;
            CB_listeFormations.Items.Clear();
            LB_employés.Items.Clear();
        }

        private void listeFormations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_listeFormations != null)
            {
                RefreshData();
                SelectEmploye(CB_listeFormations.SelectedItem.ToString());
            }

        }

        private void SelectEmploye(string formation)
        {
            foreach (var employes in LiaisonBDD.MétierEmployéFormation(formation))
            {
                LB_employés.Items.Add(employes.nom + " " + employes.prenom);
            }
        }


        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home());
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            List<string> employé = new List<string>();
            foreach (var item in LB_employés.SelectedItems)
            {
                employé.Add(item.ToString());
            }
            try
            {
                LiaisonBDD.AjouterSession(TB_NomSession.Text, DP_date_debut.DisplayDate, DP_date_fin.DisplayDate, CB_listeFormations.Text, employé);
                RefreshData();
            }
            catch
            {
                TB_Alert.Visibility = Visibility.Visible;
                TB_Alert.Text = "Veuillez renseigner tous les champs";
            }
        }
    }
}
