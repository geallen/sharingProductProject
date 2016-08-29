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
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            var yardimAlan = Session["yardimalanAdi"];
            string yardimAlanAd = string.Empty;
            string gonulluAd = string.Empty;
            if (yardimAlan != null)
            {
                yardimAlanAd += yardimAlan.ToString();
            }
            var gonullu = Session["gonulluAdi"];
            if (gonullu != null)
            {
                gonulluAd += gonullu.ToString();
            }
            ViewBag.yardimAdi = yardimAlan;

            ViewBag.gonulluAdi = gonullu;
            var users = db.user.ToList();

            foreach (user u in users)
            {
                if (u.userKullaniciAdi == yardimAlanAd)
                {
                    var yardimAlanId = u.userId;
                    ViewBag.yardimAlanID = yardimAlanId;
                }
                else if (u.userKullaniciAdi == gonulluAd)
                {
                    var gonulluId = u.userId;
                    ViewBag.gonulluID = gonulluId;
                }
            }

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


            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            
            string gonulluAd = string.Empty;
            
            var gonullu = Session["gonulluAdi"];
            if (gonullu != null)
            {
                gonulluAd += gonullu.ToString();
            }
           

            ViewBag.gonulluAdi = gonullu;
            var users = db.user.ToList();
           // string y = null;
            int gonulluId = 0;
            foreach (user u in users)
            {
                 if (u.userKullaniciAdi == gonulluAd)
                {
                    gonulluId = u.userId;
                  //  ViewBag.gonulluID = gonulluId;
                }
            }


            string sonuc = urunEkle(model.UrunAdi, model.UrunDurumu, model.UrunBilgisi, gonulluId, uzantisizResimAdi, FileName);

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
            var kullanicilar = db.user.ToList();
            ViewBag.kullaniciListesi = kullanicilar;
            var yardimAlan = Session["yardimalanAdi"];
            string yardimAlanAd = string.Empty;
            string gonulluAd = string.Empty;
            if (yardimAlan != null)
            {
                yardimAlanAd += yardimAlan.ToString();
            }
            var gonullu = Session["gonulluAdi"];
            if (gonullu != null)
            {
               gonulluAd += gonullu.ToString();
            }
            ViewBag.yardimAdi = yardimAlan;
           
            ViewBag.gonulluAdi = gonullu;
            var users = db.user.ToList();

            foreach(user u in users)
            {
                if(u.userKullaniciAdi == yardimAlanAd)
                {
                    var yardimAlanId = u.userId;
                    ViewBag.yardimAlanID = yardimAlanId;
                }
                else if(u.userKullaniciAdi == gonulluAd)
                {
                    var gonulluId = u.userId;
                    ViewBag.gonulluID = gonulluId;
                }
            }
           
            return View();
        }

        [HttpPost]
        public JsonResult urunYorumEkle1(string yorumm, int kid,  int id)
        {
            projectPaylasimEntities4 database = new projectPaylasimEntities4();
            yorum yorum1 = new yorum();
            yorum1.yorumTarihi = DateTime.Now;
            yorum1.yorumIcerik = yorumm;
            yorum1.userId = kid;
            yorum1.urunId = id;

            database.yorum.Add(yorum1);
            database.SaveChanges();
            return Json(yorumm+","+id.ToString());
        }


        public ActionResult urunBilgileri()
        {
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            var urunler = db.urun.ToList();
            ViewBag.urunListesi = urunler;


            return View();
        }

        public string urunEkle(string urunAdi, string urunDurumu, string urunBilgisi, int userId, string resimAdi, string urunPath)
        {
            try
            {
                projectPaylasimEntities4 db = new projectPaylasimEntities4();
                urun u = new urun();
                string urunAdiSonHali = urunAdi.ToUpper();

                u.urunAdi = urunAdiSonHali;
                u.urunResmi = resimAdi;
                urunDurumu = urunDurumu.Replace(" ", String.Empty);
                string urunDurumuSonHali = urunDurumu.ToUpper();
                u.urunDurumu = urunDurumuSonHali;
                u.urunBilgisi = urunBilgisi;
                u.urunPath = urunPath;
                u.ekleyenUserId = userId;

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