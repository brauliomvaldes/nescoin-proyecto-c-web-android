using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class HistorialContactoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: ListaContacto
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View();
        }


        /*
         Muestra el historial segun el usuario que entra por parametro
         flag = 1 usuario logueado
         flag = 2 usuario seleccionado
        */
        public ActionResult retornaHistorialContacto(string flag)
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            var id_usuario = Session["idusuario"];
            if (flag == "2")
            {
                id_usuario = Session["idUsuarioLogeado"];
            }

            decimal usuario = decimal.Parse(id_usuario.ToString());
            List<Vi_Trae_Historial> listaHistorialContacto = db.Vi_Trae_Historial.Where(x => x.id_usuario == usuario).ToList();
            return PartialView("Index", listaHistorialContacto);
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