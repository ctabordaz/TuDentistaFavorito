using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DentistaFavoritoApp.Repositories
{
    public class RepositorioPaciente: RepositorioBase<Paciente>, IRepository<Paciente>
    {
        public override Paciente GetById(int id)
        {
            return dbSet.Include(p=>p.Tratamientos).Where(p=>p.Id==id).FirstOrDefault();
        }
    }
}