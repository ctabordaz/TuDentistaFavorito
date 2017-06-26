using DentistaFavoritoApp.Entity;
using DentistaFavoritoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistaFavoritoApp.Controllers
{
    /// <summary>
    /// Controlador de pagina de inicio
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// Pagina de inicio
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {   
            return View();
        }
    }
}