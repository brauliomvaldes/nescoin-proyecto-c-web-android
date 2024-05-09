using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class ListaContactoController : Controller
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

        public ActionResult retornaListaContacto()
        {
            if (Session["Usuario"] != null)
            {
                var id_usuario = Session["idusuario"];
                decimal usuario = decimal.Parse(id_usuario.ToString());
                List<Vi_Trae_contactos_de_usuario> listaContactosUsuario = db.Vi_Trae_contactos_de_usuario.OrderByDescending(x=> x.promedio_calificacion).Where(x => x.id_usuario_logueado == usuario).ToList();
                ViewBag.ListaContactoAll = listaContactosUsuario;
                Session["idesContactos"] = listaContactosUsuario;
                return PartialView("Index");
                
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        //[HttpGet]
        //public ActionResult Search()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Search(string buscarTexto)
        {
            if (buscarTexto != null)
            {
                try
                {
                    Tbl_Usuario UsuarioLogueado = (Tbl_Usuario)Session["Usuario"];
                    List<Vi_Trae_contactos_de_usuario> contacto = db.Vi_Trae_contactos_de_usuario.Where(x => x.id_usuario_logueado == UsuarioLogueado.id_usuario && (x.nombre.Contains(buscarTexto) || x.apellido.Contains(buscarTexto) || x.Profesion.Contains(buscarTexto))).ToList();
                    ViewBag.ListaContactoEspecificos = contacto;

                    return PartialView("SearchContactos", contacto);
                }
                catch (Exception e)
                {
                    // handle exception
                }
            }
            return PartialView("Error");
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