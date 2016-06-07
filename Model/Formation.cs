using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    public class Formation
    {
        [Key]
        public int id { get; set; }

        [StringLength(40)]
        [Required]
        public string nom { get; set; }

        [Required]
        public string duree { get; set; }

        [Required]
        public string dureeValide { get; set; }

        public bool estGlobale { get; set; }

        public bool estActive { get; set; }

        public ICollection<Session> sessions { get; set; }

        public ICollection<Metier> metiers { get; set; }
    }
}
