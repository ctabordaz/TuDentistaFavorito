using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
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
            modelBuilder.Entity<Paciente>().Property(p => p.Identificacion).IsRequired().HasColumnAnnotation(IndexAnnotation.AnnotationName,new IndexAnnotation( new IndexAttribute("IX_Identificacion", 1) { IsUnique = true }));
            modelBuilder.Entity<Paciente>().HasMany(p => p.Tratamientos).WithRequired().HasForeignKey(t => t.Paciente_Id).WillCascadeOnDelete(true);

        
        }


    }
}