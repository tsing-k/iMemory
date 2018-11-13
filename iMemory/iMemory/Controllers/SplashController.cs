using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iMemory.Controllers
{
    public class SplashController : Controller
    {
        // GET: Splash
        public ActionResult Index()
        {
            ViewBag.Title = "李芳芳生日快乐！";
            ViewBag.Name = "李芳芳";
            return View();
        }
    }
}