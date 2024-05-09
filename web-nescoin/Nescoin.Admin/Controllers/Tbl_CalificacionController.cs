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
    public class Tbl_CalificacionController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Calificacion
        public ActionResult Index()
        {
            return View(db.Tbl_Calificacion.ToList());
        }

        // GET: Tbl_Calificacion/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Calificacion tbl_Calificacion = db.Tbl_Calificacion.Find(id);
            if (tbl_Calificacion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Calificacion);
        }

        // GET: Tbl_Calificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Calificacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Calificacion tbl_Calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Calificacion.Add(tbl_Calificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Calificacion);
        }

        // GET: Tbl_Calificacion/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Calificacion tbl_Calificacion = db.Tbl_Calificacion.Find(id);
            if (tbl_Calificacion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Calificacion);
        }

        // POST: Tbl_Calificacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Calificacion tbl_Calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Calificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Calificacion);
        }

        // GET: Tbl_Calificacion/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Calificacion tbl_Calificacion = db.Tbl_Calificacion.Find(id);
            if (tbl_Calificacion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Calificacion);
        }

        // POST: Tbl_Calificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Calificacion tbl_Calificacion = db.Tbl_Calificacion.Find(id);
            //db.Tbl_Calificacion.Remove(tbl_Calificacion);
            tbl_Calificacion.estado = false;
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
