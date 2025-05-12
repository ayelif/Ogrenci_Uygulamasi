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
    public class OgrenciDersController : Controller
    {
        private OkulContext db = new OkulContext();

        // GET: OgrenciDers
        public ActionResult Index()
        {
            var ogrenciDersler = db.OgrenciDersler.Include(o => o.Ogrenci).Include(o => o.Ders).ToList();
            return View(ogrenciDersler);
        }

        // CREATE
        public ActionResult Create()
        {
            ViewBag.ogrenciID = new SelectList(db.Ogrenciler, "ogrenciID", "ad");
            ViewBag.dersID = new SelectList(db.Dersler, "dersID", "dersAd");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tOgrenciDers ogrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.OgrenciDersler.Add(ogrenciDers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ogrenciID = new SelectList(db.Ogrenciler, "ogrenciID", "ad", ogrenciDers.ogrenciID);
            ViewBag.dersID = new SelectList(db.Dersler, "dersID", "dersAd", ogrenciDers.dersID);
            return View(ogrenciDers);
        }

        // EDIT
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();
            var ogrenciDers = db.OgrenciDersler.Find(id);
            if (ogrenciDers == null) return HttpNotFound();
            ViewBag.ogrenciID = new SelectList(db.Ogrenciler, "ogrenciID", "ad", ogrenciDers.ogrenciID);
            ViewBag.dersID = new SelectList(db.Dersler, "dersID", "dersAd", ogrenciDers.dersID);
            return View(ogrenciDers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tOgrenciDers ogrenciDers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciDers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ogrenciID = new SelectList(db.Ogrenciler, "ogrenciID", "ad", ogrenciDers.ogrenciID);
            ViewBag.dersID = new SelectList(db.Dersler, "dersID", "dersAd", ogrenciDers.dersID);
            return View(ogrenciDers);
        }

        // DELETE
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();
            var ogrenciDers = db.OgrenciDersler.Find(id);
            if (ogrenciDers == null) return HttpNotFound();
            return View(ogrenciDers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ogrenciDers = db.OgrenciDersler.Find(id);
            db.OgrenciDersler.Remove(ogrenciDers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAILS
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();
            var ogrenciDers = db.OgrenciDersler.Find(id);
            if (ogrenciDers == null) return HttpNotFound();
            return View(ogrenciDers);
        }
        public ActionResult NotGirisi()
        {
            var dersler = db.Dersler.ToList(); // Tüm dersleri al
            ViewBag.Dersler = new SelectList(dersler, "dersID", "dersAd");
            return View(new List<OgrenciNotViewModel>()); // Boş liste ile view açılır
        }


        // Dersin Öğrencilerinin Notlarını Gösterme (POST)
        [HttpPost]
        public ActionResult NotGirisi(int dersId)
        {
            var dersler = db.Dersler.ToList();
            ViewBag.Dersler = new SelectList(dersler, "dersID", "dersAd", dersId); // seçilen ders işaretli gelsin

            // Geri kalan kod...
            var ogrenciNotlar = db.OgrenciDersler
                .Where(od => od.dersID == dersId)
                .Select(od => new OgrenciNotViewModel
                {
                    OgrenciDersID = od.ID,
                    OgrenciAdSoyad = od.Ogrenci.ad + " " + od.Ogrenci.soyad,
                    Vize = od.vize,
                    Final = od.final
                }).ToList();

            ViewBag.DersAdi = db.Dersler.FirstOrDefault(d => d.dersID == dersId)?.dersAd;
            ViewBag.DersId = dersId; // Not kaydetme için sakla
            return View(ogrenciNotlar);
        }




        // Notları Kaydetme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("NotKaydet")] // Alternatif isim verdik
        public ActionResult NotGirisi_Post(List<OgrenciNotViewModel> model, int dersId)
        {
            foreach (var item in model)
            {
                var ogrenciDers = db.OgrenciDersler.Find(item.OgrenciDersID);
                if (ogrenciDers != null)
                {
                    ogrenciDers.vize = item.Vize;
                    ogrenciDers.final = item.Final;
                }
            }

            db.SaveChanges();
            TempData["Mesaj"] = "Notlar başarıyla kaydedildi.";
            return RedirectToAction("NotGirisi", new { dersId = dersId });
        }


        [HttpGet]
        public ActionResult ListStudentCourses()
        {
            return View(); // formu göster
        }

        [HttpPost]
        public ActionResult ListStudentCourses(int? ogrenciID)
        {
            if (ogrenciID == null)
            {
                ViewBag.Mesaj = "Lütfen bir öğrenci numarası girin.";
                return View();
            }

            var dersler = db.OgrenciDersler
                            .Include(x => x.Ogrenci)
                            .Include(x => x.Ders)
                            .Where(x => x.Ogrenci.ogrenciID == ogrenciID)
                            .ToList();

            return View(dersler);
        }

        // GET metodu
        public ActionResult CoursesByYearList()
        {
            return View();
        }

        // POST metodu
        [HttpPost]
        public ActionResult CoursesByYearList(string yil, string yariyil)
        {
            // Eğer 'yil' veya 'yariyil' parametreleri boş ise boş bir liste döndürüyoruz
            if (string.IsNullOrEmpty(yil) || string.IsNullOrEmpty(yariyil))
            {
                return View(new List<DersSecimDurumuViewModel>());
            }

            // Veritabanı sorgusu
            var sonuc = db.OgrenciDersler
                          .Where(x => x.yil == yil && x.yariyil == yariyil) // Yıl ve Yarıyıl filtresi
                          .GroupBy(x => x.Ders.dersAd) // Ders adına göre grupla
                          .Select(g => new DersSecimDurumuViewModel
                          {
                              DersAdı = g.Key, // Ders adı
                              SecilenOgrenciSayisi = g.Count() // Seçilen öğrenci sayısı
                          })
                          .ToList(); // Sonuçları liste olarak al

            return View(sonuc); // Sonuçları View'a gönder
        }

    }
}

