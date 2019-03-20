using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Movie.Models;

namespace MVC_Movie.Controllers
{
    public class Movie_detailsController : Controller
    {
        private KeepDB db = new KeepDB();

        // GET: Movie_details
        public ActionResult Index()
        {
            var movie_Details = db.Movie_Details.Include(m => m.Actor).Include(m => m.Movie).Include(m => m.Producer);
            return View(movie_Details.ToList());
        }

        // GET: Movie_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_details movie_details = db.Movie_Details.Find(id);
            if (movie_details == null)
            {
                return HttpNotFound();
            }
            return View(movie_details);
        }

        // GET: Movie_details/Create
        public ActionResult Create()
        {
            ViewBag.Actor_Id = new SelectList(db.actors, "Actor_Id", "Actor_name");
            ViewBag.Movie_Id = new SelectList(db.movie, "Movie_Id", "Movie_name");
            ViewBag.Producer_Id = new SelectList(db.producers, "Producer_Id", "Producer_name");
            return View();
        }

        // POST: Movie_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movie_details_id,Actor_Id,Producer_Id,Movie_Id")] Movie_details movie_details)
        {
            if (ModelState.IsValid)
            {
                db.Movie_Details.Add(movie_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Actor_Id = new SelectList(db.actors, "Actor_Id", "Actor_name", movie_details.Actor_Id);
            ViewBag.Movie_Id = new SelectList(db.movie, "Movie_Id", "Movie_name", movie_details.Movie_Id);
            ViewBag.Producer_Id = new SelectList(db.producers, "Producer_Id", "Producer_name", movie_details.Producer_Id);
            return View(movie_details);
        }

        // GET: Movie_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_details movie_details = db.Movie_Details.Find(id);
            if (movie_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Actor_Id = new SelectList(db.actors, "Actor_Id", "Actor_name", movie_details.Actor_Id);
            ViewBag.Movie_Id = new SelectList(db.movie, "Movie_Id", "Movie_name", movie_details.Movie_Id);
            ViewBag.Producer_Id = new SelectList(db.producers, "Producer_Id", "Producer_name", movie_details.Producer_Id);
            return View(movie_details);
        }

        // POST: Movie_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Movie_details_id,Actor_Id,Producer_Id,Movie_Id")] Movie_details movie_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Actor_Id = new SelectList(db.actors, "Actor_Id", "Actor_name", movie_details.Actor_Id);
            ViewBag.Movie_Id = new SelectList(db.movie, "Movie_Id", "Movie_name", movie_details.Movie_Id);
            ViewBag.Producer_Id = new SelectList(db.producers, "Producer_Id", "Producer_name", movie_details.Producer_Id);
            return View(movie_details);
        }

        // GET: Movie_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie_details movie_details = db.Movie_Details.Find(id);
            if (movie_details == null)
            {
                return HttpNotFound();
            }
            return View(movie_details);
        }

        // POST: Movie_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie_details movie_details = db.Movie_Details.Find(id);
            db.Movie_Details.Remove(movie_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
