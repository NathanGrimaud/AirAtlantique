using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    class Employe
    {
        [Key]
        public int id { get; set; }

        [StringLength(40)]
        public string nom { get; set; }

        [StringLength(40)]
        public string prenom { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(20)]
        [Index(IsUnique=true)]
        public string login { get; set; }

        [StringLength(450)]
        [Index(IsUnique=true)]
        public string email { get; set; }

        public virtual ICollection<Metier> metier { get; set; }

        public virtual ICollection<Session> sessions { get; set; }

    }
}
