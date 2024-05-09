using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
   
    public class ContactosController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();
        // GET: Contactos
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View();
        }

        /***********Api de Contacto de usuario ************/
        //[HttpPost]
        public JsonResult datosContactos(int id)
        {
            //db.Configuration.ProxyCreationEnabled = false;

            List<Vi_Trae_contactos_de_usuario> contacto = db.Vi_Trae_contactos_de_usuario.Where(x => x.id_usuario_logueado == id).ToList();

            return Json(contacto, JsonRequestBehavior.AllowGet);
        }


    }
}