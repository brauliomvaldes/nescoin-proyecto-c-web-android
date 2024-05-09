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
    public class Tbl_TelefonoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Telefono
        public ActionResult Index()
        {
            return View(db.Tbl_Telefono.ToList());
        }

        // GET: Tbl_Telefono/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Telefono tbl_Telefono = db.Tbl_Telefono.Find(id);
            if (tbl_Telefono == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Telefono);
        }

        // GET: Tbl_Telefono/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Telefono/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Telefono tbl_Telefono)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Telefono.Add(tbl_Telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Telefono);
        }

        // GET: Tbl_Telefono/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Telefono tbl_Telefono = db.Tbl_Telefono.Find(id);
            if (tbl_Telefono == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Telefono);
        }

        // POST: Tbl_Telefono/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Telefono tbl_Telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Telefono);
        }

        // GET: Tbl_Telefono/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Telefono tbl_Telefono = db.Tbl_Telefono.Find(id);
            if (tbl_Telefono == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Telefono);
        }

        // POST: Tbl_Telefono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Telefono tbl_Telefono = db.Tbl_Telefono.Find(id);
            //db.Tbl_Telefono.Remove(tbl_Telefono);

            tbl_Telefono.estado = false;
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
