using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentistaFavoritoApp.Repositories
{
    /// <summary>
    /// Implementacion del repositorio para la entidad paciente
    /// </summary>
    public class RepositorioTratamiento : RepositorioBase<Tratamiento>, IRepository<Tratamiento>
    {
    }
}