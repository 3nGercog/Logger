using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        STLogger logger;
        List<Coordinate> coordinates;

        public HomeController()
        {
            logger = new STLogger(Target.File | Target.Output);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Calculator()
        {
            ViewBag.Message = "Калькулятор";
            coordinates = (List<Coordinate>)Session["list"];
            ViewData["graf"] = coordinates ?? new List<Coordinate>();
            ViewBag.Result = coordinates?.StringFormat();
            return View();
        }
        [HttpPost]
        public ActionResult Calculator(Coordinate coordinate)
        {
            if (ModelState.IsValid)
            {
                coordinates = (List<Coordinate>)Session["list"] ?? new List<Coordinate>();
                coordinates.Add(coordinate);
                Session.Add("list", coordinates);
                return RedirectToAction("Calculator");
            }
            else
            {
                return View(coordinate);
            }
        }
    }
}