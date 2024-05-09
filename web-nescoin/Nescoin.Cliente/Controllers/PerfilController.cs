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
    public class PerfilController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();
        // GET: Perfil
        public ActionResult Index()
        {
          
            // Si no existe la variable de sesion se direcciona a la pagina de error.
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            Tbl_Usuario usuario = (Tbl_Usuario)Session["Usuario"];
            ViewBag.DatoUsuario = usuario;
            
            // *************Pasamos los datos de la dirección del usuario a la vista************************************/
            // Dirección del usuario //

            Tbl_Direccion ObjetoDireccion = db.Tbl_Direccion.Where(x => x.id_direccion == usuario.id_direccion).FirstOrDefault();
            if (ObjetoDireccion != null)
            {
                ViewBag.direccion = ObjetoDireccion.descripcion.ToString();
            }
            //Comuna del usuario
            Tbl_Comuna objetoComuna = db.Tbl_Comuna.Where(x => x.id_comuna == ObjetoDireccion.id_comuna).FirstOrDefault();
            var id_comuna = objetoComuna.id_comuna;
            //Ciudad del usuario
            Tbl_Ciudad objetoCiudad = db.Tbl_Ciudad.Where(x => x.id_ciudad == objetoComuna.id_ciudad).FirstOrDefault();
            var id_ciudad = objetoCiudad.id_ciudad;
            ViewBag.CiudadSelecionada = id_ciudad;
            //País usuario
            Tbl_Pais objetoPais = db.Tbl_Pais.Where(x => x.id_pais == objetoCiudad.id_pais).FirstOrDefault();
            var id_pais = objetoPais.id_pais;
            /**********************************************************************/
            /*************Buscamos correos del usuario*******************/
            //Buscamos el primer correo del usuario
            Tbl_Usuario_Correo listaCorreosUsuario = db.Tbl_Usuario_Correo.Where(x => x.id_usuario == usuario.id_usuario).FirstOrDefault();
            //buscamos la la  dirección email del correo del usuario
            if (listaCorreosUsuario != null)
            {
                Tbl_Correo correo = db.Tbl_Correo.Where(x => x.id_correo == listaCorreosUsuario.id_correo).FirstOrDefault();

                ViewBag.correo = correo.descripcion;
            }

            /**********************************************************/
            /*************Buscamo descripción de profesión del usuario*******************/
            Tbl_Usuario_Profesion usuarioProfesion = db.Tbl_Usuario_Profesion.Where(x => x.id_usuario == usuario.id_usuario).FirstOrDefault();
            ViewBag.descripcionProfesion = usuarioProfesion.descripcion;
            ViewBag.IdProfesion  = usuarioProfesion.id_profesion;
            ViewBag.Calificacion = usuarioProfesion.promedio_calificacion;
            /**********************************************************/
            /*************Buscamo tipo de cuentadel usuario*******************/
            Tbl_Usuario usuarioBd = db.Tbl_Usuario.Where(x => x.id_usuario == usuario.id_usuario).FirstOrDefault();
            Tbl_Tipo_Cuenta tipoCuenta = db.Tbl_Tipo_Cuenta.Where(x => x.id_tipo_cuenta== usuarioBd.id_tipo_cuenta).FirstOrDefault();
            ViewBag.IdTipoCuenta = tipoCuenta.id_tipo_cuenta;

            /**********************************************************/


            ViewBag.ListaPaises = new SelectList(ObtenerListaPais(), "id_pais", "descripcion", id_pais);

            ViewBag.ListaCiudades = new SelectList(ObtenerListaCiudad(Convert.ToInt32(id_pais)), "id_ciudad", "descripcion", id_ciudad);

            ViewBag.ListaComunas = new SelectList(ObtenerListaComuna(Convert.ToInt32(id_ciudad)), "id_comuna", "descripcion", id_comuna);

            //Obtenemos la lista de profesiones disponibles
            List<Tbl_Profesion> profesiones = db.Tbl_Profesion.ToList();
            ViewBag.ListaProfesion = profesiones;

            
            //Obtenemos los tipos de cuentas de usuarios
            List<Tbl_Tipo_Cuenta> tipos_Cuentas = db.Tbl_Tipo_Cuenta.ToList();
            ViewBag.ListaTipoCuentas = tipos_Cuentas;


            return PartialView("RegistroPerfil");

        }

        //Método que registra el usuario
        public ActionResult ActualizarUsuario(string email, int id_profesion, string nombre, string apellido, string direccion, int id_tipo_cuenta, string id_comuna, string actividad)
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            Tbl_Usuario usuarioLogeado = (Tbl_Usuario)Session["Usuario"];
            //string _nick = email.Substring(0, email.IndexOf('@'));
            Tbl_Usuario usuario = db.Tbl_Usuario.Where(x => x.id_usuario == usuarioLogeado.id_usuario).FirstOrDefault();

            if (usuario != null)
            {

                DateTime _fecha = DateTime.Now;

                ///////////////////////////////////////////////////
                //Setea y graba los datos para la nueva direccion

                Tbl_Direccion dir = db.Tbl_Direccion.Where(x => x.id_direccion == usuario.id_direccion).FirstOrDefault();

                dir.descripcion = direccion;
                dir.numero = "";
                dir.id_comuna = int.Parse(id_comuna);
                db.SaveChanges();

                ////////////////////////////////////////////
                ////////////////////////////////////////////
                ///GRABA LOS DATOS DEL USUARIO//////////////
                usuario.nick = email;
                usuario.nombre = nombre;
                usuario.apellido = apellido;
                usuario.id_tipo_cuenta = id_tipo_cuenta;
                //usuario.foto = "user-1.PNG";
                db.SaveChanges();

                ////////////////////////////////////////////
                ////////////////////////////////////////////
                ////GRABA LOS DATOS DE CORREO /////////////

                Tbl_Usuario_Correo correosUsuario = db.Tbl_Usuario_Correo.Where(x => x.id_usuario == usuario.id_usuario).FirstOrDefault();
                Tbl_Correo emailUsuario = db.Tbl_Correo.Where(x => x.id_correo == correosUsuario.id_correo).FirstOrDefault();

                emailUsuario.descripcion = email;
                db.SaveChanges();

                //////////////////////////////////////////
                /////////////////////////////////////////
                /////////////////////////////////////////

                ////GRABA LOS DATOS DE PROFESION////////
                ///

                Tbl_Usuario_Profesion usuarioProfesion = db.Tbl_Usuario_Profesion.Where(x => x.id_usuario == usuario.id_usuario).FirstOrDefault();
                db.Tbl_Usuario_Profesion.Remove(usuarioProfesion);
                db.SaveChanges();
                usuarioProfesion.id_usuario = usuario.id_usuario;
                usuarioProfesion.id_profesion = id_profesion;
                db.Tbl_Usuario_Profesion.Add(usuarioProfesion);
                db.SaveChanges();

                /////////////////////////////////////////
                /////////////////////////////////////////
                ///




                ViewBag.ListaPaises = new SelectList(ObtenerListaPais(), "id_pais", "descripcion");
                ViewBag.ListaProfesion = db.Tbl_Profesion.ToList();
                ViewBag.ListaTipoCuentas = db.Tbl_Tipo_Cuenta.ToList();
                ViewBag.mensaje = "USUARIO CREADO CORRECTAMENTE";
            }
            else
            {
                ViewBag.ListaPaises = new SelectList(ObtenerListaPais(), "id_pais", "descripcion");
                ViewBag.ListaProfesion = db.Tbl_Profesion.ToList();
                ViewBag.ListaTipoCuentas = db.Tbl_Tipo_Cuenta.ToList();
                ViewBag.mensaje = "USUARIO YA EXISTE, NO PUEDE CREAR. ";
            }
            return Redirect("~/Home/Index");
        }


        //Obtiene las profesiones dispoinbles
        public List<Tbl_Profesion> ObtieneProfesiones()
        {
            List<Tbl_Profesion> profesiones = db.Tbl_Profesion.ToList();
            return profesiones;
        }

        //Obtengo y retorno la lita de paises
        public List<Tbl_Pais> ObtenerListaPais()
        {
            List<Tbl_Pais> paises = db.Tbl_Pais.ToList();
            return paises;
        }

        //Obtiene la lista de las ciudades filtrado por el id del pais
        public List<Tbl_Ciudad> ObtenerListaCiudad(int id_pais)
        {
            //if (Session["Usuario"] == null)
            //{
            //    return View("~/Views/Shared/Error.cshtml");
            //}
            ///*Datos del usuario*/
            //Tbl_Usuario usuario = (Tbl_Usuario)Session["Usuario"];
            ///*Obtenemos id de la dirección del usuario*/
            //Tbl_Direccion direccion = db.Tbl_Direccion.Where(x => x.id_direccion == usuario.id_direccion).FirstOrDefault();
            ///*Obtenemos la id de la comuna del usuario*/
            //Tbl_Comuna comuna = db.Tbl_Comuna.Where(x => x.id_comuna == direccion.id_comuna).FirstOrDefault();
            ///*Obtenemos la id de la ciudad del usuario*/
            //Tbl_Ciudad ciudad = db.Tbl_Ciudad.Where(x => x.id_ciudad == comuna.id_ciudad).FirstOrDefault();
            
            /*Se muestran todas las ciudades de acuerdo al id del pais*/
            List<Tbl_Ciudad> ciudades = db.Tbl_Ciudad.Where(x => x.id_pais == id_pais).ToList();
            //ViewBag.IdCiudad = ciudad.id_ciudad.ToString();
            //ViewBag.ListaCiudades = new SelectList(ciudades, "id_ciudad", "descripcion", ciudad.id_ciudad);
            return ciudades;
        }

        //Obtiene la lista de las comunas filtrado por el id de ciudad
        public List<Tbl_Comuna> ObtenerListaComuna(int id_ciudad)
        {
            //if (Session["Usuario"] == null)
            //{
            //    return View("~/Views/Shared/Error.cshtml");
            //}
            //Tbl_Usuario usuario = (Tbl_Usuario)Session["Usuario"];
            //Tbl_Direccion direccion = db.Tbl_Direccion.Where(x => x.id_direccion == usuario.id_direccion).FirstOrDefault();
            //Tbl_Comuna comuna = db.Tbl_Comuna.Where(x => x.id_comuna == direccion.id_comuna).FirstOrDefault();
            List<Tbl_Comuna> comunas = db.Tbl_Comuna.Where(x => x.id_ciudad == id_ciudad).ToList();
            //ViewBag.ListaComunas = new SelectList(comunas, "id_comuna", "descripcion", comuna.id_comuna);
            return comunas;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //Genera el hash para la contraseña criptografica.
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