using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class OfertaController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: ListaContacto
        public ActionResult Index(string id_movimiento, string estadoBoton, string idUsuario)
        {
            var id_usuario = Session["idusuario"];

            switch (estadoBoton)
            {
                case "Editar":
                    ViewBag.btnEstado = "Editar";
                    ViewBag.Titulo = "Editar Proyecto";
                    ViewBag.habilitado = "false";
                    ViewBag.rutaFormulario = "/Oferta/EditarProyecto";
                    break;
                case "Solicitar":
                    ViewBag.btnEstado = "Solicitar";
                    ViewBag.Titulo = "Solicitar Proyecto";
                    ViewBag.habilitado = "true";
                    ViewBag.rutaFormulario = "/Oferta/SolicitarProyecto";
                    id_usuario = idUsuario;
                    break;
            }

            var _id_movimiento = Convert.ToDecimal(id_movimiento);
            decimal usuario = decimal.Parse(id_usuario.ToString());
            List<Vi_Trae_Oferta_Trabajo> listaOfertaTrabajo = db.Vi_Trae_Oferta_Trabajo.Where(x => x.id_usuario == usuario && x.id_movimiento == _id_movimiento).ToList();

            return PartialView(listaOfertaTrabajo);
        }

        /*
         Muestra las lista de oferta segun el usuario que entra por parametro
         flag = 1 usuario logueado
         flag = 2 usuario seleccionado
        */
        public ActionResult retornaListaOfertaTrabajo(string flag)
        {

            var id_usuario = Session["idusuario"];
            ViewBag.EstadoOcultaBoton = "true";

            switch (flag)
            {
                case "1":
                    ViewBag.BotonSolicitar = "Editar";
                    id_usuario = Session["idusuario"];
                    break;
                case "2":
                    ViewBag.BotonSolicitar = "Solicitar";
                    ViewBag.BtnHabilitado = "true";
                    id_usuario = Session["idUsuarioLogeado"];
                    decimal usr = decimal.Parse(id_usuario.ToString());
                    ViewBag.VerificaPresupuesto = db.Vi_Verifica_Presupuesto.Where(x => x.id_usuario == usr).ToList();
                    break;
            }

            decimal usuario = decimal.Parse(id_usuario.ToString());

            List<Vi_Trae_Oferta_Trabajo> listaOfertaTrabajo = db.Vi_Trae_Oferta_Trabajo.Where(x => x.id_usuario == usuario).ToList();
            return PartialView("~/Views/Oferta/Publicar.cshtml", listaOfertaTrabajo);
        }
                
        //[HttpPost,ValidateInput(false)]
        public ActionResult EditarProyecto(string frm5_descripcion, string frm5_id_movimiento)
        {

            var _id_movimiento = Convert.ToDecimal(frm5_id_movimiento);
            var id_usuario = Convert.ToDecimal(Session["idusuario"]);

            Tbl_movimiento mov = db.Tbl_movimiento.Where(x => x.id_usuario == id_usuario && x.id_movimiento == _id_movimiento).FirstOrDefault();

            mov.descripcion = frm5_descripcion;
            db.SaveChanges();

            return Redirect("~/Home");
        }

        
        public ActionResult SolicitarProyecto(string frm5_descripcion, string frm5_id_movimiento, string frm5_titulo)
        {
            decimal _ultimo_id_movimiento = 0;
            DateTime _fecha = DateTime.Now;
            var _id_usuario = Convert.ToDecimal(Session["idusuario"]);

            Tbl_movimiento mv = db.Tbl_movimiento.OrderByDescending(x => x.id_movimiento).FirstOrDefault();
            _ultimo_id_movimiento = Decimal.ToInt32(mv.id_movimiento) + 1;

            Tbl_movimiento mov = new Tbl_movimiento();

            mov.id_movimiento = _ultimo_id_movimiento;
            mov.id_tipo_movimiento = 2; //Solicitud de presupuesto (proyecto)
            mov.fecha_movimiento = _fecha;
            mov.descripcion = frm5_descripcion;
            mov.id_usuario = _id_usuario;
            mov.id_calificacion = 0;
            mov.comentario = frm5_titulo;
            mov.id_forma_pago = 1;
            mov.num_ref_movimiento = Convert.ToDecimal(frm5_id_movimiento);
            mov.estado = true;
            db.Tbl_movimiento.Add(mov);
            db.SaveChanges();

            return Redirect("~/Home");
        }

        /*********Api de Publicación del contacto ********/

        public JsonResult datosPublicacion(int id)
        {

            //db.Configuration.ProxyCreationEnabled = false;

            List<Vi_Trae_Oferta_Trabajo> oferta = db.Vi_Trae_Oferta_Trabajo.Where(x => x.id_usuario == id).ToList();

            return Json(oferta, JsonRequestBehavior.AllowGet);
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