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
    public class OgrenciController : Controller
    {
        private OkulContext db = new OkulContext();


        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.Ogrenciler.Include(o => o.Bolum);
            return View(ogrenciler.ToList());
        }

        // GET: Ogrenci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tOgrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
                return HttpNotFound();

            return View(ogrenci);
        }

        // GET: Ogrenci/Create
        public ActionResult Create()
        {
            ViewBag.bolumID = new SelectList(db.Bolumler, "bolumID", "bolumAd");
            return View();
        }

        // POST: Ogrenci/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ogrenciID,ad,soyad,bolumID")] tOgrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Ogrenciler.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bolumID = new SelectList(db.Bolumler, "bolumID", "bolumAd", ogrenci.bolumID);
            return View(ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tOgrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
                return HttpNotFound();

            ViewBag.bolumID = new SelectList(db.Bolumler, "bolumID", "bolumAd", ogrenci.bolumID);
            return View(ogrenci);
        }

        // POST: Ogrenci/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ogrenciID,ad,soyad,bolumID")] tOgrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bolumID = new SelectList(db.Bolumler, "bolumID", "bolumAd", ogrenci.bolumID);
            return View(ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tOgrenci ogrenci = db.Ogrenciler.Find(id);
            if (ogrenci == null)
                return HttpNotFound();

            return View(ogrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tOgrenci ogrenci = db.Ogrenciler.Find(id);
            db.Ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
        // Öğrenciye ait dersleri listeleme
        public ActionResult OgrencininDersListesi()
        {
            ViewBag.Ogrenciler = new SelectList(db.Ogrenciler.ToList(), "ogrenciID", "ad");
            return View();
        }

        [HttpPost]
        public ActionResult OgrencininDersListesi(int ogrenciID)
        {
            var dersler = db.OgrenciDersler
                .Where(o => o.ogrenciID == ogrenciID)
                .Include(o => o.Ders)
                .ToList();

            ViewBag.Ogrenciler = new SelectList(db.Ogrenciler.ToList(), "ogrenciID", "ad", ogrenciID);
            return View(dersler);
        }

        // Yıla ve yarıyıla göre ders seçim sayısı
        public ActionResult DersSecimSayilari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DersSecimSayilari(string yil, string yariyil)
        {
            var sonuc = db.OgrenciDersler
                .Where(x => x.yil == yil && x.yariyil == yariyil)
                .GroupBy(x => x.dersID)
                .Select(g => new
                {
                    DersAdi = g.FirstOrDefault().Ders.dersAd,
                    OgrenciSayisi = g.Count()
                })
                .ToList();

            ViewBag.Sonuclar = sonuc;
            ViewBag.Yil = yil;
            ViewBag.Yariyil = yariyil;
            return View();
        }



    }
}
