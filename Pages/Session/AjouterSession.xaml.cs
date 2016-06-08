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
            ShowSession();
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
            LB_session.Items.Clear();
            DP_date_debut.SelectedDate = null;
            DP_date_fin.SelectedDate = null;
            LB_employés.SelectedItems.Clear();
            TB_NomSession.Focus();
        }

        private void listeFormations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_listeFormations != null)
            {
                LB_employés.Items.Clear();
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
            //Switcher.Navigate(new Home.Home(this.em));
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {

            List<string> employé = new List<string>();
            foreach (var item in LB_employés.SelectedItems)
            {
                employé.Add(item.ToString());
            }

            if (employé.Count == 0)
            {
                TB_Alert.Text = "Veuillez renseigner tout les champs";
                TB_Alert.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    SessionDAO.AjouterSession(TB_NomSession.Text, DP_date_debut.SelectedDate.Value, DP_date_fin.SelectedDate.Value, CB_listeFormations.Text, employé);

                    TB_Alert.Visibility = Visibility.Hidden;
                    TB_NomSession.Clear();
                    DP_date_debut.SelectedDate = null;
                    DP_date_fin.SelectedDate = null;
                    CB_listeFormations.SelectedIndex = -1;
                    LB_employés.Items.Clear();
                }
                catch
                {
                    TB_Alert.Text = "Veuillez renseigner tous les champs";
                    TB_Alert.Visibility = Visibility.Visible;
                }
            }

            RefreshData();
            ShowSession();
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.Navigate(new Home.Home());
        }

        private void ShowSession ()
        {
            List<Model.Session> sessions = SessionDAO.ListerAllSession();
            foreach (var item in sessions)
            {
                LB_session.Items.Add(item.nom);
            }
        }

        private void LB_session_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_session.HasItems)
            {
                BT_MAJ.Visibility = Visibility.Visible;
                BT_SUPPR.Visibility = Visibility.Visible;
                Model.Session session = SessionDAO.SelectSession(LB_session.SelectedItem.ToString());
                TB_NomSession.Text = session.nom;
                DP_date_debut.SelectedDate = session.dateDebut;
                DP_date_fin.SelectedDate = session.dateFin;

                CB_listeFormations.Items.Add(SessionDAO.SelectSession(LB_session.SelectedItem.ToString()));
            }
        }


        private void BTDelete_Click(object sender, RoutedEventArgs e)
        {
            Model.Session sessionClick = SessionDAO.SelectUniqueSession(LB_session.SelectedItem.ToString());
            SessionDAO.SupprimerSession(sessionClick);
            BT_MAJ.Visibility = Visibility.Hidden;
            BT_SUPPR.Visibility = Visibility.Hidden;
            BT_ajouter.Visibility = Visibility.Visible;
            BT_annuler.Visibility = Visibility.Hidden;
            RefreshData();
        }


        private void BT_MAJ_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BT_SUPPR_Click(object sender, RoutedEventArgs e)
        {
            Model.Session sessionClick = SessionDAO.SelectUniqueSession(LB_session.SelectedItem.ToString());
            SessionDAO.SupprimerSession(sessionClick);
            BT_MAJ.Visibility = Visibility.Hidden;
            BT_SUPPR.Visibility = Visibility.Hidden;
            BT_ajouter.Visibility = Visibility.Visible;
            BT_annuler.Visibility = Visibility.Hidden;
            RefreshData();
        }
    }
}
