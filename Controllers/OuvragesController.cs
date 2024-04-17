using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP_Recapitulatif.DAL;
using TP_Recapitulatif.Models;

namespace TP_Recapitulatif.Controllers
{
    public class OuvragesController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Ouvrages
        public ActionResult Index()
        {
            var ouvrages = db.Ouvrages.Include(o => o.Categorie);
            return View(ouvrages.ToList());
        }

        // GET: Ouvrages/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            return View(ouvrage);
        }

        // GET: Ouvrages/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom");
            return View();
        }

        // POST: Ouvrages/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre,Descriptif,Prix,CategorieId")] Ouvrage ouvrage)
        {
            if (ModelState.IsValid)
            {
                db.Ouvrages.Add(ouvrage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom", ouvrage.CategorieId);
            return View(ouvrage);
        }

        // GET: Ouvrages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom", ouvrage.CategorieId);
            return View(ouvrage);
        }

        // POST: Ouvrages/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre,Descriptif,Prix,CategorieId")] Ouvrage ouvrage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ouvrage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "Id", "Nom", ouvrage.CategorieId);
            return View(ouvrage);
        }

        // GET: Ouvrages/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            if (ouvrage == null)
            {
                return HttpNotFound();
            }
            return View(ouvrage);
        }

        // POST: Ouvrages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ouvrage ouvrage = db.Ouvrages.Find(id);
            db.Ouvrages.Remove(ouvrage);
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
