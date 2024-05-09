using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nescoin.Conexion.Models;

namespace Nescoin.Admin.Controllers
{
    public class Tbl_Usuario_CorreoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Usuario_Correo
        public ActionResult Index()
        {
            var tbl_Usuario_Correo = db.Tbl_Usuario_Correo.Include(t => t.Tbl_Correo).Include(t => t.Tbl_Usuario);
            return View(tbl_Usuario_Correo.ToList());
        }

        // GET: Tbl_Usuario_Correo/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Correo tbl_Usuario_Correo = db.Tbl_Usuario_Correo.Find(id);
            if (tbl_Usuario_Correo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario_Correo);
        }

        // GET: Tbl_Usuario_Correo/Create
        public ActionResult Create()
        {
            ViewBag.id_correo = new SelectList(db.Tbl_Correo, "id_correo", "descripcion");
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Tbl_Usuario_Correo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Usuario_Correo tbl_Usuario_Correo)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Usuario_Correo.Add(tbl_Usuario_Correo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_correo = new SelectList(db.Tbl_Correo, "id_correo", "descripcion", tbl_Usuario_Correo.id_correo);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Correo.id_usuario);
            return View(tbl_Usuario_Correo);
        }

        // GET: Tbl_Usuario_Correo/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Correo tbl_Usuario_Correo = db.Tbl_Usuario_Correo.Find(id);
            if (tbl_Usuario_Correo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_correo = new SelectList(db.Tbl_Correo, "id_correo", "descripcion", tbl_Usuario_Correo.id_correo);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Correo.id_usuario);
            return View(tbl_Usuario_Correo);
        }

        // POST: Tbl_Usuario_Correo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Usuario_Correo tbl_Usuario_Correo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Usuario_Correo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_correo = new SelectList(db.Tbl_Correo, "id_correo", "descripcion", tbl_Usuario_Correo.id_correo);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Correo.id_usuario);
            return View(tbl_Usuario_Correo);
        }

        // GET: Tbl_Usuario_Correo/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Correo tbl_Usuario_Correo = db.Tbl_Usuario_Correo.Find(id);
            if (tbl_Usuario_Correo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario_Correo);
        }

        // POST: Tbl_Usuario_Correo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Usuario_Correo tbl_Usuario_Correo = db.Tbl_Usuario_Correo.Find(id);
            //db.Tbl_Usuario_Correo.Remove(tbl_Usuario_Correo);

            tbl_Usuario_Correo.estado = false;
            db.SaveChanges();
            return RedirectToAction("Index");
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
