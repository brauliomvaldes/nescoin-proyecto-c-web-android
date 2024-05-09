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
    public class Tbl_LogController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Log
        public ActionResult Index()
        {
            var tbl_Log = db.Tbl_Log.Include(t => t.Tbl_tipo_log).Include(t => t.Tbl_Usuario);
            return View(tbl_Log.ToList());
        }

        // GET: Tbl_Log/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Log tbl_Log = db.Tbl_Log.Find(id);
            if (tbl_Log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Log);
        }

        // GET: Tbl_Log/Create
        public ActionResult Create()
        {
            ViewBag.id_tipo_log = new SelectList(db.Tbl_tipo_log, "id_tipo_log", "descripcion");
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre");
            return View();
        }

        // POST: Tbl_Log/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Log tbl_Log)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Log.Add(tbl_Log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tipo_log = new SelectList(db.Tbl_tipo_log, "id_tipo_log", "descripcion", tbl_Log.id_tipo_log);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Log.id_usuario);
            return View(tbl_Log);
        }

        // GET: Tbl_Log/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Log tbl_Log = db.Tbl_Log.Find(id);
            if (tbl_Log == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tipo_log = new SelectList(db.Tbl_tipo_log, "id_tipo_log", "descripcion", tbl_Log.id_tipo_log);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Log.id_usuario);
            return View(tbl_Log);
        }

        // POST: Tbl_Log/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Log tbl_Log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tipo_log = new SelectList(db.Tbl_tipo_log, "id_tipo_log", "descripcion", tbl_Log.id_tipo_log);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_Log.id_usuario);
            return View(tbl_Log);
        }

        // GET: Tbl_Log/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Log tbl_Log = db.Tbl_Log.Find(id);
            if (tbl_Log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Log);
        }

        // POST: Tbl_Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Log tbl_Log = db.Tbl_Log.Find(id);
            //db.Tbl_Log.Remove(tbl_Log);

            tbl_Log.estado = false;
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
