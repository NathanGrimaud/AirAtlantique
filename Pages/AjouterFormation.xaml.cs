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
            List<Model.Metier> listeMetier = LiaisonBDD.ListeMetiers();
            foreach (var metier in listeMetier)
            {
                Metiers.Items.Add(metier.nom);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool estGlobale = false;
            bool estActive = false;

            if (Globale.IsChecked == true)
            {
                estGlobale = true;
            }

            List<Model.Metier> listeMetier = LiaisonBDD.ListeMetiers();
            List<string> metierChoisis = Metiers.SelectedItems.Cast<string>().ToList();
            List<Model.Metier> LesMetiers = new List<Model.Metier>();

            foreach (var metier in listeMetier)
            {
                foreach (var item in metierChoisis)
                {
                    if (metier.nom == item)
                        LesMetiers.Add(metier);
                }
            }
            ICollection<Model.Metier> collectionMetiers = LesMetiers;
            LiaisonBDD.AddFormation(Nom.Text, int.Parse(Duree.Text), Date.DisplayDate, estGlobale, estActive, collectionMetiers);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
