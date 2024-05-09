using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class VitrinaController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();
        
        // GET: Vitrina
        public ActionResult Index()
        {
            var tbl_usuario = db.Vi_Trae_Vitrina.OrderByDescending(x => x.promedio_calificacion).ToList();
            return View(tbl_usuario);
        }
    }
}