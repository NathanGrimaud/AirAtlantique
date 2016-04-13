using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    public class Demande
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime dateDemande { get; set; }

        [StringLength(40)]
        public string commentaire { get; set; }

        public virtual Status status { get; set; }

        public virtual Employe employe { get; set; }

    }
}
