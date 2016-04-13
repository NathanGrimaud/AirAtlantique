using AirAtlantique.Pages.Component;
using System;
using System.Collections;
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
    /// Logique d'interaction pour ajouterFormation.xaml
    /// </summary>
    public partial class ajouterFormation : UserControl
    {
        public ajouterFormation() : base()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Ajouter une formation";
            List<Model.Metier> listeMetier = LiaisonBDD.ListerMétier();
            foreach (var metier in listeMetier)
            {
                Metiers.Items.Add(metier.nom);
            }

            foreach (var formations in LiaisonBDD.ListerFormations())
            {
                LB_ListeFormations.Items.Add(formations.nom);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool estGlobale = false;
            bool estActive = true;

            if (Globale.IsChecked == true)
            {
                estGlobale = true;
            }

            List<string> metierChoisis = Metiers.SelectedItems.Cast<string>().ToList();
            try
            {
                LiaisonBDD.AjouterFormation(Nom.Text, int.Parse(Duree.Text), Date.DisplayDate, estGlobale, estActive, metierChoisis);

                //Clear all input
                Nom.Clear();
                Duree.Clear();
                Date.SelectedDate = null;
                Globale.IsChecked = false;
                Metiers.Items.Clear();
            }
            catch
            {
                TB_Alert.Visibility = Visibility.Visible;
                TB_Alert.Text = "Veuillez renseigner tous les champs";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home());
        }

    }
}
