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
    public class Tbl_ComunaController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Comuna
        public ActionResult Index()
        {
            var tbl_Comuna = db.Tbl_Comuna.Include(t => t.Tbl_Ciudad);
            return View(tbl_Comuna.ToList());
        }

        // GET: Tbl_Comuna/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Comuna tbl_Comuna = db.Tbl_Comuna.Find(id);
            if (tbl_Comuna == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Comuna);
        }

        // GET: Tbl_Comuna/Create
        public ActionResult Create()
        {
            ViewBag.id_ciudad = new SelectList(db.Tbl_Ciudad, "id_ciudad", "descripcion");
            return View();
        }

        // POST: Tbl_Comuna/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Comuna tbl_Comuna)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Comuna.Add(tbl_Comuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ciudad = new SelectList(db.Tbl_Ciudad, "id_ciudad", "descripcion", tbl_Comuna.id_ciudad);
            return View(tbl_Comuna);
        }

        // GET: Tbl_Comuna/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Comuna tbl_Comuna = db.Tbl_Comuna.Find(id);
            if (tbl_Comuna == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ciudad = new SelectList(db.Tbl_Ciudad, "id_ciudad", "descripcion", tbl_Comuna.id_ciudad);
            return View(tbl_Comuna);
        }

        // POST: Tbl_Comuna/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Comuna tbl_Comuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Comuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ciudad = new SelectList(db.Tbl_Ciudad, "id_ciudad", "descripcion", tbl_Comuna.id_ciudad);
            return View(tbl_Comuna);
        }

        // GET: Tbl_Comuna/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Comuna tbl_Comuna = db.Tbl_Comuna.Find(id);
            if (tbl_Comuna == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Comuna);
        }

        // POST: Tbl_Comuna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Comuna tbl_Comuna = db.Tbl_Comuna.Find(id);
            //db.Tbl_Comuna.Remove(tbl_Comuna);

            tbl_Comuna.estado = false;            
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
