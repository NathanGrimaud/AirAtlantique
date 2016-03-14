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
                //db.SaveChanges();
                this.testFrero.Text = "in db";
            }
        }

        private void ChangePage_Click(object sender, RoutedEventArgs e)
        {
            var switcher = new Switcher(new Template());
            var args = new MessageArgs();
            args.Add("login", this.Username);
            args.Add("password", this.Password);
            switcher.NavigateWithParams(new Home(),args);
        }
    }
}
