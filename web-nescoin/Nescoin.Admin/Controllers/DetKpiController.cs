using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nescoin.Admin.Controllers
{
    public class DetKpiController : Controller
    {
        // GET: DetKpi
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}