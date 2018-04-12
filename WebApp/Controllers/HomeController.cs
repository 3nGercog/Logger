using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using WebAp;
using WebApp.Models;

namespace WebApp.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.Required)]
    public class HomeController : BaseController
    {
        List<Coordinate> coordinates;
        public HomeController() { }
        public HomeController(ILogger logger, ISession session, IReader reader, ISum sum)
            : base(logger, session, reader, sum)
        {}

        [Logger()]
        public ActionResult Index(IndexViewModel model, int? page)
        {
            IndexViewModel ivm = model;
            STLogger.Info("Create IndexViewModel");
            try
            {
                int pg = page.HasValue ? page.Value : 1;
                int size = 100;
                var mod = Reader.Sort(ivm);
                var tables = mod.OrderBy(h => h.FileName).ThenBy(h => h.Id).ToList();
                ViewData["table"] = tables.ToPagedList(pg, size) ?? new List<FileModel>().ToPagedList(pg, size);
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

                var mod = Reader.Sort(model);
                var tables = mod.OrderBy(h => h.FileName).ThenBy(h => h.Id).ToList();
                ViewData["table"] = tables.ToPagedList(1, 100) ?? new List<FileModel>().ToPagedList(1, 100);
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
                mod = Reader.Sort(model);
            else
                mod = Reader.GetAll();
            var tables = mod.OrderBy(h => h.FileName).ThenBy(h => h.Id).Skip(startIndex).Take(pageSize).ToList();
            
            ViewData["table"] = tables ?? new List<FileModel>();
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

                coordinates = new List<Coordinate>();

                //coordinates = (List<Coordinate>)this.Session["list"] ?? new List<Coordinate>();
                //coordinates = new List<Coordinate>() { new Coordinate { X = 2, Y = 2 }, new Coordinate { X = 3, Y = 5 },
                //    new Coordinate { X = 6, Y = 3 }, new Coordinate { X = 2, Y = 2 } };
                double x = 0, y = 0;
                //if (coordinates == null)
                //    STLogger.Warn("coordinates = null");
                //else if(coordinates.Count <= 3)
                //    STLogger.Warn("coordinates Count = " + coordinates.Count.ToString());
                //else
                //{
                //    STLogger.Debug("Start sum to X");
                //    x = Sum.SumX(coordinates);
                //    STLogger.Debug("Start sum to Y");
                //    y = Sum.SumY(coordinates);
                //    STLogger.Debug("Complete sum ");
                //}

                ViewData["list"] = coordinates;
                ViewData["graf"] = coordinates;
                STLogger.Info("set ViewData[\"graf\"]");
                ViewBag.Result = coordinates?.StringFormat();
                ViewBag.X = string.Format("sumX = {0}", x.ToString("N2"));
                ViewBag.Y = string.Format("sumY =  {0}", y.ToString("N2"));
                ViewBag.Square = string.Format("Square is {0}", (x == y).ToString());

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
                    ViewBag.Message = "Калькулятор";
                    if (ViewBag.Message == null)
                        STLogger.Warn("ViewBag.Message = null");
                    else
                        STLogger.Info("set ViewBag.Message = " + ViewBag.Message);
                    STLogger.Info("ModelState.IsValid " + ModelState.IsValid.ToString());

                    coordinates = (List<Coordinate>)ViewData["list"] ?? new List<Coordinate>();
                    //coordinates = (List<Coordinate>)this.Session["list"] ?? new List<Coordinate>();
                    if (coordinates == null)
                        STLogger.Warn("coordinates = null");

                    STLogger.Info("init coordinates.");

                    coordinates.Add(coordinate);
                    STLogger.Info("Add new coordinate to coordinates.");

                    ViewData["list"] = coordinates;
                    STLogger.Info("Write coordinates to session");
                    double x = 0, y = 0;
                    if (coordinates == null)
                        STLogger.Warn("coordinates = null");
                    else if (coordinates.Count <= 3)
                        STLogger.Warn("coordinates Count = " + coordinates.Count.ToString());
                    else
                    {
                        STLogger.Debug("Start sum to X");
                        x = Sum.SumX(coordinates);
                        STLogger.Debug("Start sum to Y");
                        y = Sum.SumY(coordinates);
                        STLogger.Debug("Complete sum ");
                    }

                    STLogger.Info("init coordinates.");

                    ViewData["graf"] = coordinates;
                    STLogger.Info("set ViewData[\"graf\"]");
                    ViewBag.Result = coordinates?.StringFormat();
                    //" sumX = " + x.Value.ToString("N2") + " sumY = " + y.Value.ToString("N2") + " Square is " + (x.Value == y.Value).ToString();
                    ViewBag.X = string.Format("sumX = {0}", x.ToString("N2"));
                    ViewBag.Y = string.Format("sumY =  {0}", y.ToString("N2"));
                    ViewBag.Square = string.Format("Square is {0}", (x == y).ToString());
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
                return View("Calculator");
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