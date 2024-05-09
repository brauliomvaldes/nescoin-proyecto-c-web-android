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
    public class Tbl_ContactoController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Contacto
        public ActionResult Index()
        {
            var tbl_Contacto = db.Tbl_Contacto.Include(t => t.Tbl_Calificacion).Include(t => t.Tbl_Tipo_usuario).Include(t => t.Tbl_Usuario);
            return View(tbl_Contacto.ToList());
        }

        // GET: Tbl_Contacto/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Contacto tbl_Contacto = db.Tbl_Contacto.Find(id);
            if (tbl_Contacto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Contacto);
        }

        // GET: Tbl_Contacto/Create
        public ActionResult Create()
        {
            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "nombre");
            ViewBag.id_tipo_usuario = new SelectList(db.Tbl_Tipo_usuario, "id_tipo_usuario", "descripcion");
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nick");
            return View();
        }

        // POST: Tbl_Contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Contacto tbl_Contacto)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Contacto.Add(tbl_Contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "nombre", tbl_Contacto.id_calificacion);
            ViewBag.id_tipo_usuario = new SelectList(db.Tbl_Tipo_usuario, "id_tipo_usuario", "descripcion", tbl_Contacto.id_tipo_usuario);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nick", tbl_Contacto.id_usuario);
            return View(tbl_Contacto);
        }

        // GET: Tbl_Contacto/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Contacto tbl_Contacto = db.Tbl_Contacto.Find(id);
            if (tbl_Contacto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "nombre", tbl_Contacto.id_calificacion);
            ViewBag.id_tipo_usuario = new SelectList(db.Tbl_Tipo_usuario, "id_tipo_usuario", "descripcion", tbl_Contacto.id_tipo_usuario);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nick", tbl_Contacto.id_usuario);
            return View(tbl_Contacto);
        }

        // POST: Tbl_Contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Contacto tbl_Contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_calificacion = new SelectList(db.Tbl_Calificacion, "id_calificacion", "nombre", tbl_Contacto.id_calificacion);
            ViewBag.id_tipo_usuario = new SelectList(db.Tbl_Tipo_usuario, "id_tipo_usuario", "descripcion", tbl_Contacto.id_tipo_usuario);
            ViewBag.id_usuario = new SelectList(db.Tbl_Usuario, "id_usuario", "nick", tbl_Contacto.id_usuario);
            return View(tbl_Contacto);
        }

        // GET: Tbl_Contacto/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Contacto tbl_Contacto = db.Tbl_Contacto.Find(id);
            if (tbl_Contacto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Contacto);
        }

        // POST: Tbl_Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Contacto tbl_Contacto = db.Tbl_Contacto.Find(id);
            //db.Tbl_Contacto.Remove(tbl_Contacto);
            tbl_Contacto.estado = false;
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
