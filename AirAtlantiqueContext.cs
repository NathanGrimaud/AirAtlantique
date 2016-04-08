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
            Database.SetInitializer<AirAtlantiqueContext>(new CreateDatabaseIfNotExists<AirAtlantiqueContext>());

        }
        public DbSet<Demande> demandes { get; set; }

        public DbSet<Employe> employes { get; set; }

        public DbSet<Formateur> formateurs { get; set; }

        public DbSet<FormateurExterne> formateursExternes { get; set; }

        public DbSet<Formation> formations { get; set; }

        public DbSet<Metier> metiers { get; set; }

        public DbSet<Session> sessions { get; set; }


    }
}
