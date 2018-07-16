using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SolucionAlEjercicio.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static SolucionAlEjercicio.Models.JSONModel;

namespace SolucionAlEjercicio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var oSolution = new Solution_BL();

            var oData = oSolution.DecypherPuzzle();
            var oResult = oSolution.ResolvePuzzle(oData);

            ViewData["Data"] = oData.Lines;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<List<Location>>));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, oResult);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            string jsonData = sr.ReadToEnd();

            ViewData["Result"] = jsonData;

            return View(); 
        }
    }
}