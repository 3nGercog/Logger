using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        List<Coordinate> coordinates;
        public HomeController(ILogger logger) : base(logger)
        {
        }
        [Logger()]
        public ActionResult Index()
        {
            try
            {
                STLogger.Info("Index");
            }
            catch (Exception ex)
            {
                STLogger.Error(ex.Message);
            }
            finally
            {
                STLogger.Start();
            }
            
            
            return View();
        }

        [HttpGet]
        [Logger()]
        public ActionResult Calculator()
        {
            try
            {
                ViewBag.Message = "Калькулятор";
                if (ViewBag.Message == null)
                    STLogger.Warn("ViewBag.Message = null");
                else
                    STLogger.Info("set ViewBag.Message = " + ViewBag.Message);

                coordinates = Session.GetDataFromSession<List<Coordinate>>("list");

                if (coordinates == null)
                    STLogger.Warn("coordinates = null");

                STLogger.Info("init coordinates.");

                ViewData["graf"] = coordinates;
                STLogger.Info("set ViewData[\"graf\"]");
                ViewBag.Result = coordinates?.StringFormat();
                STLogger.Info("set ViewBag.Result");

                STLogger.Info("Write coordinates to session");
            }
            catch (Exception ex)
            {
                STLogger.Error(ex.Message);
            }
            finally
            {
                STLogger.Start();
            }

            return View();
        }
        [HttpPost]
        [Logger()]
        public ActionResult Calculator(Coordinate coordinate)
        {
            if (ModelState == null)
                STLogger.Warn("ModelState = null");
            if (ModelState.IsValid)
            {
                try
                {
                    STLogger.Info("ModelState.IsValid " + ModelState.IsValid.ToString());

                    coordinates = this.Session.GetDataFromSession<List<Coordinate>>("list") ?? new List<Coordinate>();
                    if (coordinates == null)
                        STLogger.Warn("coordinates = null");

                    STLogger.Info("init coordinates.");

                    coordinates.Add(coordinate);
                    STLogger.Info("Add new coordinate to coordinates.");

                    Session.SetDataToSession<List<Coordinate>>("list", coordinates);
                    STLogger.Info("Write coordinates to session");
                }
                catch (Exception ex)
                {
                    STLogger.Error(ex.Message);
                }
                finally
                {
                    STLogger.Start();
                }
                return RedirectToAction("Calculator");
            }
            else
            {
                STLogger.Warn("ModelState.IsValid " + ModelState.IsValid.ToString());
                STLogger.Start();
                return View(coordinate);
            }
        }
    }
}