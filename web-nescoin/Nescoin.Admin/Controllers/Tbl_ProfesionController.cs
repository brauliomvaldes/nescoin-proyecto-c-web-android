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
    public class Tbl_ProfesionController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Profesion
        public ActionResult Index()
        {
            return View(db.Tbl_Profesion.ToList());
        }

        // GET: Tbl_Profesion/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Profesion tbl_Profesion = db.Tbl_Profesion.Find(id);
            if (tbl_Profesion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Profesion);
        }

        // GET: Tbl_Profesion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Profesion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Profesion tbl_Profesion)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Profesion.Add(tbl_Profesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Profesion);
        }

        // GET: Tbl_Profesion/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Profesion tbl_Profesion = db.Tbl_Profesion.Find(id);
            if (tbl_Profesion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Profesion);
        }

        // POST: Tbl_Profesion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Profesion tbl_Profesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Profesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Profesion);
        }

        // GET: Tbl_Profesion/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Profesion tbl_Profesion = db.Tbl_Profesion.Find(id);
            if (tbl_Profesion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Profesion);
        }

        // POST: Tbl_Profesion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Profesion tbl_Profesion = db.Tbl_Profesion.Find(id);
            //db.Tbl_Profesion.Remove(tbl_Profesion);

            tbl_Profesion.estado = false;
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
