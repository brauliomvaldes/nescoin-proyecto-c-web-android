using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class RecalificarController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Recalificar
        public ActionResult Index(string id_usuario)
        {
            decimal usuario = decimal.Parse(id_usuario.ToString());
            List<Vi_Trae_Vitrina> tbl_usuario = db.Vi_Trae_Vitrina.Where(x => x.id_usuario == usuario).ToList();
            return PartialView(tbl_usuario);
        }

        [HttpPost]
        public ActionResult RecalificarContacto(string frm14_id_usuario, string frm14_califica)
        {

            decimal _usuario = decimal.Parse(frm14_id_usuario.ToString());
            decimal _calificacion = decimal.Parse(frm14_califica.ToString());

            List<Tbl_Contacto> listContact = db.Tbl_Contacto.Where(x => x.id_contacto == _usuario).ToList();

            var promedioActual = listContact.Sum(x => x.id_calificacion) + _calificacion;
            var cantidad = listContact.Count() + 1;

            //Esta instruccion de obliga a re-calificar cuando un usuario solo tiene un contacto            
            //if (cantidad == 1)
            //{
            //    cantidad = 2;
            //}

            //var PromedioFinal = Convert.ToInt64((promedioActual / cantidad));
            var PromedioFinal = Math.Round(Convert.ToDecimal(promedioActual / cantidad),2);
            Tbl_Usuario_Profesion usuprof = db.Tbl_Usuario_Profesion.Where(x => x.id_usuario == _usuario).FirstOrDefault();
            usuprof.promedio_calificacion = double.Parse(PromedioFinal.ToString());

            Tbl_Contacto unContacto = new Tbl_Contacto();

            foreach (Tbl_Contacto obj in listContact )
            {
                unContacto = obj;
                unContacto.id_calificacion = PromedioFinal;
               
            }
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