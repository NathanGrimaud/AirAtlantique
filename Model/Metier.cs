using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    class Metier
    {
        [Key]
        public int id { get; set; }
        [StringLength(40)]
        public string nom { get; set; }

        public ICollection<Formation> formations { get; set; }
        public ICollection<Employe> employees { get; set; }

    }
}
