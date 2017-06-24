using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DentistaFavoritoApp.Entity
{
    public class DentistaContext : DbContext
    {
        public DentistaContext() : base("DentistaDB")
        {
           
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Paciente>().HasMany(p => p.Tratamientos);

        
        }


    }
}