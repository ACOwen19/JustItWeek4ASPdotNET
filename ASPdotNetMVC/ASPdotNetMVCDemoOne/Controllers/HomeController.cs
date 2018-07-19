using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPdotNetMVCDemoOne.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id = 0)
        {
            ViewBag.NumberOfTimes = id;
            return View();
        }

        public ActionResult About(string myName, int myNumber = 1)
        {
            ViewBag.Message = "Hello, " + myName + " your number is: " + myNumber + ".";

            return View();
        }

        public ActionResult Contact(int id = 0)
        {
            ViewBag.Message = "Hello, you typed in the number " +id;

            return View();
        }
    }
}