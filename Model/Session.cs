﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    public class Session
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nom { get; set; }

        [Required]
        public DateTime dateDebut { get; set; }

        [Required]
        public DateTime dateFin { get; set; }

        [Required]
        public virtual Formation formation { get; set; }
         
        public virtual ICollection<Employe> employes { get; set; }
        
    }
}
