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
    /// Logique d'interaction pour AjouterMetier.xaml
    /// </summary>
    public partial class AjouterMetier : UserControl
    {
        public AjouterMetier()
        {
            InitializeComponent();
            ShowData();

        }
        private void ShowData()
        {
            List<Model.Metier> listeMetier = LiaisonBDD.ListeMetiers();
            foreach (var metier in listeMetier)
            {
                listeMetiers.Items.Add(metier.nom);
            }
        }

        private void RefreshData()
        {
            listeMetiers.Items.Clear();
            alertEmpty.Text = String.Empty;
            ShowData();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (addMetier.Text != "")
            {
                LiaisonBDD.AjouterMetier(addMetier.Text);
                addMetier.Clear();
                RefreshData();
                
            }
            else
            {
                alertEmpty.Text = "Veuillez entrer un métier valide!";
            }
        }
    }
}
