using AirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using AirAtlantique.DAO;
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

namespace AirAtlantique.Pages.Employé
{
    /// <summary>
    /// Logique d'interaction pour AjouterEmployé.xaml
    /// </summary>
    public partial class AjouterEmployé : UserControl
    {
        public AjouterEmployé()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Ajouter un employé";
            List<Metier> listeMetier = MetierDAO.ListerMétier();
            foreach (var metier in listeMetier)
            {
                lesMetiers.Items.Add(metier.nom);
            }
        }

        private void ajouterEmploye_Click(object sender, RoutedEventArgs e)
        {
            //identifiant par défaut de l'employé (prénom.nom)
            var login = prenomEmploye.Text.ToLower() + "." + nomEmploye.Text.ToLower();

            //mot de passe par défaut de l'employé (prénom.nom) A définir par l'utilisateur ensuite?
            var mdp = prenomEmploye.Text.ToLower() + "." + nomEmploye.Text.ToLower();

            //mail par défaut de l'employé (prénom.nom@airatlantique.com)
            var mail = prenomEmploye.Text.ToLower() + "." + nomEmploye.Text.ToLower() + "@airatlantique.com";

            List<Metier> listeMetier = MetierDAO.ListerMétier();
            List<string> metierChoisis = lesMetiers.SelectedItems.Cast<string>().ToList();
            try
            {
                EmployéDAO.AjouterEmployé(nomEmploye.Text, prenomEmploye.Text, mdp, login, mail, metierChoisis);
                //Clear all input
                nomEmploye.Clear();
                prenomEmploye.Clear();
                TB_Alert.Text = null;
            }
            catch
            {
                TB_Alert.Visibility = Visibility.Visible;
                TB_Alert.Text = "Veuillez renseigner tous les champs";
            }


        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new HomeEmployés());
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new HomeEmployés());
        }
    }
}
