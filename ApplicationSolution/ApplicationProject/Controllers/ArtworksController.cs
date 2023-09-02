using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationProject.DAL;
using ApplicationProject.Models;

namespace ApplicationProject.Controllers
{
    public class ArtworksController : Controller
    {
        private WorkContext db = new WorkContext();

        // GET: Artworks
        public ActionResult Index()
        {
            var artworks = db.Artworks.Include(a => a.Job);
            return View(artworks.ToList());
        }

        // GET: Artworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // GET: Artworks/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title");
            return View();
        }

        // POST: Artworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtworkId,Title,NameOfCreator,DateOfCreation,Description,JobId")] Artwork artwork)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Artworks.Add(artwork);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log).
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title", artwork.JobId);
            return View(artwork);
        }

        // GET: Artworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title", artwork.JobId);
            return View(artwork);
        }

        // POST: Artworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artworkUpdate = db.Artworks.Find(id);
            if (TryUpdateModel(artworkUpdate, "", new string[] { "ArtworkId", "Title", "NameOfCreator", "DateOfCreation", "Description", "JobId" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log).
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "Title", artworkUpdate.JobId);
            return View(artworkUpdate);
        }

        // GET: Artworks/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if problem pesists see your system administrator.";
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // POST: Artworks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Artwork artwork = db.Artworks.Find(id);
                db.Artworks.Remove(artwork);
                db.SaveChanges();
            }
            catch
            {
                //Log the error (uncomment dex variable name and add a line here to write a log).
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
