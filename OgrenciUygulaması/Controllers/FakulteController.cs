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
    public class FakulteController : Controller
    {
        private OkulContext db = new OkulContext();

        // GET: Fakulte
        public ActionResult Index()
        {
            return View(db.Fakulteler.ToList());
        }

        // GET: Fakulte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFakulte tFakulte = db.Fakulteler.Find(id);
            if (tFakulte == null)
            {
                return HttpNotFound();
            }
            return View(tFakulte);
        }

        // GET: Fakulte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fakulte/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fakulteID,fakulteAd")] tFakulte tFakulte)
        {
            if (ModelState.IsValid)
            {
                db.Fakulteler.Add(tFakulte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tFakulte);
        }

        // GET: Fakulte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFakulte tFakulte = db.Fakulteler.Find(id);
            if (tFakulte == null)
            {
                return HttpNotFound();
            }
            return View(tFakulte);
        }

        // POST: Fakulte/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fakulteID,fakulteAd")] tFakulte tFakulte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tFakulte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tFakulte);
        }

        // GET: Fakulte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFakulte tFakulte = db.Fakulteler.Find(id);
            if (tFakulte == null)
            {
                return HttpNotFound();
            }
            return View(tFakulte);
        }

        // POST: Fakulte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tFakulte tFakulte = db.Fakulteler.Find(id);
            db.Fakulteler.Remove(tFakulte);
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
        // GET: Fakulte/FakulteEkle
        public ActionResult FakulteEkle()
        {
            return View();
        }

        // POST: Fakulte/FakulteEkle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FakulteEkle([Bind(Include = "fakulteID,fakulteAd")] tFakulte tFakulte)
        {
            if (ModelState.IsValid)
            {
                db.Fakulteler.Add(tFakulte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tFakulte);
        }

    }
}
