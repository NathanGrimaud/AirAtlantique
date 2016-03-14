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
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home 
    {
        public Home() : base()
        {
            InitializeComponent();
        }
        public void receiveParams(MessageArgs param)
        {
            var login = param["login"];
            var password = param["password"];
            @params.Text = "identifiants :" + login + " : " + password;
        }

    }
}
