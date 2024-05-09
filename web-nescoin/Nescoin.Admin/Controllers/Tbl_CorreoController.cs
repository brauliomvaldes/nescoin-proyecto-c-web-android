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
    public class Tbl_CorreoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Correo
        public ActionResult Index()
        {
            return View(db.Tbl_Correo.ToList());
        }

        // GET: Tbl_Correo/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Correo tbl_Correo = db.Tbl_Correo.Find(id);
            if (tbl_Correo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Correo);
        }

        // GET: Tbl_Correo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Correo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Correo tbl_Correo)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Correo.Add(tbl_Correo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Correo);
        }

        // GET: Tbl_Correo/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Correo tbl_Correo = db.Tbl_Correo.Find(id);
            if (tbl_Correo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Correo);
        }

        // POST: Tbl_Correo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Correo tbl_Correo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Correo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Correo);
        }

        // GET: Tbl_Correo/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Correo tbl_Correo = db.Tbl_Correo.Find(id);
            if (tbl_Correo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Correo);
        }

        // POST: Tbl_Correo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Correo tbl_Correo = db.Tbl_Correo.Find(id);
            //db.Tbl_Correo.Remove(tbl_Correo);

            tbl_Correo.estado = false;
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
