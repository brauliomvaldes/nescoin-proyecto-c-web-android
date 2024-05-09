using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Nescoin.Conexion.Models;

namespace Nescoin.Cliente.Controllers
{
    public class CompartirController : Controller
    {

        private BD_NESCOINEntities db = new BD_NESCOINEntities();
        // GET: Compartir
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            var id_usuario = Session["idusuario"];
            decimal usuario = decimal.Parse(id_usuario.ToString());
            List<Vi_Trae_contactos_de_usuario> listaContactosUsuario = db.Vi_Trae_contactos_de_usuario.Where(x => x.id_usuario_logueado == usuario).ToList();

            foreach(var objeto in listaContactosUsuario)
            {
                if (objeto.id_usuario == Convert.ToDecimal(Session["contactoSeleccionado"]))
                {
                    Session["NombreContactoAgregar"] = objeto.nombre + " " + objeto.apellido;
                }
            }


            return PartialView(listaContactosUsuario);
        }

        public ActionResult compartirContacto()
        {
            if(Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            var id_usuario = Session["idusuario"];
            decimal usuario = decimal.Parse(id_usuario.ToString());
            List<Vi_Trae_contactos_de_usuario> listaContactosUsuario = db.Vi_Trae_contactos_de_usuario.Where(x => x.id_usuario_logueado == usuario).ToList();
            return PartialView("Index", listaContactosUsuario);
        }

        public ActionResult seleccionaContacto(string id_usuario)
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            try
            {
                var seleccionado = Session["contactoSeleccionado"];
                decimal id_contacto_seleccionado = decimal.Parse(seleccionado.ToString());
                decimal usuario = decimal.Parse(id_usuario.ToString());
                /////////////////////////////////////////
                /// NUEVO CONTACTO CREADO CORRECTAMENTE
                /////////////////////////////////////////
                ///
                Tbl_Contacto unContacto = new Tbl_Contacto();
                Tbl_Contacto contacto = db.Tbl_Contacto.Where(x => x.id_contacto == usuario && x.id_usuario == id_contacto_seleccionado)
                    .FirstOrDefault();
                if (contacto == null)
                {
                    unContacto.id_contacto = usuario;
                    unContacto.id_usuario = id_contacto_seleccionado;
                    //
                    // SE REGISTRA COMO CONTACTO CON CUENTA
                    unContacto.id_tipo_usuario = 1;
                    // SE REGISTRA CON MAXIMA CALIFICACION
                    unContacto.id_calificacion = 5;
                    unContacto.estado = true;
                    db.Tbl_Contacto.Add(unContacto);
                    db.SaveChanges();
                }
            }catch (Exception ex)
            {
                ViewBag.mensaje="Error, los contactos ya pertenece a la la red de contactos del usaurio seleccionado"+ex;
            }
            return Redirect("~/Home");
        }

        public ActionResult usuarioVitrina(string id_usuario)
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }

            try
            {
                var usuarioLogeado = Session["idusuario"];
                decimal id_usuario_logeado = decimal.Parse(usuarioLogeado.ToString());
                decimal usuarioVitrina = decimal.Parse(id_usuario.ToString());
                /////////////////////////////////////////
                /// NUEVO CONTACTO CREADO CORRECTAMENTE
                /////////////////////////////////////////
                ///
                Tbl_Contacto unContacto = new Tbl_Contacto();
                Tbl_Contacto contacto = db.Tbl_Contacto.Where(x => x.id_contacto == usuarioVitrina && x.id_usuario == id_usuario_logeado)
                    .FirstOrDefault();
                if (contacto == null)
                {
                    unContacto.id_contacto = usuarioVitrina;
                    unContacto.id_usuario = id_usuario_logeado;
                    //
                    // SE REGISTRA COMO CONTACTO CON CUENTA
                    unContacto.id_tipo_usuario = 0;
                    // SE REGISTRA CON MAXIMA CALIFICACION
                    unContacto.id_calificacion = 5;
                    unContacto.estado = true;
                    db.Tbl_Contacto.Add(unContacto);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = "Error, los contactos ya pertenece a la la red de contactos del usaurio logeado" + ex;
            }

            return Redirect("~/Home");
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