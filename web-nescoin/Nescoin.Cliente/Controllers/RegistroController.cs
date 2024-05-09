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
    public class RegistroController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();
        // GET: Registro
        public ActionResult Index()
        {
            ViewBag.ListaPaises = new SelectList(ObtenerListaPais(), "id_pais", "descripcion");
            ViewBag.ListaProfesion = db.Tbl_Profesion.ToList();
            ViewBag.ListaTipoCuentas = db.Tbl_Tipo_Cuenta.ToList();
            return View("Index");
        }


        //Método que registra el usuario
        public ActionResult RegistraUsuario(string email, string id_profesion, string nombre, string apellido, string direccion, int id_tipo_cuenta, string id_pais, string id_ciudad, string id_comuna, string password_1, string password_2, string actividad, int telefono)
        {
            Tbl_Usuario usu = db.Tbl_Usuario.Where(x => x.nick == email).FirstOrDefault();
            int _ultimo_id_direccion = 0;
            int _ultimo_id_usuario = 0;
            int _ultimo_id_correo = 0;
            int _ultimo_id_telefono = 0;

            if (usu == null)
            {
                DateTime _fecha = DateTime.Now;
                Tbl_Direccion unaDireccion = new Tbl_Direccion();

                Tbl_Direccion dir = db.Tbl_Direccion.OrderByDescending(x => x.id_direccion).FirstOrDefault();
                if (dir == null)
                {
                    _ultimo_id_direccion = 1;
                }
                else
                {
                    _ultimo_id_direccion = Decimal.ToInt32(dir.id_direccion) + 1;
                }
                

                ///////////////////////////////////////////////////
                //Setea y graba los datos para la nueva direccion
                unaDireccion.id_direccion = _ultimo_id_direccion;
                unaDireccion.descripcion = direccion;
                unaDireccion.numero = "0"; 
                unaDireccion.id_comuna = Int32.Parse(id_comuna);
                unaDireccion.estado = true;
                db.Tbl_Direccion.Add(unaDireccion);
                db.SaveChanges();

                ////////////////////////////////////////////
                ////////////////////////////////////////////
                ///GRABA LOS DATOS DEL USUARIO//////////////
                
                string hash = GenerarHash(password_1);
                usu = db.Tbl_Usuario.OrderByDescending(x => x.id_usuario).FirstOrDefault();
                if (usu == null)
                {
                    _ultimo_id_usuario = 1;
                }
                else
                {
                    _ultimo_id_usuario = Decimal.ToInt32(usu.id_usuario) + 1;
                }

                Tbl_Usuario unUsuario = new Tbl_Usuario();
                unUsuario.id_usuario = _ultimo_id_usuario;
                unUsuario.nick = email;//_nick;
                unUsuario.nombre = nombre;
                unUsuario.apellido = apellido;
                unUsuario.fecha_creacion = _fecha;
                unUsuario.fecha_actualizacion = _fecha;
                unUsuario.contraseña = hash;
                unUsuario.id_direccion = _ultimo_id_direccion;
                unUsuario.id_tipo_cuenta = id_tipo_cuenta;
                unUsuario.foto = "user-1.PNG";
                unUsuario.estado = true;
                db.Tbl_Usuario.Add(unUsuario);
                db.SaveChanges();

                ////////////////////////////////////////////
                ////////////////////////////////////////////
                ////GRABA LOS DATOS DE CORREO /////////////
                
                Tbl_Correo corr = db.Tbl_Correo.OrderByDescending(x => x.id_correo).FirstOrDefault();
                if (corr == null)
                {
                    _ultimo_id_correo = 1;
                }
                else
                {
                    _ultimo_id_correo = Decimal.ToInt32(corr.id_correo) + 1;
                }
                

                Tbl_Correo UnCorreo = new Tbl_Correo();
                UnCorreo.id_correo = _ultimo_id_correo;
                UnCorreo.descripcion = email;
                UnCorreo.estado = true;
                db.Tbl_Correo.Add(UnCorreo);
                db.SaveChanges();

                Tbl_Usuario_Correo UnUsuarioCorreo = new Tbl_Usuario_Correo();
                UnUsuarioCorreo.id_usuario = _ultimo_id_usuario;
                UnUsuarioCorreo.id_correo = _ultimo_id_correo;
                UnUsuarioCorreo.principal = true; //Por defecto se crea correo por defecto
                UnUsuarioCorreo.estado = true;
                db.Tbl_Usuario_Correo.Add(UnUsuarioCorreo);
                db.SaveChanges();
                //////////////////////////////////////////
                /////////////////////////////////////////
                /////////////////////////////////////////
                
                ////GRABA LOS DATOS DE PROFESION////////
                Tbl_Usuario_Profesion unaProfesion = new Tbl_Usuario_Profesion();
                unaProfesion.id_usuario = _ultimo_id_usuario;
                unaProfesion.id_profesion = int.Parse(id_profesion);
                unaProfesion.descripcion = actividad;
                unaProfesion.promedio_calificacion = 5; //Por defecto comienza con la calificación mas alta
                unaProfesion.estado = true;
                db.Tbl_Usuario_Profesion.Add(unaProfesion);
                db.SaveChanges();

                /////////////////////////////////////////
                /////////////////////////////////////////
                ///GRABA EL TELEFONO/////////////////////

                Tbl_Telefono tel = db.Tbl_Telefono.OrderByDescending(x => x.id_telefono).FirstOrDefault();
                if (tel == null)
                {
                    _ultimo_id_telefono = 1;
                }
                else
                {
                    _ultimo_id_telefono = Decimal.ToInt32(tel.id_telefono) + 1;
                }

                Tbl_Telefono unTelefono = new Tbl_Telefono();
                unTelefono.id_telefono = _ultimo_id_telefono;
                unTelefono.numero_telefono = telefono;
                unTelefono.estado = true;
                db.Tbl_Telefono.Add(unTelefono);
                db.SaveChanges();

                Tbl_Usuario_Telefono unUsuarioTelefono = new Tbl_Usuario_Telefono();
                unUsuarioTelefono.id_usuario = _ultimo_id_usuario;
                unUsuarioTelefono.id_telefono = _ultimo_id_telefono;
                unUsuarioTelefono.estado = true;
                db.Tbl_Usuario_Telefono.Add(unUsuarioTelefono);
                db.SaveChanges();
                /////////////////////////////////////////
                /////////////////////////////////////////


                ViewBag.ListaPaises = new SelectList(ObtenerListaPais(), "id_pais", "descripcion");
                ViewBag.ListaProfesion = db.Tbl_Profesion.ToList();
                ViewBag.ListaTipoCuentas = db.Tbl_Tipo_Cuenta.ToList();
                ViewBag.mensaje = "USUARIO CREADO CORRECTAMENTE";
                Session["flagNuevoUsuario"] = "1";
            }
            else
            {
                ViewBag.ListaPaises = new SelectList(ObtenerListaPais(), "id_pais", "descripcion");
                ViewBag.ListaProfesion = db.Tbl_Profesion.ToList();
                ViewBag.ListaTipoCuentas = db.Tbl_Tipo_Cuenta.ToList();
                ViewBag.mensaje = "USUARIO YA EXISTE, NO PUEDE CREAR. ";
                Session["flagNuevoUsuario"] = "2";
            }
            return View("Index");
        }

               /*********Api para registrar usuario *************/
        [HttpPost]
        public JsonResult rUsuario1(string email, string nombre, string apellido, string password_1, string password_2, string id_profesion = "1", string direccion = "", string id_pais = "1", string id_ciudad = "13", string id_comuna = "1", string actividad = "completar en pagina web", int telefono = 0, int id_tipo_cuenta = 2)
        {

            if (nombre == null && apellido == null && email == null && password_1 == null)
            {
                return Json("Falta Datos de registro", JsonRequestBehavior.AllowGet);
            }

            //string _nick = email.Substring(0, email.IndexOf('@'));
            Tbl_Usuario usu = db.Tbl_Usuario.Where(x => x.nick == email).FirstOrDefault();
            int _ultimo_id_direccion = 0;
            int _ultimo_id_usuario = 0;
            int _ultimo_id_correo = 0;
            int _ultimo_id_telefono = 0;

            if (usu == null)
            {

                DateTime _fecha = DateTime.Now;
                Tbl_Direccion unaDireccion = new Tbl_Direccion();

                Tbl_Direccion dir = db.Tbl_Direccion.OrderByDescending(x => x.id_direccion).FirstOrDefault();
                if (dir == null)
                {
                    _ultimo_id_direccion = 1;
                }
                else
                {
                    _ultimo_id_direccion = Decimal.ToInt32(dir.id_direccion) + 1;
                }


                ///////////////////////////////////////////////////
                //Setea y graba los datos para la nueva direccion
                unaDireccion.id_direccion = _ultimo_id_direccion;
                unaDireccion.descripcion = direccion;
                unaDireccion.numero = "0";
                unaDireccion.id_comuna = Int32.Parse(id_comuna);
                unaDireccion.estado = true;
                db.Tbl_Direccion.Add(unaDireccion);
                db.SaveChanges();

                ////////////////////////////////////////////
                ////////////////////////////////////////////
                ///GRABA LOS DATOS DEL USUARIO//////////////

                //string hash = GenerarHash(password_1);
                usu = db.Tbl_Usuario.OrderByDescending(x => x.id_usuario).FirstOrDefault();
                if (usu == null)
                {
                    _ultimo_id_usuario = 1;
                }
                else
                {
                    _ultimo_id_usuario = Decimal.ToInt32(usu.id_usuario) + 1;
                }


                Tbl_Usuario unUsuario = new Tbl_Usuario();
                unUsuario.id_usuario = _ultimo_id_usuario;
                unUsuario.nick = email;//_nick;
                unUsuario.nombre = nombre;
                unUsuario.apellido = apellido;
                unUsuario.fecha_creacion = _fecha;
                unUsuario.fecha_actualizacion = _fecha;
                unUsuario.contraseña = password_1;//hash;
                unUsuario.id_direccion = _ultimo_id_direccion;
                unUsuario.id_tipo_cuenta = 2;//id_tipo_cuenta;
                unUsuario.foto = "user-1.PNG";
                unUsuario.estado = true;
                db.Tbl_Usuario.Add(unUsuario);
                db.SaveChanges();

                ////////////////////////////////////////////
                ////////////////////////////////////////////
                ////GRABA LOS DATOS DE CORREO /////////////

                Tbl_Correo corr = db.Tbl_Correo.OrderByDescending(x => x.id_correo).FirstOrDefault();
                if (corr == null)
                {
                    _ultimo_id_correo = 1;
                }
                else
                {
                    _ultimo_id_correo = Decimal.ToInt32(corr.id_correo) + 1;
                }


                Tbl_Correo UnCorreo = new Tbl_Correo();
                UnCorreo.id_correo = _ultimo_id_correo;
                UnCorreo.descripcion = email;
                UnCorreo.estado = true;
                db.Tbl_Correo.Add(UnCorreo);
                db.SaveChanges();

                Tbl_Usuario_Correo UnUsuarioCorreo = new Tbl_Usuario_Correo();
                UnUsuarioCorreo.id_usuario = _ultimo_id_usuario;
                UnUsuarioCorreo.id_correo = _ultimo_id_correo;
                UnUsuarioCorreo.principal = true; //Por defecto se crea correo por defecto
                UnUsuarioCorreo.estado = true;
                db.Tbl_Usuario_Correo.Add(UnUsuarioCorreo);
                db.SaveChanges();
                //////////////////////////////////////////
                /////////////////////////////////////////
                /////////////////////////////////////////

                ////GRABA LOS DATOS DE PROFESION////////
                Tbl_Usuario_Profesion unaProfesion = new Tbl_Usuario_Profesion();
                unaProfesion.id_usuario = _ultimo_id_usuario;
                unaProfesion.id_profesion = int.Parse(id_profesion);
                unaProfesion.descripcion = actividad;
                unaProfesion.promedio_calificacion = 5; //Por defecto comienza con la calificación mas alta
                unaProfesion.estado = true;
                db.Tbl_Usuario_Profesion.Add(unaProfesion);
                db.SaveChanges();

                /////////////////////////////////////////
                /////////////////////////////////////////
                ///GRABA EL TELEFONO/////////////////////

                Tbl_Telefono tel = db.Tbl_Telefono.OrderByDescending(x => x.id_telefono).FirstOrDefault();
                if (tel == null)
                {
                    _ultimo_id_telefono = 1;
                }
                else
                {
                    _ultimo_id_telefono = Decimal.ToInt32(tel.id_telefono) + 1;
                }

                Tbl_Telefono unTelefono = new Tbl_Telefono();
                unTelefono.id_telefono = _ultimo_id_telefono;
                unTelefono.numero_telefono = telefono;
                unTelefono.estado = true;
                db.Tbl_Telefono.Add(unTelefono);
                db.SaveChanges();

                Tbl_Usuario_Telefono unUsuarioTelefono = new Tbl_Usuario_Telefono();
                unUsuarioTelefono.id_usuario = _ultimo_id_usuario;
                unUsuarioTelefono.id_telefono = _ultimo_id_telefono;
                unUsuarioTelefono.estado = true;
                db.Tbl_Usuario_Telefono.Add(unUsuarioTelefono);
                db.SaveChanges();
                /////////////////////////////////////////
                /////////////////////////////////////////

            }
            else
            {

                return Json("Usuario ya existe", JsonRequestBehavior.AllowGet);
            }
            //Tbl_Usuario verificar = db.Tbl_Usuario.Where(x => x.nick == email).FirstOrDefault();
            //return Json(usu, JsonRequestBehavior.AllowGet);
            return Json(new { nombre = usu.nombre, apellido = usu.apellido, email = usu.nick }, JsonRequestBehavior.AllowGet);
        }


         public ActionResult PruebaDatos(string email, string id_profesion, string nombre, string apellido, string direccion, int id_tipo_cuenta, string id_pais, string id_ciudad, string id_comuna, string password_1, string password_2, string actividad, int telefono)
        {
            ViewBag.ListaPaises = new SelectList(ObtenerListaPais(), "id_pais", "descripcion");
            ViewBag.ListaProfesion = db.Tbl_Profesion.ToList();
            ViewBag.ListaTipoCuentas = db.Tbl_Tipo_Cuenta.ToList();
            ViewBag.mensaje = "USUARIO CREADO CORRECTAMENTE";
            return Redirect ("Index");
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
        public ActionResult ObtieneListaCiudad(int id_pais)
        {
            List<Tbl_Ciudad> ciudades = db.Tbl_Ciudad.Where(x => x.id_pais == id_pais).ToList();
            ViewBag.ListaCiudades = new SelectList(ciudades, "id_ciudad", "descripcion");
            return PartialView("MuestraCiudades");
        }

        //Obtiene la lista de las comunas filtrado por el id de ciudad
        public ActionResult ObtieneListaComuna(int id_ciudad)
        {
            List<Tbl_Comuna> comunas = db.Tbl_Comuna.Where(x => x.id_ciudad == id_ciudad).ToList();
            ViewBag.ListaComunas = new SelectList(comunas, "id_comuna", "descripcion");
            return PartialView("MuestraComunas");
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