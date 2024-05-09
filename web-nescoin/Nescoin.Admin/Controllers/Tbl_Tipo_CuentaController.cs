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
    public class Tbl_Tipo_CuentaController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Tipo_Cuenta
        public ActionResult Index()
        {
            return View(db.Tbl_Tipo_Cuenta.ToList());
        }

        // GET: Tbl_Tipo_Cuenta/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Tipo_Cuenta tbl_Tipo_Cuenta = db.Tbl_Tipo_Cuenta.Find(id);
            if (tbl_Tipo_Cuenta == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tipo_Cuenta);
        }

        // GET: Tbl_Tipo_Cuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Tipo_Cuenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Tipo_Cuenta tbl_Tipo_Cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Tipo_Cuenta.Add(tbl_Tipo_Cuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Tipo_Cuenta);
        }

        // GET: Tbl_Tipo_Cuenta/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Tipo_Cuenta tbl_Tipo_Cuenta = db.Tbl_Tipo_Cuenta.Find(id);
            if (tbl_Tipo_Cuenta == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tipo_Cuenta);
        }

        // POST: Tbl_Tipo_Cuenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Tipo_Cuenta tbl_Tipo_Cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Tipo_Cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Tipo_Cuenta);
        }

        // GET: Tbl_Tipo_Cuenta/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Tipo_Cuenta tbl_Tipo_Cuenta = db.Tbl_Tipo_Cuenta.Find(id);
            if (tbl_Tipo_Cuenta == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tipo_Cuenta);
        }

        // POST: Tbl_Tipo_Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Tipo_Cuenta tbl_Tipo_Cuenta = db.Tbl_Tipo_Cuenta.Find(id);
            //db.Tbl_Tipo_Cuenta.Remove(tbl_Tipo_Cuenta);

            tbl_Tipo_Cuenta.estado = false;
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
