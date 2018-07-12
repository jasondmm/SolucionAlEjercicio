using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolucionAlEjercicio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/base.json")))
                {
                    string json = r.ReadToEnd();
                    List<Base> oBase = JsonConvert.DeserializeObject<List<Base>>(json);
                }
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/cypher.json")))
                {
                    string json = r.ReadToEnd();
                    List<string> oBase = JsonConvert.DeserializeObject<List<string>>(json);
                }
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/values.json")))
                {
                    string json = r.ReadToEnd();
                    List< List<Values>>oBase2 = JsonConvert.DeserializeObject<List<List<Values>>>(json);
                }
                using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/words.json")))
                {
                    string json = r.ReadToEnd();
                    List<string> oBase = JsonConvert.DeserializeObject<List<string>>(json);
                }
            }
            catch(Exception e)
            {
                var t = 0;
            }



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



    class Base
    {
        public string source { get; set; }
        public string replacement { get; set; }
    }
    class Values
    {
        public int order { get; set; }
        public int rule { get; set; }
        public bool isTermination { get; set; }
    }
}