using AirAtlantique.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AirAtlantique
{
    public static class Switcher
     {
         static ContentControl templater;
         public static void init(ContentControl templateWrapper)
         {
             templater = templateWrapper;
         }
        public static void Navigate(UserControl destination)
         {
             if (templater != null)
                 templater.Content = destination;
         }
     }
}
