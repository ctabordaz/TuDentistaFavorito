using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistaFavoritoApp.Controllers
{
    public class TratamientoController : Controller
    {
        // GET: Tratamiento
        public ActionResult Index(int? id)
        {
            return View("Index");
        }

        public ActionResult PorPaciente(int? id)
        {
            return View("Index");
        }
    }
}