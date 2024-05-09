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
    public class Tbl_CiudadController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Ciudad
        public ActionResult Index()
        {
            var tbl_Ciudad = db.Tbl_Ciudad.Include(t => t.Tbl_Pais);
            return View(tbl_Ciudad.ToList());
        }

        // GET: Tbl_Ciudad/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Ciudad tbl_Ciudad = db.Tbl_Ciudad.Find(id);
            if (tbl_Ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ciudad);
        }

        // GET: Tbl_Ciudad/Create
        public ActionResult Create()
        {
            ViewBag.id_pais = new SelectList(db.Tbl_Pais, "id_pais", "descripcion");
            return View();
        }

        // POST: Tbl_Ciudad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Ciudad tbl_Ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Ciudad.Add(tbl_Ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pais = new SelectList(db.Tbl_Pais, "id_pais", "descripcion", tbl_Ciudad.id_pais);
            return View(tbl_Ciudad);
        }

        // GET: Tbl_Ciudad/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Ciudad tbl_Ciudad = db.Tbl_Ciudad.Find(id);
            if (tbl_Ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pais = new SelectList(db.Tbl_Pais, "id_pais", "descripcion", tbl_Ciudad.id_pais);
            return View(tbl_Ciudad);
        }

        // POST: Tbl_Ciudad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Ciudad tbl_Ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.Tbl_Pais, "id_pais", "descripcion", tbl_Ciudad.id_pais);
            return View(tbl_Ciudad);
        }

        // GET: Tbl_Ciudad/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Ciudad tbl_Ciudad = db.Tbl_Ciudad.Find(id);
            if (tbl_Ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Ciudad);
        }

        // POST: Tbl_Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Ciudad tbl_Ciudad = db.Tbl_Ciudad.Find(id);
            //db.Tbl_Ciudad.Remove(tbl_Ciudad);
            tbl_Ciudad.estado = false;
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
