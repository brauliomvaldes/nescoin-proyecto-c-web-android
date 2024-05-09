using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class HomeController : Controller
    {

        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            Session["Objeto_Usuario"] = "usuario logeado";
            ViewBag.Session = Session["Usuario"];
            ViewBag.Escritorio = true;
            return View();
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Planes()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        public ActionResult DetalleContacto(string id_usuario)
        {

            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            ViewBag.nombreUsuario = Session["NombreUsuario"];
            Session["idUsuarioLogeado"] = id_usuario;
            
            decimal usuario = decimal.Parse(id_usuario.ToString());
            List<Vi_Trae_Vitrina> tbl_usuario = db.Vi_Trae_Vitrina.Where(x => x.id_usuario == usuario).ToList();
            Session["contactoSeleccionado"] = id_usuario;
            return View(tbl_usuario);
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