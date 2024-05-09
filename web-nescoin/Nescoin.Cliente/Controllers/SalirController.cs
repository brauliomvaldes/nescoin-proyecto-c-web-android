using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class SalirController : Controller
    {
        // GET: Salir
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            Session["Usuario"] = null;
            Session["idusuario"] = null;
            return Redirect("/Vitrina/Index");
        }
    }
}