using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class PresupuestoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: ListaContacto
        public ActionResult Index(string id_movimiento, string idUsuario)
        {

            var _id_movimiento = Convert.ToDecimal(id_movimiento);


            //var id_usuario = Session["idusuario"];
            //id_usuario = Session["idUsuarioLogeado"];


            ViewBag.rutaFormulario = "/Presupuesto/ResponderSolicitudPresupuesto";
            decimal usuario = decimal.Parse(idUsuario.ToString());
            List<Vi_Verifica_Solicitud_Presupuesto> listaPresupuesto = db.Vi_Verifica_Solicitud_Presupuesto.Where(x => x.usuario_logueado == usuario && x.id_movimiento == _id_movimiento).ToList();
            return PartialView("Index", listaPresupuesto);

        }

        /*
         Muestra las lista de presupuesto segun el usuario que entra por parametro
         flag = 1 usuario logueado
         flag = 2 usuario seleccionado
        */

        public PartialViewResult retornaListaPresupuesto(string flag)
        {
            var id_usuario = Session["idusuario"];
            if (flag == "2")
            {
                id_usuario = Session["idUsuarioLogeado"];
            }

            ViewBag.FlagButton = flag;

            decimal usuario = decimal.Parse(id_usuario.ToString());
            List<Vi_Verifica_Solicitud_Presupuesto> listaPresupuesto = db.Vi_Verifica_Solicitud_Presupuesto.Where(x => x.usuario_logueado == usuario).ToList();
            return PartialView("~/Views/Presupuesto/Responder.cshtml", listaPresupuesto);
        }


        public ActionResult ResponderSolicitudPresupuesto(string frm8_btnAcepta, string frm8_btnRechaza, string frm8_id_movimiento, string frm8_descripcion)
        {

            decimal _id_tipo_movimiento = 0;

            if (frm8_btnAcepta != null)
            {
                _id_tipo_movimiento = 3;
            }
            else
            {
                _id_tipo_movimiento = 6;
            }

            var _id_movimiento = Convert.ToDecimal(frm8_id_movimiento);

            Tbl_movimiento mov = db.Tbl_movimiento.Where(x => x.id_movimiento == _id_movimiento).FirstOrDefault();

            mov.id_tipo_movimiento = _id_tipo_movimiento;
            mov.descripcion = frm8_descripcion;
            db.SaveChanges();


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