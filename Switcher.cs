using AirAtlantique.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AirAtlantique
{
    public partial class UserControl
    {
        Dictionary<String, Object> parameters {get;set;}
        public void receiveParams(Dictionary<String, Object> p)
        {
            this.parameters = p;
        }
    }

    public class Switcher
    {
        Template templater;
        public Switcher(Template templateWrapper)
        {
            this.templater = templateWrapper;

        }

        public void Navigate<T>(T destination)
        {
            if (templater != null)
                templater.Content = destination;
        }


       public void NavigateWithParams<T>(T destination,MessageArgs param ){
            if (templater != null)
                templater.arguments = param;
            Navigate(destination);            
       }
    }
}
