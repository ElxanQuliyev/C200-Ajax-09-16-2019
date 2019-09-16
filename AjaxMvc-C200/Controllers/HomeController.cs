using AjaxMvc_C200.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxMvc_C200.Controllers
{
    public class HomeController : Controller
    {
        CarsC200DB db = new CarsC200DB();
        public ActionResult Index()
        {
            ViewBag.marka = db.Markas.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}