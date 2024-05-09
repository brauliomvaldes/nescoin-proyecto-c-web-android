using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Nescoin.Conexion.Models;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Security.Policy;

namespace Nescoin.Cliente.Controllers
{
                
    public class RegistroContactoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();
        // GET: RegistroContacto
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return PartialView();
        }

        //ESTE METODO GUARDA LOS DATOS DEL NUEVO CONTACTO
        public ActionResult guardaDatos(string nombre, string apellido, string correo, string id_profesion, string actividad, int campotel, string califica_frm11)
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            /*
             * 
             ACA VAN TODAS LAS LINEAS DE CODIGO PARA GUARDAR EL NUEVO CONTACTO
             * * */
            if (nombre != "" && apellido != "" && correo != "" && id_profesion != "" && actividad != "")
            {
                //string _nick = correo.Substring(0, correo.IndexOf('@'));
                Tbl_Usuario usu = db.Tbl_Usuario.Where(x => x.nick == correo).FirstOrDefault();
                int _ultimo_id_direccion = 0;
                int _ultimo_id_usuario = 0;
                int _ultimo_id_correo = 0;
                int _ultimo_id_telefono = 0;

                if (usu == null)
                {

                    //List<Tbl_Usuario> uLogeado = new List<Tbl_Usuario>();

                    if (Session["usuario"] != null)
                    {
                        string hash = chequeaCorreo(correo);
                        if (hash != "")
                        {
                            try
                            {
                                Tbl_Usuario uLogeado = (Tbl_Usuario)Session["Usuario"];

                                //Tbl_Usuario usuLogeado = uLogeado.Where(x => x.id_usuario != 0).FirstOrDefault();

                                int _id_usuario_logeado = Decimal.ToInt32(uLogeado.id_usuario);

                                DateTime _fecha = DateTime.Now;

                                Tbl_Direccion unaDireccion = new Tbl_Direccion();
                                Tbl_Direccion dir = db.Tbl_Direccion.OrderByDescending(x => x.id_direccion).FirstOrDefault();
                                _ultimo_id_direccion = Decimal.ToInt32(dir.id_direccion) + 1;

                                ///////////////////////////////////////////////////
                                //Setea y graba los datos para la nueva direccion
                                unaDireccion.id_direccion = _ultimo_id_direccion;
                                unaDireccion.descripcion = "sin direccion";
                                unaDireccion.numero = "0";
                                unaDireccion.id_comuna = 1;
                                unaDireccion.estado = true;
                                db.Tbl_Direccion.Add(unaDireccion);
                                db.SaveChanges();

                                //////////////////////////////////
                                ///

                                Tbl_Telefono unTelefono = new Tbl_Telefono();
                                Tbl_Telefono tel = db.Tbl_Telefono.OrderByDescending(x => x.id_telefono).FirstOrDefault();
                                _ultimo_id_telefono = Decimal.ToInt32(tel.id_telefono) + 1;

                                ///////////////////////////////////////////////////
                                //Setea y graba los datos para nuevo telefono
                                unTelefono.id_telefono = _ultimo_id_telefono;
                                unTelefono.numero_telefono = campotel;
                                unTelefono.estado = true;
                                db.Tbl_Telefono.Add(unTelefono);
                                db.SaveChanges();

                                ////////////////////////////////////////////
                                ////////////////////////////////////////////
                                ///GRABA LOS DATOS DEL USUARIO//////////////

                                usu = db.Tbl_Usuario.OrderByDescending(x => x.id_usuario).FirstOrDefault();
                                _ultimo_id_usuario = Decimal.ToInt32(usu.id_usuario) + 1;

                                Tbl_Usuario unUsuario = new Tbl_Usuario();
                                unUsuario.id_usuario = _ultimo_id_usuario;
                                unUsuario.nick = correo;
                                unUsuario.nombre = nombre;
                                unUsuario.apellido = apellido;
                                unUsuario.fecha_creacion = _fecha;
                                unUsuario.fecha_actualizacion = _fecha;
                                unUsuario.contraseña = hash;
                                unUsuario.id_direccion = _ultimo_id_direccion;
                                unUsuario.id_tipo_cuenta = 1;
                                unUsuario.foto = "user-1.PNG";
                                unUsuario.estado = true;
                                db.Tbl_Usuario.Add(unUsuario);
                                db.SaveChanges();

                                ////////////////////////////////////////////
                                ////////////////////////////////////////////
                                ////GRABA LOS DATOS DE CORREO /////////////

                                Tbl_Correo corr = db.Tbl_Correo.OrderByDescending(x => x.id_correo).FirstOrDefault();
                                _ultimo_id_correo = Decimal.ToInt32(corr.id_correo) + 1;

                                Tbl_Correo UnCorreo = new Tbl_Correo();
                                UnCorreo.id_correo = _ultimo_id_correo;
                                UnCorreo.descripcion = correo;
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
                                unaProfesion.promedio_calificacion = int.Parse(califica_frm11);
                                unaProfesion.estado = true;
                                db.Tbl_Usuario_Profesion.Add(unaProfesion);
                                db.SaveChanges();

                                /////////////////////////////////////////
                                ////// GRABA EL TELEFONO DEL USUARIO
                                /////////////////////////////////////////
                                Tbl_Usuario_Telefono unUsuarioTelefono = new Tbl_Usuario_Telefono();
                                unUsuarioTelefono.id_usuario = _ultimo_id_usuario;
                                unUsuarioTelefono.id_telefono = _ultimo_id_telefono;
                                unUsuarioTelefono.estado = true;
                                db.Tbl_Usuario_Telefono.Add(unUsuarioTelefono);
                                db.SaveChanges();
                             
                                /////////////////////////////////////////
                                /// NUEVO CONTACTO CREADO CORRECTAMENTE
                                /////////////////////////////////////////
                                ///
                                Tbl_Contacto unContacto = new Tbl_Contacto();
                                unContacto.id_contacto = _ultimo_id_usuario;
                                unContacto.id_usuario = _id_usuario_logeado;
                                //
                                // SE REGISTRA COMO CONTACTO SIN CUENTA
                                unContacto.id_tipo_usuario = 2;
                                // SE REGISTRA CON MAXIMA CALIFICACION
                                unContacto.id_calificacion = int.Parse(califica_frm11);
                                unContacto.estado = true;
                                db.Tbl_Contacto.Add(unContacto);
                                db.SaveChanges();
                            }catch (Exception ex)
                            {
                                ViewBag.mensaje = "Error, los contactos ya pertenece a la la red de contactos del usaurio seleccionado"+ex;
                            }

                            ////////////////////////////////////////////////////////////
                            /// NUEVO CONTACTO DEL USUARIO LOGEADO CREADO CORRECTAMENTE
                            ///////////////////////////////////////////////////////////
                            

                        Session["flagNuevoContacto"] = "1";
                        ViewBag.mensaje = "USUARIO CONTACTO CREADO CORRECTAMENTE";
                        }
                    }
                    else
                    {
                        ViewBag.mensaje = "ERROR, NO SE ENCUENTRA LOGEADO ???";
                    }
                }

                else
                {
                    Session["flagNuevoContacto"] = "2";
                    ViewBag.mensaje = "USUARIO YA EXISTE, NO SE PUEDE CREAR. ";
                }

                ViewBag.mensaje = "Se ha guardado el nuevo contacto a su lista";
            }
            else
            {
                ViewBag.mensaje = "Error! Debe completar todos los datos";

            }
            return Redirect("~/Home");
        }
   
        public String chequeaCorreo(string correo)
        {
            string hash = "";
            try
            {
                //genera numero aleatorio que reemplaza su clave actual olvidada
                Random rand = new Random();
                string _sunick = correo.Substring(0, correo.IndexOf('@'));
                int randNum = rand.Next(100000, 1000000);
                string clavetemporal = randNum.ToString();

                //variable que contendra el mensaje de correo

                MailMessage correoalusuario = new MailMessage();
                string sCuentaCorreo = "nescoin.recuperacion@gmail.com";
                correoalusuario.From = new MailAddress(sCuentaCorreo);
                correoalusuario.To.Add(correo);
                correoalusuario.Subject = "Registro en red Nescoin";
                correoalusuario.Body = "Estimado, Usted ha sido referido en la App Nescoin (www.nescoin.cl), su usuario es:"+_sunick+" y su clave :" + clavetemporal;
                correoalusuario.IsBodyHtml = true;
                correoalusuario.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;

                string sPasswordCorreo = "clave_nescoin2020";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correoalusuario);

                // registra nueva clave generarda de forma aleatoria en el usuario
                // generar hash de contraseña temporal

                hash = GenerarHash(clavetemporal);

                // reemplaza antigua contraseña

                ViewBag.mensaje = "¡Proceso Exitoso! Se ha enviado un mensaje a su correo registrado";

            }
            catch (Exception ex)
            {
                ViewBag.mensaje = "¡Error! al enviar correo, correo no existe" + ex;

            }

            return (hash);
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

        /*********Api para registrar contacto de usuario *************/
        /*********Api para registrar contacto de usuario *************/
        /*********Api para registrar contacto de usuario *************/

        [HttpPost]
        public JsonResult guardaContactoApp(string idusuarioapp, string nombre, string apellido, string actividad,
            string correo, string telefono, string califica_frm11 = "5", string id_profesion = "1")
        {
            /*
             * 
             ACA VAN TODAS LAS LINEAS DE CODIGO PARA GUARDAR EL NUEVO CONTACTO
             * * */
            string mensaje = "";
            if (nombre != "" && apellido != "" && actividad != "" && correo != "")
            {
                Tbl_Usuario usu = db.Tbl_Usuario.Where(x => x.nick == correo).FirstOrDefault();
                int _ultimo_id_direccion = 0;
                int _ultimo_id_usuario = 0;
                int _ultimo_id_correo = 0;
                int _ultimo_id_telefono = 0;

                if (usu == null)
                {
                    string hash = chequeaCorreo(correo);
                    if (hash != "")
                    {
                        try
                        {
                            // utiliza Id usuario App para registrar su nuevo contacto
                            //
                            int _id_usuario_logueado = Int32.Parse(idusuarioapp);

                            if (_id_usuario_logueado == 0)
                            {
                                mensaje = "error en ID usuario logueado";
                                return Json(mensaje, JsonRequestBehavior.AllowGet);
                            }

                            DateTime _fecha = DateTime.Now;

                            Tbl_Direccion unaDireccion = new Tbl_Direccion();
                            Tbl_Direccion dir = db.Tbl_Direccion.OrderByDescending(x => x.id_direccion).FirstOrDefault();
                            _ultimo_id_direccion = Decimal.ToInt32(dir.id_direccion) + 1;

                            ///////////////////////////////////////////////////
                            //Setea y graba los datos para la nueva direccion
                            unaDireccion.id_direccion = _ultimo_id_direccion;
                            unaDireccion.descripcion = "sin direccion";
                            unaDireccion.numero = "0";
                            unaDireccion.id_comuna = 1;
                            unaDireccion.estado = true;
                            db.Tbl_Direccion.Add(unaDireccion);
                            db.SaveChanges();

                            //////////////////////////////////
                            ///

                            Tbl_Telefono unTelefono = new Tbl_Telefono();
                            Tbl_Telefono tel = db.Tbl_Telefono.OrderByDescending(x => x.id_telefono).FirstOrDefault();
                            _ultimo_id_telefono = Decimal.ToInt32(tel.id_telefono) + 1;

                            ///////////////////////////////////////////////////
                            //Setea y graba los datos para nuevo telefono
                            unTelefono.id_telefono = _ultimo_id_telefono;
                            unTelefono.numero_telefono = int.Parse(telefono);
                            unTelefono.estado = true;
                            db.Tbl_Telefono.Add(unTelefono);
                            db.SaveChanges();

                            ////////////////////////////////////////////
                            ////////////////////////////////////////////
                            ///GRABA LOS DATOS DEL contacto del USUARIO//////////////

                            usu = db.Tbl_Usuario.OrderByDescending(x => x.id_usuario).FirstOrDefault();
                            _ultimo_id_usuario = Decimal.ToInt32(usu.id_usuario) + 1;

                            Tbl_Usuario unUsuario = new Tbl_Usuario();
                            unUsuario.id_usuario = _ultimo_id_usuario;
                            unUsuario.nick = correo;
                            unUsuario.nombre = nombre;
                            unUsuario.apellido = apellido;
                            unUsuario.fecha_creacion = _fecha;
                            unUsuario.fecha_actualizacion = _fecha;
                            unUsuario.contraseña = hash;
                            unUsuario.id_direccion = _ultimo_id_direccion;
                            unUsuario.id_tipo_cuenta = 1;
                            unUsuario.foto = "user-1.PNG";
                            unUsuario.estado = true;
                            db.Tbl_Usuario.Add(unUsuario);
                            db.SaveChanges();

                            ////////////////////////////////////////////
                            ////////////////////////////////////////////
                            ////GRABA LOS DATOS DE CORREO /////////////

                            Tbl_Correo corr = db.Tbl_Correo.OrderByDescending(x => x.id_correo).FirstOrDefault();
                            _ultimo_id_correo = Decimal.ToInt32(corr.id_correo) + 1;

                            Tbl_Correo UnCorreo = new Tbl_Correo();
                            UnCorreo.id_correo = _ultimo_id_correo;
                            UnCorreo.descripcion = correo;
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
                            unaProfesion.promedio_calificacion = int.Parse(califica_frm11);
                            unaProfesion.estado = true;
                            db.Tbl_Usuario_Profesion.Add(unaProfesion);
                            db.SaveChanges();

                            /////////////////////////////////////////
                            ////// GRABA EL TELEFONO DEL USUARIO
                            /////////////////////////////////////////
                            Tbl_Usuario_Telefono unUsuarioTelefono = new Tbl_Usuario_Telefono();
                            unUsuarioTelefono.id_usuario = _ultimo_id_usuario;
                            unUsuarioTelefono.id_telefono = _ultimo_id_telefono;
                            unUsuarioTelefono.estado = true;
                            db.Tbl_Usuario_Telefono.Add(unUsuarioTelefono);
                            db.SaveChanges();

                            /////////////////////////////////////////
                            /// NUEVO CONTACTO CREADO CORRECTAMENTE
                            /////////////////////////////////////////
                            ///
                            Tbl_Contacto unContacto = new Tbl_Contacto();
                            unContacto.id_contacto = _ultimo_id_usuario;
                            unContacto.id_usuario = _id_usuario_logueado;
                            //
                            // SE REGISTRA COMO CONTACTO SIN CUENTA
                            unContacto.id_tipo_usuario = 2;
                            // SE REGISTRA CON MAXIMA CALIFICACION
                            unContacto.id_calificacion = int.Parse(califica_frm11);
                            unContacto.estado = true;
                            db.Tbl_Contacto.Add(unContacto);
                            db.SaveChanges();
                            mensaje = "Exitoso, se ha agregado " + nombre + " " + apellido + " a su Lista de Contactos";
                            ////////////////////////////////////////////////////////////
                            /// NUEVO CONTACTO DEL USUARIO LOGEADO CREADO CORRECTAMENTE
                            ///////////////////////////////////////////////////////////
                        }
                        catch (Exception ex)
                        {
                            ViewBag.mensaje = "Error, los contactos ya pertenece a la la red de contactos del usaurio seleccionado" + ex;
                        }
                    }
                }
                else
                {
                    mensaje = "USUARIO YA EXISTE, NO SE PUEDE CREAR. ";
                }
            }
            else
            {
                mensaje = "Error! Debe completar todos los datos";

            }
            return Json(new { resultado = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }

}
