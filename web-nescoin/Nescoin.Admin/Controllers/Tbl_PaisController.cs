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
    public class Tbl_PaisController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Pais
        public ActionResult Index()
        {
            return View(db.Tbl_Pais.ToList());
        }

        // GET: Tbl_Pais/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Pais tbl_Pais = db.Tbl_Pais.Find(id);
            if (tbl_Pais == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Pais);
        }

        // GET: Tbl_Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Pais/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Pais tbl_Pais)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Pais.Add(tbl_Pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Pais);
        }

        // GET: Tbl_Pais/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Pais tbl_Pais = db.Tbl_Pais.Find(id);
            if (tbl_Pais == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Pais);
        }

        // POST: Tbl_Pais/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Pais tbl_Pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Pais);
        }

        // GET: Tbl_Pais/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Pais tbl_Pais = db.Tbl_Pais.Find(id);
            if (tbl_Pais == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Pais);
        }

        // POST: Tbl_Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Pais tbl_Pais = db.Tbl_Pais.Find(id);
            //db.Tbl_Pais.Remove(tbl_Pais);

            tbl_Pais.estado = false;
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
