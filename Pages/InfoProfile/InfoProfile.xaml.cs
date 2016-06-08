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
using AirAtlantique.Pages.Login;
namespace AirAtlantique.Pages.InfoProfile
{

    /// <summary>
    /// Logique d'interaction pour InfoProfile.xaml
    /// </summary>
    /// 
    public partial class InfoProfile : UserControl
    {
        private Employe employee;
        public InfoProfile()
        {
            InitializeComponent();
            Deconnexion.Click += Deconnexion_Click;
            Sessions.Click += Sessions_Click;
        }

        private void Sessions_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new InfoFormations(this.employee));
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Login.Login());
        }

        public void loadInfos(Employe employee)
        {
            Username.Text = employee.samAccountName;
            Nom.Text = employee.nom;
            Prenom.Text = employee.prenom;
            try
            {
                Poste.Text = employee.metier.First<Metier>().nom;
            }
            catch (Exception)
            {
                Poste.Text = "visiteur";
            }
           
        }
        public void setEmployee(Employe employee)
        {
            this.employee = employee;
            this.loadInfos(employee);
        }
    }
}
