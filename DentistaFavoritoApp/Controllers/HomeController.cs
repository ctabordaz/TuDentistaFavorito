﻿using DentistaFavoritoApp.Entity;
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

        public ActionResult Index()
        {   
            return View();
        }
    }
}