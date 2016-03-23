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

namespace AirAtlantique.Pages
{

    public partial class Login 
    {
        private Employe admin { get; set; }
        public Login() : base()
        {
            InitializeComponent();
            changePage.Click += ChangePage_Click;
            using (var db = new AirAtlantiqueContext())
            {
                var admin = new Employe()
                {
                    email = "admin@aa.com",
                    login = "admin",
                    nom = "admin",
                    prenom = "admin"
                };
                db.employes.Add(admin);
                this.admin = admin;      
            }
        }

        private void ChangePage_Click(object sender, RoutedEventArgs e)
        {          
            var args = new Dictionary<String, Object>();
            args.Add("nom",this.admin.nom );
            args.Add("prenom",this.admin.prenom );
            this.testFrero.Text = "avant navigation";

            Switcher.Navigate(new Home(args) );

        }
    }
}
