using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TP_Recapitulatif.Models;

namespace TP_Recapitulatif.DAL
{
    public class LibraryContext :DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {
        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Ouvrage> Ouvrages { get; set; }
        protected override void OnModelCreating(DbModelBuilder
        modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

