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
            var oDatos = ObtenerDatos();
            ViewData["Datos"] = DecifrarDatos(oDatos);

            return View(); 
        }

        /// <summary>
        /// Aplicar el algoritmo Markov para decifrar la sopa de letras
        /// </summary>
        /// <param name="oDatos"></param>
        /// <returns></returns>
        private List<string> DecifrarDatos(DatosJSON oDatos)
        {
            List<string> oResultado = new List<string>();
            for (int i = 0; i < oDatos.oValues.Count; i++)
            {
                oDatos.oValues[i].Sort((a, b) => a.order > b.order ? 1 : a.order < b.order ? -1 : 0);
                string sLineaResultado = oDatos.oCypher[i];

                for (int j = 0; j < oDatos.oValues[i].Count; j++)
                {
                    var nRegla = oDatos.oValues[i][j].rule;
                    sLineaResultado = sLineaResultado.Replace(oDatos.oBase[nRegla].source, oDatos.oBase[nRegla].replacement);
                }
                oResultado.Add(sLineaResultado);
            }
            return oResultado;
        }

        /// <summary>
        /// Obtiene los datos con los que se va a trabajar
        /// </summary>
        /// <returns>los datos como objetos</returns>
        private DatosJSON ObtenerDatos()
        { // http, fs, bd
            DatosJSON oDatos = new DatosJSON();

            using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/base.json")))
            {
                string json = r.ReadToEnd();
                oDatos.oBase = JsonConvert.DeserializeObject<List<Base>>(json);
            }
            using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/cypher.json")))
            {
                string json = r.ReadToEnd();
                oDatos.oCypher = JsonConvert.DeserializeObject<List<string>>(json);
            }
            using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/values.json")))
            {
                string json = r.ReadToEnd();
                oDatos.oValues = JsonConvert.DeserializeObject<List<List<Values>>>(json);
            }
            using (StreamReader r = new StreamReader(Server.MapPath("~/App_Data/json/words.json")))
                {
                    string json = r.ReadToEnd();
                    oDatos.oWords = JsonConvert.DeserializeObject<List<string>>(json);
                }

            return oDatos;
        }
    }
}