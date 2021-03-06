﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DentistaFavoritoApp.App_Start
{
    public class BundleConfig
    {
        /// <summary>
        /// Agrupa los archivos a utililizar por la aplicacion
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-resource.min.js",
                        "~/Scripts/App/App.js",
                        "~/Scripts/App/Services/ResourcesService.js",
                        "~/Scripts/App/Services/UtilitiesService.js",
                        "~/Scripts/App/Controllers/HomeController.js",
                        "~/Scripts/App/Controllers/PacienteController.js",
                        "~/Scripts/App/Controllers/CrearPacienteController.js",
                        "~/Scripts/App/Controllers/TratamientoController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/ui-bootstrap.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}