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
      
    }
}