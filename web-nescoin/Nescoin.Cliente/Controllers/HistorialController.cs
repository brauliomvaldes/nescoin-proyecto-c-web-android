using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Cliente.Controllers
{
    public class HistorialController : Controller
    {
        // GET: Historial
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            return View();
        }
    }
}