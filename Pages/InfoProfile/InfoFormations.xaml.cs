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
using AirAtlantique.DAO;
using AirAtlantique.Model;

namespace AirAtlantique.Pages.InfoProfile
{
    /// <summary>
    /// Logique d'interaction pour InfoFormations.xaml
    /// </summary>
    public partial class InfoFormations : UserControl
    {
        public InfoFormations(Model.Employe employe)
        {
            InitializeComponent();
            retour.Click += Retour_Click;
            demandeFormation.Click += DemandeFormation_Click;
            this.loadSessions(employe);
        }
        private void loadSessions(Model.Employe employe)
        {
            foreach (var session in employe.sessions)
            {
                lb_formations.Items.Add(session.nom);
            }
            
        }
        private void DemandeFormation_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
