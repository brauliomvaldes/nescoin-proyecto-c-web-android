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
    public class Tbl_Usuario_ProfesionController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Usuario_Profesion
        public ActionResult Index()
        {
            var tbl_Usuario_Profesion = db.Tbl_Usuario_Profesion.Include(t => t.Tbl_Profesion).Include(t => t.Tbl_Usuario);
            return View(tbl_Usuario_Profesion.ToList());
        }

        // GET: Tbl_Usuario_Profesion/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Profesion tbl_Usuario_Profesion = db.Tbl_Usuario_Profesion.Find(id);
            if (tbl_Usuario_Profesion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario_Profesion);
        }

        // GET: Tbl_Usuario_Profesion/Create
        public ActionResult Create()
        {
            ViewBag.id_profesion = new SelectList(db.Tbl_Profesion, "id_profesion", "descripcion");
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Tbl_Usuario_Profesion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Usuario_Profesion tbl_Usuario_Profesion)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Usuario_Profesion.Add(tbl_Usuario_Profesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_profesion = new SelectList(db.Tbl_Profesion, "id_profesion", "descripcion", tbl_Usuario_Profesion.id_profesion);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Profesion.id_usuario);
            return View(tbl_Usuario_Profesion);
        }

        // GET: Tbl_Usuario_Profesion/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Profesion tbl_Usuario_Profesion = db.Tbl_Usuario_Profesion.Find(id);
            if (tbl_Usuario_Profesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_profesion = new SelectList(db.Tbl_Profesion, "id_profesion", "descripcion", tbl_Usuario_Profesion.id_profesion);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Profesion.id_usuario);
            return View(tbl_Usuario_Profesion);
        }

        // POST: Tbl_Usuario_Profesion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Usuario_Profesion tbl_Usuario_Profesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Usuario_Profesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_profesion = new SelectList(db.Tbl_Profesion, "id_profesion", "descripcion", tbl_Usuario_Profesion.id_profesion);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Usuario_Profesion.id_usuario);
            return View(tbl_Usuario_Profesion);
        }

        // GET: Tbl_Usuario_Profesion/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario_Profesion tbl_Usuario_Profesion = db.Tbl_Usuario_Profesion.Find(id);
            if (tbl_Usuario_Profesion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario_Profesion);
        }

        // POST: Tbl_Usuario_Profesion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Usuario_Profesion tbl_Usuario_Profesion = db.Tbl_Usuario_Profesion.Find(id);
            //db.Tbl_Usuario_Profesion.Remove(tbl_Usuario_Profesion);

            tbl_Usuario_Profesion.estado = false;
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
