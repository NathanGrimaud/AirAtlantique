using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    public class Formateur
    {
        [Key]
        public int id { get; set; }

        public bool estInterne { get; set; }
        public virtual Employe formateurInterne { get; set; }
        public virtual FormateurExterne formateurExterne { get; set; }

    }
}
