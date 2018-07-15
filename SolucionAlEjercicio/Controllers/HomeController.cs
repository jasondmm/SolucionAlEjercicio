﻿using Newtonsoft.Json;
using SolucionAlEjercicio.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SolucionAlEjercicio.Models.JSONModel;

namespace SolucionAlEjercicio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var oDatos = new Solution_BL().DecypherPuzzle();

            ViewData["Datos"] = oDatos.Lines;



            return View(); 
        }

        
    }
}