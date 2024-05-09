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
    public class Tbl_DireccionController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Direccion
        public ActionResult Index()
        {
            var tbl_Direccion = db.Tbl_Direccion.Include(t => t.Tbl_Comuna);
            return View(tbl_Direccion.ToList());
        }

        // GET: Tbl_Direccion/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Direccion tbl_Direccion = db.Tbl_Direccion.Find(id);
            if (tbl_Direccion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Direccion);
        }

        // GET: Tbl_Direccion/Create
        public ActionResult Create()
        {
            ViewBag.id_comuna = new SelectList(db.Tbl_Comuna, "id_comuna", "descripcion");
            return View();
        }

        // POST: Tbl_Direccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Direccion tbl_Direccion)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Direccion.Add(tbl_Direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_comuna = new SelectList(db.Tbl_Comuna, "id_comuna", "descripcion", tbl_Direccion.id_comuna);
            return View(tbl_Direccion);
        }

        // GET: Tbl_Direccion/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Direccion tbl_Direccion = db.Tbl_Direccion.Find(id);
            if (tbl_Direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_comuna = new SelectList(db.Tbl_Comuna, "id_comuna", "descripcion", tbl_Direccion.id_comuna);
            return View(tbl_Direccion);
        }

        // POST: Tbl_Direccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Direccion tbl_Direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_comuna = new SelectList(db.Tbl_Comuna, "id_comuna", "descripcion", tbl_Direccion.id_comuna);
            return View(tbl_Direccion);
        }

        // GET: Tbl_Direccion/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Direccion tbl_Direccion = db.Tbl_Direccion.Find(id);
            if (tbl_Direccion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Direccion);
        }

        // POST: Tbl_Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Direccion tbl_Direccion = db.Tbl_Direccion.Find(id);
            //db.Tbl_Direccion.Remove(tbl_Direccion);

            tbl_Direccion.estado = false;
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
