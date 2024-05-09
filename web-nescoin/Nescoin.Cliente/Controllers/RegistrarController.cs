using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class RegistrarController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Registrar
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return PartialView();
        }

        public ActionResult RegistarNuevoProyecto(string frm1_titulo_proyecto, string frm1_descripcion)
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            string _titulo_proyecto = frm1_titulo_proyecto;
            string _descripcion = frm1_descripcion;
            int _ultimo_id_movimiento = 0;
            var _id_usuario_logueado = Session["idusuario"].ToString();
            DateTime _fecha = DateTime.Now;


            //Rescata el ultimo movimiento            
            Tbl_movimiento mv = db.Tbl_movimiento.OrderByDescending(x => x.id_movimiento).FirstOrDefault();
            if (mv == null)
            {
                _ultimo_id_movimiento = 1 ;
            }
            else
            {
                _ultimo_id_movimiento = Decimal.ToInt32(mv.id_movimiento) + 1;
            }
            

            //////////////////////////////////////////////////////
            Tbl_movimiento unMovimiento = new Tbl_movimiento();
            unMovimiento.id_movimiento = _ultimo_id_movimiento;
            unMovimiento.id_tipo_movimiento = 1; //Numero 1: indica nuevo proyecto
            unMovimiento.fecha_movimiento = _fecha;
            unMovimiento.descripcion = frm1_descripcion;
            unMovimiento.id_usuario = Convert.ToDecimal(_id_usuario_logueado);
            unMovimiento.id_calificacion = 5; //por defecto
            unMovimiento.comentario = frm1_titulo_proyecto;
            unMovimiento.id_forma_pago = 1;
            unMovimiento.estado = true;

            db.Tbl_movimiento.Add(unMovimiento);
            db.SaveChanges();

            return Redirect("~/Home");
        }

    }
}