using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 

namespace Nescoin.Admin.Controllers
{
    public class HomeController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        public ActionResult Index()
        {

            if (Session["Usuario"] == null)
            {
                ViewBag.mensaje = "La session ha caducado";
                Session["viewBagMensaje"] = "La session ha caducado";
                return Redirect("~/Login");
            }
        
            var vi_tbl_ech_prof_com = db.Vi_Tbl_Echo_Prof_Comuna.ToList();
            ViewBag.tblIndicador = db.Tbl_IndicadoresBS.ToList();
            ViewBag.tbl_Vitrina = db.Vi_Trae_Vitrina.ToList();

            return View(vi_tbl_ech_prof_com);
        }

        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            Session["NombreUsuario"] = null;

            return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}