using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DentistaFavoritoApp.Repositories
{
    /// <summary>
    /// Implementacion del repositorio para la entidad paciente
    /// </summary>
    public class RepositorioPaciente: RepositorioBase<Paciente>, IRepository<Paciente>
    {
        /// <summary>
        /// Se sobreescribe el metodo para que incluya los tratamientos
        /// </summary>
        /// <param name="id">id del paciente en base de datos</param>
        /// <returns>el paciente con sus tratamientos</returns>
        public override Paciente GetById(int id)
        {
            return dbSet.Include(p=>p.Tratamientos).Where(p=>p.Id==id).FirstOrDefault();
        }
    }
}