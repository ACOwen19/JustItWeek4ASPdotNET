using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMovies18.Models;
using System.Data.Entity;
using System.Net;

namespace MVCMovies18.Controllers
{
    public class HomeController : Controller
    {
        private MoviesACO18Entities db = new MoviesACO18Entities();

        public ActionResult Index(string SearchString, string movieGenre)
        {
            // creates an empty list to populate the select for movieGenre
            List<string> genreList = new List<string>();
            // gets the genres from the db in order
            var genreQuery = from g in db.Movies
                             orderby g.Genre
                             select g.Genre;
            // adds unique genres to the list (distinct is unique)
            // NB doing this means that only one value for each genre will be passed in meaning that only that database entry will display
            // We aren't hard coding this so the list will update if new genres are added by the create or edit methods
            genreList.AddRange(genreQuery.Distinct());
            // creates select list and populates it with the values in the genreList
            // before passing it to the viewbag to be forund by the view
            ViewBag.movieGenre = new SelectList(genreList);
            
            //LINQ query to get all records from the db
            var movies = from m in db.Movies
            select m;


            if (!String.IsNullOrEmpty(movieGenre)) // If the dropdown hasn't been clicked or is on the defualt value
            {
                movies = movies.Where(x => x.Genre == (movieGenre));
            }

            if (!String.IsNullOrEmpty(SearchString)) // If the searchbox is not empty
            {
                movies = movies.Where(x => x.Title.Contains(SearchString)); // movies = only movies whose title contains the entered string
            }
          

            //passing the data to the view
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Ensures the called method contains @Html.AntiForgeryToken();
        public ActionResult Create([Bind(Include ="Id,Title,ReleaseDate,Genre,Price,ImageUrl")]Movie movie)
            // Bind means only date for the included fields are allowed into the action method
        {

            // because we are displaying the urls but image url is a nullable value the page will crash if there is no image url,
            // therefore we set a default value for imageUrl if its null
            if (movie.ImageUrl == null)
            {
                movie.ImageUrl = "https://vignette.wikia.nocookie.net/theimaginenation/images/e/ed/N-a.jpg/revision/latest?cb=20121209234504";
            }

            if (ModelState.IsValid) // Ensures that the action method will only run if the data validation rules have been met
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                // Save Changes sends any pending db changes to the server
                return RedirectToAction("Index");
                // Redirects the user to the index action method, aka to the list of movies
            }
            return View(movie);
        }

        public ActionResult Edit(int? id) // int? makes the int nullable
        {
            // if a null id is passed in, display HTML error page, null will be entered 
            // if the user attemtps to enter a custom url such as /Home/Details without
            // Entering an id afterwards
            // need to add using System.Net to use HttpStatusCode
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get record from the database using its id
            Movie movie = db.Movies.Find(id);

            // if user enters an invalid id & the record doesn't exist in the db display
            // an HTML error page. HTML error pages look much better than standard error pages
            if (movie == null)
            {
                return HttpNotFound();
            }
            //Pass the data to the view to be displayed
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseDate,Genre,Price,ImageUrl")]Movie movie)
        {
            if (movie.ImageUrl == null)
            {
                movie.ImageUrl = "https://vignette.wikia.nocookie.net/theimaginenation/images/e/ed/N-a.jpg/revision/latest?cb=20121209234504";
            }

            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                // needed to add using System.Data.Entity to allow us to edit the entity framework
                // this modifies an existing method
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // This method tells the program to dispose of any resources as soon as it is finished using them,
        // releasing memory & improving performance
        // using in @using (Html.BeginForm()) tells MVC to release the resources for the form as soon as they are no longer needed
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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