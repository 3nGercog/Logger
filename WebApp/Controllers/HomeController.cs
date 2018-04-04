using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        STLogger logger;
        public HomeController()
        {
            logger = new STLogger(Target.File | Target.Output);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculator()
        {
            ViewBag.Message = "Калькулятор";

            return View();
        }
    }
}