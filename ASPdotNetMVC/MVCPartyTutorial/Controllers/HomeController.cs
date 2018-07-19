using MVCPartyTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPartyTutorial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost] // Capable of taking info from server
        public ActionResult RsvpForm(GuestResponse guestResponse)
        {
       
            if (ModelState.IsValid)
            {
            return View("Thanks", guestResponse);
                
            }
            else // If there has been an error this will return the user to the current view
            {
                return View();
            }
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