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
    public class Tbl_tipo_logController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_tipo_log
        public ActionResult Index()
        {
            return View(db.Tbl_tipo_log.ToList());
        }

        // GET: Tbl_tipo_log/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_tipo_log tbl_tipo_log = db.Tbl_tipo_log.Find(id);
            if (tbl_tipo_log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipo_log);
        }

        // GET: Tbl_tipo_log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_tipo_log/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_tipo_log tbl_tipo_log)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_tipo_log.Add(tbl_tipo_log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_tipo_log);
        }

        // GET: Tbl_tipo_log/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_tipo_log tbl_tipo_log = db.Tbl_tipo_log.Find(id);
            if (tbl_tipo_log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipo_log);
        }

        // POST: Tbl_tipo_log/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_tipo_log tbl_tipo_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_tipo_log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_tipo_log);
        }

        // GET: Tbl_tipo_log/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_tipo_log tbl_tipo_log = db.Tbl_tipo_log.Find(id);
            if (tbl_tipo_log == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tipo_log);
        }

        // POST: Tbl_tipo_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_tipo_log tbl_tipo_log = db.Tbl_tipo_log.Find(id);
            //db.Tbl_tipo_log.Remove(tbl_tipo_log);

            tbl_tipo_log.estado = false;
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
