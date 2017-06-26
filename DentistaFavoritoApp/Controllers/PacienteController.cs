using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistaFavoritoApp.Controllers
{
    /// <summary>
    /// Controlador para la administracion de pacientes
    /// </summary>
    public class PacienteController : Controller
    {
        
        /// <summary>
        /// Pagina de inicio de pacientes
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Pagina para crear pacientes
        /// </summary>
        /// <returns></returns>
        public ActionResult Crear()
        {
            return View();
        }
        /// <summary>
        /// Pagina para editar pacientes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Editar(int? id)
        {
            return View("Crear");
        }

    }
}