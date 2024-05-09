using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Nescoin.Conexion.Models;

namespace Nescoin.Cliente.Controllers
{
    public class LoginController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            return View();
        }
        

        [HttpPost]
        public ActionResult VerificaIngreso(string nombre, string contraseña)
        {
            if (contraseña != null)
            {
                string hash = GenerarHash(contraseña);
                Tbl_Usuario usu = db.Tbl_Usuario
                    .Where(x => x.nick == nombre && x.contraseña == hash)
                    .FirstOrDefault();
                if (usu != null)
                {
                    Tbl_Usuario usuarios = new Tbl_Usuario();
                    usuarios.id_usuario = usu.id_usuario;
                    usuarios.contraseña = usu.contraseña;
                    usuarios.nombre = usu.nombre;
                    usuarios.apellido = usu.apellido;
                    usuarios.id_direccion = usu.id_direccion;
                    usuarios.id_tipo_cuenta = usu.id_tipo_cuenta;
                    Session["Usuario"] = usuarios;
                    ViewBag.usuario = usuarios.contraseña;
                    Session["Profesiones"] = db.Tbl_Profesion.ToList();
                    Session["idusuario"]= usuarios.id_usuario;
                    Session["contactoSeleccionado"] = usuarios.id_usuario;
                    Session["NombreUsuario"] = usuarios.nombre + " " + usuarios.apellido;
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ViewBag.mensaje = "¡Error! usuario o clave Incorrectos";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.mensaje = "Error debe ingresar una clave";
                return View("Index");

            }

                //return RedirectToAction("Index");
        }

        //SI ENTRA LA CONTRASEÑA "abc123"
        public string GenerarHash(string clave)
        {
            byte[] byteClave = Encoding.UTF8.GetBytes(clave);  //se genera un arreglo de tipo UTF (con 6 elemento, con la clave que ingreso el usuario)
            MD5 md5 = MD5.Create();                            //Crea un objeto MD5
            byte[] hashArray = md5.ComputeHash(byteClave);     //Crea otro arreglo apartir del anterior (ahora con 16 elementos)
            StringBuilder sbuilder = new StringBuilder();      //este es un objeto String (cadena de texto), se le pueden agregar mas textos...
            for (int i = 0; i < hashArray.Length; i++)         //Se recorre el arreglo llamado "hashArray" con sus 16 elementos
            {
                sbuilder.Append(hashArray[i].ToString("x2"));  //Al string llamado "sbuilder" se le va agregando cada elemento con dos caracteres de tipo hexadecimal
                                                               //le puedo agregar mas si deseo, como x3 (tres caracteres), x4 (cuatro caracteres), etc.
            }
            return sbuilder.ToString();                         //retorna el string completo
        }

        /*********Api para buscar usuario *************/
        //[HttpPost]
        public JsonResult datosUsuario(string nick, string contraseña)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            if(contraseña !=null && contraseña != "")
            {
                string hash = GenerarHash(contraseña);
                Tbl_Usuario usu = db.Tbl_Usuario.First(x => x.nick == nick && x.contraseña == hash);
                return Json(new {id_usuario = usu.id_usuario, nombre = usu.nombre, apellido = usu.apellido }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { mensaje = "Falta nick o contraseña " }, JsonRequestBehavior.AllowGet);


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