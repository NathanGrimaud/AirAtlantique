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

namespace AirAtlantique.Pages.Component
{
    /// <summary>
    /// Logique d'interaction pour SideMenu.xaml
    /// </summary>
    public partial class SideMenu : UserControl
    {
        List<Rectangle> iconsArray;
        public SideMenu()
        {

            InitializeComponent();
            iconsArray = new List<Rectangle>() {
                this.allIcon,this.menuIcon,this.rhIcon,this.cIcon
            };
  
        }
        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
         
            foreach (var item in this.iconsArray)
            {
                if (item.IsMouseOver)                   
                     item.Fill.Opacity = 0.2;
            }
            
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (var item in this.iconsArray)
            {
                if (!item.IsMouseOver)                
                 item.Fill.Opacity = 1;
            }
        }

        private void menuIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.slideMenu.Visibility == System.Windows.Visibility.Visible)
                this.slideMenu.Visibility = System.Windows.Visibility.Collapsed;
            else
                this.slideMenu.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
