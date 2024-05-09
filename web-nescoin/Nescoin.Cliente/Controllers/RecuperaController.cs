using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Nescoin.Conexion.Models;
using System.Security.Policy;

namespace Nescoin.Cliente.Controllers
{
    public class RecuperaController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Recupera
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cambio()
        {
            return View();
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


        [HttpPost]
        public ActionResult RecuperaClave(string usuario, string correo)
        {
            if (usuario != null && correo != null)
            {
                Tbl_Usuario usu = db.Tbl_Usuario
                    .Where(x => x.nick == usuario)
                    .FirstOrDefault();
                if (usu != null)
                {
                    decimal id_usu = usu.id_usuario;

                    Tbl_Usuario_Correo suscorreos = db.Tbl_Usuario_Correo
                    .Where(x => x.estado == true && x.id_usuario == id_usu).FirstOrDefault();

                    if (suscorreos != null)
                    {
                        decimal idcorreo = suscorreos.id_correo;

                        Tbl_Correo correodelusuario = db.Tbl_Correo
                        .Where(x => x.estado == true && x.id_correo == idcorreo && x.descripcion == correo).FirstOrDefault();

                        if (correodelusuario != null)
                        {
                            try
                            {
                                //genera numero aleatorio que reemplaza su clave actual olvidada
                                Random rand = new Random();

                                int randNum = rand.Next(100000,1000000);
                                string clavetemporal = randNum.ToString();

                                //variable que contendra el mensaje de correo

                                MailMessage correoalusuario = new MailMessage();
                                string sCuentaCorreo = "nescoin.recuperacion@gmail.com";
                                correoalusuario.From = new MailAddress(sCuentaCorreo);
                                correoalusuario.To.Add(correo);
                                correoalusuario.Subject="Recuperación de contraseña acceso a Nescoin";
                                correoalusuario.Body="Estimado, debe volver a definir contraseña, ingrese con clave:"+clavetemporal;
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

                                string hash = GenerarHash(clavetemporal);

                                // reemplaza antigua contraseña

                                usu.contraseña = hash;
                                db.SaveChanges();

                                // fin registro
                                ViewBag.ErrorRecupera = "false";
                                ViewBag.mensaje = "¡Proceso Exitoso! Se ha enviado un mensaje a su correo registrado";
                                return View("Index");
                            }
                            catch (Exception ex)
                            {
                                ViewBag.ErrorRecupera = "true";
                                ViewBag.mensaje = "¡Error! al enviar correo, correo no existe"+ex;
                                return View("Index");
                            }
                        }
                        else
                        {
                            ViewBag.ErrorRecupera = "true";
                            ViewBag.mensaje = "¡Error! correo no pertenece al usuario";
                            return View("Index");
                        }
                    }
                    else
                    {
                        ViewBag.ErrorRecupera = "true";
                        ViewBag.mensaje = "¡Error! usuario y correo no corresponden";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.ErrorRecupera = "true";
                    ViewBag.mensaje = "¡Error! usuario no existe";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.mensaje = "No pueden haber campos en blanco";
                return View("Index");
            }
        }


        [HttpPost]
        public JsonResult apiRecuperaClave(string correo)
        {
            if (correo != null)
            {
                Tbl_Usuario usu = db.Tbl_Usuario
                    .Where(x => x.nick == correo)
                    .FirstOrDefault();
                if (usu != null)
                {
                    decimal id_usu = usu.id_usuario;

                    Tbl_Usuario_Correo suscorreos = db.Tbl_Usuario_Correo
                    .Where(x => x.estado == true && x.id_usuario == id_usu).FirstOrDefault();

                    if (suscorreos != null)
                    {
                        decimal idcorreo = suscorreos.id_correo;

                        Tbl_Correo correodelusuario = db.Tbl_Correo
                        .Where(x => x.estado == true && x.id_correo == idcorreo && x.descripcion == correo).FirstOrDefault();

                        if (correodelusuario != null)
                        {
                            try
                            {
                                //genera numero aleatorio que reemplaza su clave actual olvidada
                                Random rand = new Random();

                                int randNum = rand.Next(100000, 1000000);
                                string clavetemporal = randNum.ToString();

                                //variable que contendra el mensaje de correo

                                MailMessage correoalusuario = new MailMessage();
                                string sCuentaCorreo = "nescoin.recuperacion@gmail.com";
                                correoalusuario.From = new MailAddress(sCuentaCorreo);
                                correoalusuario.To.Add(correo);
                                correoalusuario.Subject = "Recuperación de contraseña acceso a Nescoin";
                                correoalusuario.Body = "Estimado, debe volver a definir contraseña, ingrese con clave:" + clavetemporal;
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

                                string hash = GenerarHash(clavetemporal);

                                // reemplaza antigua contraseña

                                usu.contraseña = hash;
                                db.SaveChanges();

                                // fin registro

                                return Json(new { mensaje = "¡Proceso Exitoso! Se ha enviado un mensaje a su correo registrado" }, JsonRequestBehavior.AllowGet);
                                }
                            catch (Exception ex)
                            {

                                return Json(new { mensaje = "¡Error! al enviar correo, correo no existe" + ex }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { mensaje = "¡Error! correo no pertenece al usuario" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { mensaje = "¡Error! usuario y correo no corresponden" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { mensaje = "¡Error! usuario no existe" }, JsonRequestBehavior.AllowGet);
                   
                }
            }
            else
            {

                return Json(new { mensaje = "No pueden haber campos en blanco" }, JsonRequestBehavior.AllowGet);
            }
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