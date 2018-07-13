using Newtonsoft.Json;
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
            List<Base> oBase = new List<Base>();
            List<string> oCypher = new List<string>();
            List<List<Values>> oValues = new List<List<Values>>();
            List<string> oWords = new List<string>();

            try
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/base.json")))
                {
                    string json = r.ReadToEnd();
                    oBase = JsonConvert.DeserializeObject<List<Base>>(json);
                }
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/cypher.json")))
                {
                    string json = r.ReadToEnd();
                    oCypher= JsonConvert.DeserializeObject<List<string>>(json);
                }
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/values.json")))
                {
                    string json = r.ReadToEnd();
                    oValues = JsonConvert.DeserializeObject<List<List<Values>>>(json);
                }
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/words.json")))
                {
                    string json = r.ReadToEnd();
                    oWords = JsonConvert.DeserializeObject<List<string>>(json);
                }
            }
            catch(Exception e)
            {
                var t = 0;
            }
            List<string> oResultado = new List<string>();
            for(int i = 0; i < oValues.Count; i++)
            {
                oValues[i].Sort((a, b) => a.order > b.order ? 1 : a.order < b.order ? -1 : 0);
                string sLineaResultado = oCypher[i];

                for (int j = 0; j < oValues[i].Count; j++)
                {
                    var nRegla = oValues[i][j].rule;
                    sLineaResultado = sLineaResultado.Replace(oBase[nRegla].source, oBase[nRegla].replacement);
                }
                oResultado.Add(sLineaResultado);
            }

            ViewData["Datos"] = oResultado;
            return View(); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }



    
}