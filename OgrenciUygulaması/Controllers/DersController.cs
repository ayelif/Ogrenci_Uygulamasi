using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OgrenciUygulaması.Models;

namespace OgrenciUygulaması.Controllers
{
    public class DersController : Controller
    {
        private OkulContext db = new OkulContext();

        // GET: tDers
        public ActionResult Index()
        {
            return View(db.Dersler.ToList());
        }

        // GET: tDers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tDers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tDers ders)
        {
            if (ModelState.IsValid)
            {
                db.Dersler.Add(ders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ders);
        }

        // GET: tDers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tDers ders = db.Dersler.Find(id);
            if (ders == null) return HttpNotFound();

            return View(ders);
        }

        // POST: tDers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tDers ders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ders);
        }

        // GET: tDers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tDers ders = db.Dersler.Find(id);
            if (ders == null) return HttpNotFound();

            return View(ders);
        }

        // POST: tDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tDers ders = db.Dersler.Find(id);
            db.Dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }

    }
}
