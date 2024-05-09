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
    public class Tbl_UsuarioController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Usuario
        public ActionResult Index()
        {
            var tbl_Usuario = db.Tbl_Usuario.Include(t => t.Tbl_Direccion).Include(t => t.Tbl_Tipo_Cuenta);
            return View(tbl_Usuario.ToList());
        }

        // GET: Tbl_Usuario/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            if (tbl_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario);
        }

        // GET: Tbl_Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_direccion = new SelectList(db.Tbl_Direccion, "id_direccion", "descripcion");
            ViewBag.id_tipo_cuenta = new SelectList(db.Tbl_Tipo_Cuenta, "id_tipo_cuenta", "descripcion");
            return View();
        }

        // POST: Tbl_Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Usuario tbl_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Usuario.Add(tbl_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_direccion = new SelectList(db.Tbl_Direccion, "id_direccion", "descripcion", tbl_Usuario.id_direccion);
            ViewBag.id_tipo_cuenta = new SelectList(db.Tbl_Tipo_Cuenta, "id_tipo_cuenta", "descripcion", tbl_Usuario.id_tipo_cuenta);
            return View(tbl_Usuario);
        }

        // GET: Tbl_Usuario/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            if (tbl_Usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_direccion = new SelectList(db.Tbl_Direccion, "id_direccion", "descripcion", tbl_Usuario.id_direccion);
            ViewBag.id_tipo_cuenta = new SelectList(db.Tbl_Tipo_Cuenta, "id_tipo_cuenta", "descripcion", tbl_Usuario.id_tipo_cuenta);
            return View(tbl_Usuario);
        }

        // POST: Tbl_Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Usuario tbl_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_direccion = new SelectList(db.Tbl_Direccion, "id_direccion", "descripcion", tbl_Usuario.id_direccion);
            ViewBag.id_tipo_cuenta = new SelectList(db.Tbl_Tipo_Cuenta, "id_tipo_cuenta", "descripcion", tbl_Usuario.id_tipo_cuenta);
            return View(tbl_Usuario);
        }

        // GET: Tbl_Usuario/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            if (tbl_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario);
        }

        // POST: Tbl_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            //db.Tbl_Usuario.Remove(tbl_Usuario);

            tbl_Usuario.estado = false;
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
