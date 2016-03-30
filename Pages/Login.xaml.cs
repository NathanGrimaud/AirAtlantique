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
using System.DirectoryServices;

namespace AirAtlantique.Pages
{

    public partial class Login 
    {
        private Employe admin { get; set; }
        public Login() : base()
        {
            InitializeComponent();
            changePage.Click += ChangePage_Click;
            
        }

        private void ChangePage_Click(object sender, RoutedEventArgs e)
        {          
            
        }
        
        private DirectoryEntry connectToAD()
        {
            var ldap = new DirectoryEntry("nathan.ad.epsi.fr");
            ldap.AuthenticationType = AuthenticationTypes.Secure;
            ldap.Path = "OU=Secretariat,OU=NathanCorp,DC=nathan,DC=ad,DC=epsi,DC=fr";
            return ldap;
        }
    }
}
