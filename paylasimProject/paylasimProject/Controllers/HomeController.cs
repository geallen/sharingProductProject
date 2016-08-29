using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace paylasimProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mesajlasma()
        {
            ViewBag.Message = "Mesaj Sayfasina Hosgeldiniz";
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

        [HttpPost]
        public ActionResult Mesajlasma(int gonderenId, int gonderilenId, string mesaj, string konu)
        {
            var gonderilmeTarihi = DateTime.Now;
            string sonuc = mesajGonder(gonderenId, gonderilenId, mesaj, gonderilmeTarihi, konu);
            //   ViewBag.sonuc = sonuc;
            if (sonuc == "Mesajiniz Gonderildi")
            {
                // return Json(gonderenId + "," + gonderilenId + "," + mesaj + "," + konu);
                //  return RedirectToAction("Index");
                TempData["sonuc"] = "Mesajiniz Gonderildi";
                return RedirectToAction("UrunEkleme", "UrunEkleme");
            }
            else
            {
                // return Json(",");
                TempData["sonuc"] = "Mesajiniz Gonderildi";
                return View();
            }
        }

        public string mesajGonder(int gonderenId, int gonderilenId, string mesaj, DateTime gonderilmeTarihi, string konu)
        {
            try
            {
                projectPaylasimEntities4 database = new projectPaylasimEntities4();
                mesajlar mesaj1 = new mesajlar();

                mesaj1.gonderenId = gonderenId;
                mesaj1.gonderilenId = gonderilenId;
                mesaj1.mesajIcerik = mesaj;
                mesaj1.mesajKonusu = konu;
                mesaj1.gonderilmeTarihi = gonderilmeTarihi;
                database.mesajlar.Add(mesaj1);
                database.SaveChanges();

                return "Mesajiniz Gonderildi";

            }

            catch (Exception ex)
            {
                return "Mesaj Gonderilirken Hata :" + ex.Message;
            }
        }

        public ActionResult MesajlariGoruntule()
        {
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
         
            string yardimAlanAd = string.Empty;
            string gonulluAd = string.Empty;
            int userId = 0;
            string userAdi = string.Empty;

            if (Session["yardimalanAdi"] != null)
            {
                userAdi += Session["yardimalanAdi"].ToString();
            }
            if (Session["gonulluAdi"] != null)
            {
                userAdi += Session["gonulluAdi"].ToString();
            }
            ViewBag.userADI = userAdi;
            var users = db.user.ToList();
            foreach (user u in users)
            {
                if (u.userKullaniciAdi == userAdi)
                {
                    userId = u.userId;
                }
                else if (u.userKullaniciAdi == userAdi)
                {
                    userId = u.userId;
                }
            }
            ViewBag.userID = userId;
            var mesajListesi = db.mesajlar.ToList();
            ViewBag.mesajListesi = mesajListesi;
            return View();
        }
    }
}