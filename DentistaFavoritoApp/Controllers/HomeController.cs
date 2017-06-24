using DentistaFavoritoApp.Entity;
using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistaFavoritoApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                Repositories.IRepository<Paciente> Pacientes = new Repositories.RepositorioPaciente();

                IEnumerable<Paciente> lista = Pacientes.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
            return View();
        }
    }
}