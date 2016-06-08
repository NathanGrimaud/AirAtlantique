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
using AirAtlantique.Model;

namespace AirAtlantique.Pages.Formation
{
    /// <summary>
    /// Logique d'interaction pour DemandeFormation.xaml
    /// </summary>
    public partial class DemandeFormation : UserControl
    {
        public DemandeFormation()
        {
            InitializeComponent();
            Valider.Click += Valider_Click;
            retour.Click += Retour_Click;

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if(commentaire.Text != "" && picker.Text != "")
            {
                var demande = new Model.Demande()
                {
                    commentaire = commentaire.Text,
                    dateDemande = picker.Text,
                    
                };
            }            
        }
    }
}
