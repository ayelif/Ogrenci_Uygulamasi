using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciUygulaması.Controllers
{
    public class HomeController : Controller
    {
        // Index sayfasını görüntüle
        public ActionResult Index()
        {
            return View();
        }

        // Fakülte Ekleme Sayfası
        public ActionResult FakulteEkle()
        {
            return View();
        }

        // Bölüm Ekleme Sayfası
        public ActionResult BolumEkle()
        {
            return View();
        }

        // Öğrenci Ekleme Sayfası
        public ActionResult OgrenciEkle()
        {
            return View();
        }

        // Öğrenci Sorgula Sayfası
        public ActionResult OgrenciSorgula()
        {
            return View();
        }

        // Öğrenci Sorgula Web Servisi Sayfası
        public ActionResult OgrenciSorgulaWebServis()
        {
            return View();
        }

        // Ders Atama ve Listeleme Sayfası
        public ActionResult DersAtama()
        {
            return View();
        }

        // Ders Tablosu Yönetimi Sayfası
        public ActionResult DersTablosu()
        {
            return View();
        }

        // Bölüm Tablosu Yönetimi Sayfası
        public ActionResult BolumTablosu()
        {
            return View();
        }

        // Öğrenci Tablosu Yönetimi Sayfası
        public ActionResult OgrenciTablosu()
        {
            return View();
        }
    }

}