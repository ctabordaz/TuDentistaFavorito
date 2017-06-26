using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistaFavoritoApp.Controllers
{
    /// <summary>
    /// Controlador para la administracion de tratamientos
    /// </summary>
    public class TratamientoController : Controller
    {

        /// <summary>
        /// Pagina de inicio para trataientos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            return View("Index");
        }

        /// <summary>
        /// Pagina para mostrar los tratamientos por paciente
        /// </summary>
        /// <param name="id">id paciente</param>
        /// <returns></returns>
        public ActionResult PorPaciente(int? id)
        {
            return View("Index");
        }
    }
}