using AirAtlantique.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AirAtlantique
{
    /// <summary> 
    /// a tool class to easily change content of main page
    /// </summary>
    public static class Switcher
     {
         static ContentControl templater;
         static ContentControl menu;

        /// <summary>
        ///  a static method to initialise the mainWindow content control
        ///  for we can change it's content
        /// </summary>
        /// <param name="templateWrapper">
        /// the base window (ex : MainWindow) that will contain all of the use controls
        /// </param>
        /// <param name="menuWrapper">
        /// the base menu 
        /// </param>

        public static void init(ContentControl templateWrapper, ContentControl menuWrapper)
         {
             templater = templateWrapper;
             menu = menuWrapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination">
        /// the instance of the destination page
        /// </param>
        public static void Navigate(UserControl destination)
         {
             if (templater != null)
                 templater.Content = destination;
            else
                throw new Exception("you need to give the switcher all the ContentControl that will be filled");
         }
        public static void changeMenu(UserControl menuWrapper)
        {
            if (menu != null)
                menu.Content = menuWrapper;             
            else
                throw new Exception("you need to give the switcher all the ContentControl that will be filled");
        }
    }
}
