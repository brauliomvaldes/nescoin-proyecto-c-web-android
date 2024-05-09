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
    public class Tbl_Usuario_TelefonoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Usuario_Telefono
        public ActionResult Index()
        {
            var tbl_Usuario_Telefono = db.Tbl_Usuario_Telefono.Include(t => t.Tbl_Telefono).Include(t => t.Tbl_Usuario);
            return View(tbl_Usuario_Telefono.ToList());
        }

        // GET: Tbl_Usuario_Telefono/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Telefono tbl_Usuario_Telefono = db.Tbl_Usuario_Telefono.Find(id);
            if (tbl_Usuario_Telefono == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario_Telefono);
        }

        // GET: Tbl_Usuario_Telefono/Create
        public ActionResult Create()
        {
            ViewBag.id_telefono = new SelectList(db.Tbl_Telefono, "id_telefono", "id_telefono");
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Tbl_Usuario_Telefono/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Usuario_Telefono tbl_Usuario_Telefono)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Usuario_Telefono.Add(tbl_Usuario_Telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_telefono = new SelectList(db.Tbl_Telefono, "id_telefono", "id_telefono", tbl_Usuario_Telefono.id_telefono);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Telefono.id_usuario);
            return View(tbl_Usuario_Telefono);
        }

        // GET: Tbl_Usuario_Telefono/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Telefono tbl_Usuario_Telefono = db.Tbl_Usuario_Telefono.Find(id);
            if (tbl_Usuario_Telefono == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_telefono = new SelectList(db.Tbl_Telefono, "id_telefono", "id_telefono", tbl_Usuario_Telefono.id_telefono);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Telefono.id_usuario);
            return View(tbl_Usuario_Telefono);
        }

        // POST: Tbl_Usuario_Telefono/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Usuario_Telefono tbl_Usuario_Telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Usuario_Telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_telefono = new SelectList(db.Tbl_Telefono, "id_telefono", "id_telefono", tbl_Usuario_Telefono.id_telefono);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Telefono.id_usuario);
            return View(tbl_Usuario_Telefono);
        }

        // GET: Tbl_Usuario_Telefono/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Telefono tbl_Usuario_Telefono = db.Tbl_Usuario_Telefono.Find(id);
            if (tbl_Usuario_Telefono == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario_Telefono);
        }

        // POST: Tbl_Usuario_Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Usuario_Telefono tbl_Usuario_Telefono = db.Tbl_Usuario_Telefono.Find(id);
            //db.Tbl_Usuario_Telefono.Remove(tbl_Usuario_Telefono);

            tbl_Usuario_Telefono.estado = false;
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
