using AirAtlantique.Pages.Component;
using System;
using System.Collections;
using System.Collections.Generic;
using AirAtlantique.DAO;
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

namespace AirAtlantique.Pages.Formation
{
    /// <summary>
    /// Logique d'interaction pour ajouterFormation.xaml
    /// </summary>
    public partial class ajouterFormation : UserControl
    {
        public ajouterFormation() : base()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Ajouter une formation";
            ShowData();
        }

        private void ShowData()
        {
            List<Model.Metier> listeMetier = MetierDAO.ListerMétier();
            foreach (var metier in listeMetier)
            {
                LB_Metiers.Items.Add(metier.nom);
            }

            foreach (var formations in FormationDAO.ListerFormations())
            {
                LB_ListeFormations.Items.Add(formations.nom);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool estGlobale = false;
            bool estActive = true;
            List<string> metierChoisis = LB_Metiers.SelectedItems.Cast<string>().ToList();

            if (CB_estGlobale.IsChecked == true)
            {
                estGlobale = true;
            }


            try
            {
                FormationDAO.AjouterFormation(TB_nom.Text, TB_duree.Text, TB_dureeVal.Text, estGlobale, estActive, metierChoisis);
                ClearInputs();
                ShowData();
            }
            catch
            {
                TB_Alert.Visibility = Visibility.Visible;
                TB_Alert.Text = "Veuillez renseigner tous les champs";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Formation.ajouterFormation());
        }


        private void ClearInputs()
        {
            //Clear all input
            TB_nom.Clear();
            TB_duree.Clear();
            TB_dureeVal.Clear();
            CB_estGlobale.IsChecked = false;
            LB_Metiers.Items.Clear();
            LB_ListeFormations.Items.Clear();
        }

        public void BT_majFormation_Click(object sender, RoutedEventArgs e)
        {
            //if (LB_ListeFormations.SelectedItem.Equals(1))
            //{
                Model.Formation maFormation = FormationDAO.SelectFormation(LB_ListeFormations.SelectedItem.ToString());
                maFormation.nom = TB_nom.Text;
                maFormation.duree = TB_duree.Text;
                maFormation.dureeValide = TB_dureeVal.Text;
                maFormation.estActive = true;
                bool obligatoire = false;
                if (CB_estGlobale.IsChecked == true)
                {
                    obligatoire = true;
                }
                maFormation.estGlobale = obligatoire;
                FormationDAO.EditerFormation(maFormation);
                ClearInputs();
                ShowData();
            //}

        }

        private void BT_supprimer_Click(object sender, RoutedEventArgs e)
        {
            var item = LB_ListeFormations.SelectedItem.ToString();
            FormationDAO.SupprimerFormation(item);
            ClearInputs();
            ShowData();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home.Home());
        }

        private void LB_ListeFormations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_ListeFormations.HasItems)
            {
                editFormation.Visibility = Visibility.Visible;
                Model.Formation maFormation = FormationDAO.SelectFormation(LB_ListeFormations.SelectedItem.ToString());
                TB_nom.Text = maFormation.nom;
                TB_duree.Text = maFormation.duree;
                TB_dureeVal.Text = maFormation.dureeValide;
                if (maFormation.estGlobale == true)
                {
                    CB_estGlobale.IsChecked = true;
                }
            }
        }
    }
}
