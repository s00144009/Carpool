using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carpool.Controllers
{
    public class DirectionsController : Controller
    {
        // GET: Directions
        public ActionResult GetDirections()
        {
            return View();
        }
        public ActionResult Tester()
        {
            return View();
        }

    }
}