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
        public static void Navigate(Template destination)
        {
            if (templater != null)
                templater.Content = destination;
        }
        public static void NavigateWithParams(Template destination,MessageArgs param = null){
            Navigate(destination);
            destination.receiveParams(param);
        }
    }
}
