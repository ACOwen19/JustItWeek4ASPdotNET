using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emptyMCVDemo.Models;
// Must ensure that it can use the model we created

namespace emptyMCVDemo.Controllers
{
    public class HomeController : Controller
    {
        List<Album> albums = new List<Album>();
        
        public ActionResult Index()
        {
            Album album1 = new Album("Dark Side of the Moon", "Pink Floyd", "Vinyl", 9.99M);
            albums.Add(album1);
            Album album2 = new Album("Rumors", "Fleetwood Mac", "CD", 8.99M);
            albums.Add(album2);
            Album album3 = new Album("Mouth Sounds", "Neil Cicerega", "Download", 12.99M);
            albums.Add(album3);
            // must pass data to the view
            return View(albums);
        }
    }
}