using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace climateResearch.Controllers
{
    public class AdminController : Controller
    {
        // Пункт наблюдения
        public ActionResult index()
        {
            return View();
        }
    }
}