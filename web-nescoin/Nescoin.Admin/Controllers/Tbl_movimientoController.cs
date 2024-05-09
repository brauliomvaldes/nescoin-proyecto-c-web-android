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
    public class Tbl_movimientoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_movimiento
        public ActionResult Index()
        {
            var tbl_movimiento = db.Tbl_movimiento.Include(t => t.Tbl_Calificacion).Include(t => t.Tbl_Forma_Pago).Include(t => t.Tbl_Usuario).Include(t => t.Tbl_tipo_movimiento);
            return View(tbl_movimiento.ToList());
        }

        // GET: Tbl_movimiento/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_movimiento tbl_movimiento = db.Tbl_movimiento.Find(id);
            if (tbl_movimiento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_movimiento);
        }

        // GET: Tbl_movimiento/Create
        public ActionResult Create()
        {
            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "descripcion");
            ViewBag.id_forma_pago = new SelectList(db.Tbl_Forma_Pago, "id_forma_pago", "descripcion");
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre");
            ViewBag.id_tipo_movimiento = new SelectList(db.Tbl_tipo_movimiento, "id_tipo_movimiento", "nombre");
            return View();
        }

        // POST: Tbl_movimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_movimiento tbl_movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_movimiento.Add(tbl_movimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "descripcion", tbl_movimiento.id_calificacion);
            ViewBag.id_forma_pago = new SelectList(db.Tbl_Forma_Pago, "id_forma_pago", "descripcion", tbl_movimiento.id_forma_pago);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_movimiento.id_usuario);
            ViewBag.id_tipo_movimiento = new SelectList(db.Tbl_tipo_movimiento, "id_tipo_movimiento", "nombre", tbl_movimiento.id_tipo_movimiento);
            return View(tbl_movimiento);
        }

        // GET: Tbl_movimiento/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_movimiento tbl_movimiento = db.Tbl_movimiento.Find(id);
            if (tbl_movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "descripcion", tbl_movimiento.id_calificacion);
            ViewBag.id_forma_pago = new SelectList(db.Tbl_Forma_Pago, "id_forma_pago", "descripcion", tbl_movimiento.id_forma_pago);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_movimiento.id_usuario);
            ViewBag.id_tipo_movimiento = new SelectList(db.Tbl_tipo_movimiento, "id_tipo_movimiento", "nombre", tbl_movimiento.id_tipo_movimiento);
            return View(tbl_movimiento);
        }

        // POST: Tbl_movimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_movimiento tbl_movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "descripcion", tbl_movimiento.id_calificacion);
            ViewBag.id_forma_pago = new SelectList(db.Tbl_Forma_Pago, "id_forma_pago", "descripcion", tbl_movimiento.id_forma_pago);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nombre", tbl_movimiento.id_usuario);
            ViewBag.id_tipo_movimiento = new SelectList(db.Tbl_tipo_movimiento, "id_tipo_movimiento", "nombre", tbl_movimiento.id_tipo_movimiento);
            return View(tbl_movimiento);
        }

        // GET: Tbl_movimiento/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_movimiento tbl_movimiento = db.Tbl_movimiento.Find(id);
            if (tbl_movimiento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_movimiento);
        }

        // POST: Tbl_movimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_movimiento tbl_movimiento = db.Tbl_movimiento.Find(id);
            //db.Tbl_movimiento.Remove(tbl_movimiento);

            tbl_movimiento.estado = false;
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
