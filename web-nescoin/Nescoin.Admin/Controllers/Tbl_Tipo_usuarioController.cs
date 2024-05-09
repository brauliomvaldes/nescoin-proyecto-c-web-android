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
    public class Tbl_Tipo_usuarioController : Controller
    {
        private BD_NESCOINEntities db = new BD_NESCOINEntities();

        // GET: Tbl_Tipo_usuario
        public ActionResult Index()
        {
            return View(db.Tbl_Tipo_usuario.ToList());
        }

        // GET: Tbl_Tipo_usuario/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Tipo_usuario tbl_Tipo_usuario = db.Tbl_Tipo_usuario.Find(id);
            if (tbl_Tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tipo_usuario);
        }

        // GET: Tbl_Tipo_usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Tipo_usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Tbl_Tipo_usuario tbl_Tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Tipo_usuario.Add(tbl_Tipo_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Tipo_usuario);
        }

        // GET: Tbl_Tipo_usuario/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Tipo_usuario tbl_Tipo_usuario = db.Tbl_Tipo_usuario.Find(id);
            if (tbl_Tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tipo_usuario);
        }

        // POST: Tbl_Tipo_usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Tbl_Tipo_usuario tbl_Tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Tipo_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Tipo_usuario);
        }

        // GET: Tbl_Tipo_usuario/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Tipo_usuario tbl_Tipo_usuario = db.Tbl_Tipo_usuario.Find(id);
            if (tbl_Tipo_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tipo_usuario);
        }

        // POST: Tbl_Tipo_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Tbl_Tipo_usuario tbl_Tipo_usuario = db.Tbl_Tipo_usuario.Find(id);
            //db.Tbl_Tipo_usuario.Remove(tbl_Tipo_usuario);

            tbl_Tipo_usuario.estado = false;
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
