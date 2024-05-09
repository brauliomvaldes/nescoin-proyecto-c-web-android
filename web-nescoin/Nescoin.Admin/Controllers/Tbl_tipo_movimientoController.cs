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
    public class Tbl_tipo_movimientoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_tipo_movimiento
        public ActionResult Index()
        {
            return View(db.Tbl_tipo_movimiento.ToList());
        }

        // GET: Tbl_tipo_movimiento/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_tipo_movimiento tbl_tipo_movimiento = db.Tbl_tipo_movimiento.Find(id);
            if (tbl_tipo_movimiento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipo_movimiento);
        }

        // GET: Tbl_tipo_movimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_tipo_movimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_tipo_movimiento tbl_tipo_movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_tipo_movimiento.Add(tbl_tipo_movimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_tipo_movimiento);
        }

        // GET: Tbl_tipo_movimiento/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_tipo_movimiento tbl_tipo_movimiento = db.Tbl_tipo_movimiento.Find(id);
            if (tbl_tipo_movimiento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipo_movimiento);
        }

        // POST: Tbl_tipo_movimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_tipo_movimiento tbl_tipo_movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_tipo_movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_tipo_movimiento);
        }

        // GET: Tbl_tipo_movimiento/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_tipo_movimiento tbl_tipo_movimiento = db.Tbl_tipo_movimiento.Find(id);
            if (tbl_tipo_movimiento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipo_movimiento);
        }

        // POST: Tbl_tipo_movimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_tipo_movimiento tbl_tipo_movimiento = db.Tbl_tipo_movimiento.Find(id);
            //db.Tbl_tipo_movimiento.Remove(tbl_tipo_movimiento);

            tbl_tipo_movimiento.estado = false;
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
