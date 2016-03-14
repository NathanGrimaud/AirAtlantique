using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirAtlantique.Model;
namespace AirAtlantique
{
    class AirAtlantiqueContext : DbContext
    {

            public AirAtlantiqueContext() : base("AirAtlantique")
            {

            }
            public virtual DbSet<Demande> demandes  { get; set; }
            public virtual DbSet<Employe> employes  { get; set; }
            public virtual DbSet<Formateur> formateurs  { get; set; }
            public virtual DbSet<FormateurExterne> formateursExternes  { get; set; }
            public virtual DbSet<Formation> formations  { get; set; }
            public virtual DbSet<Metier> metiers  { get; set; }
            public virtual DbSet<Session> sessions  { get; set; }
        
    }
}
