using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AirAtlantique.Pages
{
    public class Template: ContentControl
    {
        public MessageArgs arguments { get; set; }
        public Template():base()
        {

        }
        public void receiveParams(MessageArgs parameters = null) {

        }
    }
}
