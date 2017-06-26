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
    /// <summary>
    /// Context para la conexion a base de datos
    /// </summary>
    public class DentistaContext : DbContext
    {
        public DentistaContext() : base("DentistaDB")
        {
           
        }

        /// <summary>
        /// Lista de entidades de paciente
        /// </summary>
        public DbSet<Paciente> Pacientes { get; set; } 


        /// <summary>
        /// Lista de entidades de tratamientos
        /// </summary>
        public DbSet<Tratamiento> Tratamientos { get; set; }

        /// <summary>
        /// Se definen las caracteristicas de las entidades en base de datos
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Paciente
            modelBuilder.Entity<Paciente>().Property(p => p.Nombre).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Paciente>().Property(p => p.DatosContacto).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Paciente>().Property(p => p.Identificacion).IsRequired();
            //Relacion uno a mucho con tratamiento
            modelBuilder.Entity<Paciente>().HasMany(p => p.Tratamientos).WithRequired().HasForeignKey(t => t.Paciente_Id).WillCascadeOnDelete(true);

            //Tratamiento
            modelBuilder.Entity<Tratamiento>().Property(t => t.Detalle).IsRequired().HasMaxLength(200);
        }


    }
}