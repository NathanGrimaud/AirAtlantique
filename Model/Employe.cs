using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;   
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    public class Employe
    {
        [Key]
        [Required]
        public int id { get; set; }

         [StringLength(40)]
        [Required]
        public string nom { get; set; }

        [StringLength(40)]
        [Required]
        public string prenom { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(20)]
        [Index(IsUnique=true)]
        public string samAccountName { get; set; }

        [StringLength(450)]
        [Index(IsUnique=true)]
        public string email { get; set; }

        public virtual ICollection<Metier> metier { get; set; }

        public virtual ICollection<Session> sessions { get; set; }
        public override string ToString()
        {
            return this.prenom + " " + this.nom;
        }
    }
}
