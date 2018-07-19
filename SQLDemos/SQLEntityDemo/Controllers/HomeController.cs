using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLEntityDemo.Models;
// need to add this
// NB SQL database relationships didn't work on PC, see slides for details on how to do it on another machine
namespace SQLEntityDemo.Controllers
{
    public class HomeController : Controller
    {
        private CustomersOrdersJulyEntities db = new CustomersOrdersJulyEntities();
        // need to add this
        public ActionResult Index()
        {
            return View();
        }
    }
}