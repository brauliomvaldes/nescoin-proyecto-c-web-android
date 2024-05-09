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
    public class Tbl_Forma_PagoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Forma_Pago
        public ActionResult Index()
        {
            return View(db.Tbl_Forma_Pago.ToList());
        }

        // GET: Tbl_Forma_Pago/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Forma_Pago tbl_Forma_Pago = db.Tbl_Forma_Pago.Find(id);
            if (tbl_Forma_Pago == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Forma_Pago);
        }

        // GET: Tbl_Forma_Pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Forma_Pago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Forma_Pago tbl_Forma_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Forma_Pago.Add(tbl_Forma_Pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Forma_Pago);
        }

        // GET: Tbl_Forma_Pago/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Forma_Pago tbl_Forma_Pago = db.Tbl_Forma_Pago.Find(id);
            if (tbl_Forma_Pago == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Forma_Pago);
        }

        // POST: Tbl_Forma_Pago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Forma_Pago tbl_Forma_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Forma_Pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Forma_Pago);
        }

        // GET: Tbl_Forma_Pago/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Forma_Pago tbl_Forma_Pago = db.Tbl_Forma_Pago.Find(id);
            if (tbl_Forma_Pago == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Forma_Pago);
        }

        // POST: Tbl_Forma_Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Forma_Pago tbl_Forma_Pago = db.Tbl_Forma_Pago.Find(id);
            //db.Tbl_Forma_Pago.Remove(tbl_Forma_Pago);

            tbl_Forma_Pago.estado = false;
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
