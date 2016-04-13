﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Model
{
    public class FormateurExterne 
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string nom { get; set; }

        [Required]
        [StringLength(40)]
        public string prenom { get; set; }

        [Required]
        [StringLength(40)]
        public string email { get; set; }

        [StringLength(40)]
        public string telephone { get; set; }
    }
}
