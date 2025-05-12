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
     public class BolumController : Controller
    {
        private OkulContext db = new OkulContext();

        // GET: tBolum
        public ActionResult Index()
        {
            return View(db.Bolumler.ToList());
        }

        // GET: tBolum/Create
        public ActionResult Create()
        {
            // Fakülte listesini ViewBag'e doğru şekilde ekliyoruz
            ViewBag.FakulteID = new SelectList(db.Fakulteler, "fakulteID", "fakulteAd");
            return View();
        }

        // POST: tBolum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tBolum bolum)
        {
            if (ModelState.IsValid)
            {
                db.Bolumler.Add(bolum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Eğer model geçerli değilse, fakülte listesini tekrar ViewBag'e ekliyoruz
            ViewBag.FakulteID = new SelectList(db.Fakulteler, "fakulteID", "fakulteAd", bolum.fakulteID);
            return View(bolum);
        }

        // GET: tBolum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tBolum bolum = db.Bolumler.Find(id);
            if (bolum == null) return HttpNotFound();

            return View(bolum);
        }

        // POST: tBolum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tBolum bolum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolum);
        }

        // GET: tBolum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tBolum bolum = db.Bolumler.Find(id);
            if (bolum == null) return HttpNotFound();

            return View(bolum);
        }

        // POST: tBolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tBolum bolum = db.Bolumler.Find(id);
            db.Bolumler.Remove(bolum);
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

