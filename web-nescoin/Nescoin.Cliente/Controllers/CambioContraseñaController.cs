using Nescoin.Conexion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class CambioContraseñaController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: CambioContraseña
        public ActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CambiaClave(string claveactual, string nuevaclave, string repite)
        {
            // recupera id del usuario logeado
            decimal idusuariologeado = (decimal)Session["idusuario"];

            if (idusuariologeado > 0)
            {

                if (claveactual != "" && nuevaclave != "" && claveactual != nuevaclave && nuevaclave == repite)
                {

                    Tbl_Usuario usuario = db.Tbl_Usuario
                            .Where(x => x.estado == true && x.id_usuario == idusuariologeado).FirstOrDefault();

                    if (usuario != null)
                    {
                        string hash = GenerarHash(claveactual);
                        if (usuario.contraseña == hash)
                        {
                            hash = GenerarHash(nuevaclave);
                            usuario.contraseña = hash;

                            db.SaveChanges();

                            Session["flagCambioContraseña"] = "1";
                            ViewBag.mensaje = "¡Proceso Exitoso! clave modificada";
                            ViewBag.CambiaContraseña = "false";
                        }
                        else
                        {
                            Session["flagCambioContraseña"] = "2";
                            ViewBag.CambiaContraseña = "true";
                            ViewBag.mensaje = "¡Error! clave ingresada no corresponde al usuario";
                        }
                    }
                    else
                    {
                        ViewBag.CambiaContraseña = "true";
                        ViewBag.mensaje = "¡Error! usuario no hallado";
                    }
                }
                else
                {
                    ViewBag.CambiaContraseña = "true";
                    ViewBag.mensaje = "¡Error! campos vacios o problemas con las claves. Usuario:";
                }
            }
            else
            {
                ViewBag.mensaje = "¡Error! usuario no hallado";
            }
            return View("Index");
        }



        public string GenerarHash(string clave)
        {
            byte[] byteClave = Encoding.UTF8.GetBytes(clave);
            MD5 md5 = MD5.Create();
            byte[] hashArray = md5.ComputeHash(byteClave);
            StringBuilder sbuilder = new StringBuilder();
            for (int i = 0; i < hashArray.Length; i++)
            {
                sbuilder.Append(hashArray[i].ToString("x2"));
            }
            return sbuilder.ToString();
        }

    }
}