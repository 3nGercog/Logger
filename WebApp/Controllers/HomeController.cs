using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAp;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        List<Coordinate> coordinates;
        public HomeController() { }
        public HomeController(ILogger logger, ISession session, IReader reader)
            : base(logger, session, reader)
        {}

        [Logger()]
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();
            STLogger.Info("Create IndexViewModel");
            try
            {
                ivm.Level = SiteLevel.Warn;
                var mod = Reader.GetSorted(ivm);
                var tables = mod.OrderBy(h => h.FileName).ThenBy(h => h.Id).Skip(0).Take(100).ToList();
                ViewData["table"] = tables;
                ViewBag.AllCount = mod.Count;
                STLogger.Info(mod);
            }
            catch (Exception ex)
            {
                STLogger.Error(ex.Message);
            }
            finally
            {
                STLogger.Start();
            }
            return View(ivm);
        }

        [HttpPost]
        [Logger()]
        public ActionResult Index(IndexViewModel model)
        {
            IndexViewModel ivm = new IndexViewModel();
            STLogger.Info("Create IndexViewModel");
            try
            {
                var mod = Reader.GetSorted(model);
                var tables = mod.OrderBy(h => h.FileName).ThenBy(h => h.Id).Skip(0).Take(100).ToList();
                ViewData["table"] = tables;
                ViewBag.AllCount = mod.Count;
                STLogger.Info(mod);
            }
            catch (Exception ex)
            {
                STLogger.Error(ex.Message);
            }
            finally
            {
                STLogger.Start();
            }
            return View(ivm);
        }

        [HttpPost]
        [Logger]
        public PartialViewResult Next(IndexViewModel model, string query, int startIndex, int pageSize)
        {
            List<FileModel> mod;
            if (model != null)
                mod = Reader.GetSorted(model);
            else
                mod = Reader.GetdAll();
            var tables = mod.OrderBy(h => h.FileName).ThenBy(h => h.Id).Skip(startIndex).Take(pageSize).ToList();
            
            ViewData["table"] = tables;
            //var page = source.Skip(startIndex).Take(pageSize);
            return PartialView("_TableView");
        }
        [HttpGet]
        [Logger]
        public ActionResult Detail(string file, string item)
        {
            FileModel fm;
            string row = this.Reader.GetOne(file, item);
            if (!string.IsNullOrEmpty(row))
            {
                var arr = row.Split(new char[] { '\t' });
                fm = new FileModel()
                {
                    FileName = file,
                    Id = item,
                    Level = arr[1],
                    Message = arr[2]
                };
                return View(fm);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
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

                coordinates = this.ISession.Get<List<Coordinate>>("list");

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

                    coordinates = this.ISession.Get<List<Coordinate>>("list") ?? new List<Coordinate>();
                    if (coordinates == null)
                        STLogger.Warn("coordinates = null");

                    STLogger.Info("init coordinates.");

                    coordinates.Add(coordinate);
                    STLogger.Info("Add new coordinate to coordinates.");

                    this.ISession.Store("list", coordinates);
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