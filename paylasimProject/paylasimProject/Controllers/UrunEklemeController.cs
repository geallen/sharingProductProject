using paylasimProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace paylasimProject.Controllers
{
    public class UrunEklemeController : Controller
    {
        // GET: UrunEkleme
        public ActionResult UrunEkleme()
        {


            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult UrunEkleme(UrunEklemeEkrani model, string url)
        {
            string FileName = Path.GetFileName(model.UrunResmi.FileName);
            string uzantisizResimAdi = Path.GetFileNameWithoutExtension(model.UrunResmi.FileName);
            string path = Path.Combine(Server.MapPath("~/images"), FileName);
            ViewBag.resimAdi = FileName;
            // ViewBag.yol = path;
            //ViewBag.uzantisizResimAdi = uzantisizResimAdi;
            string sonuc = urunEkle(model.UrunAdi, model.UrunDurumu, model.UrunBilgisi, uzantisizResimAdi, FileName);

            ViewBag.sonuc = sonuc;
            if (sonuc == "Ekleme Basarili")
            {
                TempData["mesaj4"] = "Urun Ekleme Basarili";
                if (model.UrunResmi != null)
                {
                    model.UrunResmi.SaveAs(path);
                }
                return View();
            }
            else
            {
                TempData["mesaj4"] = "Yeniden Eklemeyi Deneyiniz";
                return View(model);
            }
        }


        public ActionResult urunGoruntule()
        {
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            var urunler = db.urun.ToList();
            ViewBag.urunListesi = urunler;

            return View();
        }



        public ActionResult urunBilgileri()
        {
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            var urunler = db.urun.ToList();
            ViewBag.urunListesi = urunler;


            return View();
        }


        public string urunEkle(string urunAdi, string urunDurumu, string urunBilgisi, string resimAdi, string urunPath)
        {
            try
            {
                projectPaylasimEntities4 db = new projectPaylasimEntities4();
                urun u = new urun();
                u.urunAdi = urunAdi;
                u.urunResmi = resimAdi;
                urunDurumu = urunDurumu.Replace(" ", String.Empty);
                string urunDurumuSonHali = urunDurumu.ToUpper();
                u.urunDurumu = urunDurumuSonHali;
                u.urunBilgisi = urunBilgisi;
                u.urunPath = urunPath;


                db.urun.Add(u);
                db.SaveChanges();
                return "Ekleme Basarili";
            }
            catch (Exception ex)
            {
                return "Hata : " + ex;
            }
        }
    }
}