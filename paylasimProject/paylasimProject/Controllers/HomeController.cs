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

        public ActionResult Mesajlasma(int urunSahibiId)
        {
            ViewBag.urunSahibiID = urunSahibiId;
            ViewBag.Message = "Mesaj Sayfasina Hosgeldiniz";
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            var yardimAlan = Session["yardimalanAdi"];
            string yardimAlanAd = string.Empty;
            string gonulluAd = string.Empty;

            string girisYapanUserAdi = string.Empty;
            if (Session["yardimalanAdi"] != null)
            {
                girisYapanUserAdi = (string)Session["yardimalanAdi"];
            }
            if (Session["gonulluAdi"] != null)
            {
                girisYapanUserAdi = (string)Session["gonulluAdi"];
            }

            var gonderilcekKisi = Request["urunSahibiId"];
            int gonderilcek_Kisi = int.Parse(gonderilcekKisi);
            ViewBag.gonderilcekKisi = gonderilcek_Kisi;

            foreach (user u in db.user)
            {

                if (u.userKullaniciAdi == girisYapanUserAdi)
                {
                    ViewBag.girisYapanUserAdi = u.userAdi;
                    ViewBag.girisYapanUserId = u.userId;
                }
                if (u.userId == gonderilcek_Kisi)
                {
                    ViewBag.gonderilcekKisi = u.userAdi;
                    ViewBag.gonderilcekKisiId = u.userId;
                }
            }


            return View();
        }

        public ActionResult Mesajlasma1(int gonderenID)
        {

            ViewBag.Message = "Mesaj Sayfasina Hosgeldiniz";
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            int girisYapmisUserId = 0;
            string mesajListesi = string.Empty;
            string girisYapmisUserAdi = string.Empty;
            if (Session["gonulluAdi"] != null)
            {
                girisYapmisUserAdi = (string)Session["gonulluAdi"];
            }

            if (Session["yardimAlanAdi"] != null)
            {
                girisYapmisUserAdi = (string)Session["yardimAlanAdi"];
            }
            foreach (user u in db.user)
            {
                if (u.userKullaniciAdi == girisYapmisUserAdi)
                {
                    girisYapmisUserId = u.userId;
                    ViewBag.girisYapmisUserAdi = u.userAdi;
                    var gonderen = Request["gonderenID"];
                    int gonderenId = int.Parse(gonderen);
                    ViewBag.gonderen = gonderenId;
                    foreach (mesajlar mesaj in db.mesajlar)
                    {
                        if ((mesaj.gonderenId == girisYapmisUserId && mesaj.gonderilenId == gonderenID) || (mesaj.gonderilenId == girisYapmisUserId && mesaj.gonderenId == gonderenID))
                        {
                            foreach (user us in db.user)
                            {
                                if (us.userId == mesaj.gonderenId)
                                {
                                    mesajListesi += us.userAdi + ": ";
                                }
                                if(us.userId == gonderenId)
                                {
                                    ViewBag.gonderilenAdi = us.userAdi;
                                }
                            }
                            mesajListesi += mesaj.mesajIcerik + "\r\n";

                        }
                        ViewBag.mesajListesi = mesajListesi;
                    }
                    ViewBag.girisYapmisUserId = girisYapmisUserId;
                }
            }
            /*      projectPaylasimEntities4 db = new projectPaylasimEntities4();
                  var yardimAlan = Session["yardimalanAdi"];
                  string yardimAlanAd = string.Empty;
                  var gonullu = Session["gonulluAdi"];
                  string gonulluAd = string.Empty;
                  if (yardimAlan != null)
                  {
                      yardimAlanAd += yardimAlan.ToString();
                  }

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
                  */


            return View();
        }

        [HttpPost]
        public ActionResult Mesajlasma1(int gonderenId, int gonderilenId, string mesaj, string konu)
        {

            //projectPaylasimEntities4 db = new projectPaylasimEntities4();
            //var yardimAlan = Session["yardimalanAdi"];
            //string yardimAlanAd = string.Empty;
            //string gonulluAd = string.Empty;
            //if (yardimAlan != null)
            //{
            //    yardimAlanAd += yardimAlan.ToString();
            //}
            //var gonullu = Session["gonulluAdi"];
            //if (gonullu != null)
            //{
            //    gonulluAd += gonullu.ToString();
            //}
            //ViewBag.yardimAdi = yardimAlan;

            //ViewBag.gonulluAdi = gonullu;
            //var users = db.user.ToList();

            //foreach (user u in users)
            //{
            //    if (u.userKullaniciAdi == yardimAlanAd)
            //    {
            //        var yardimAlanId = u.userId;
            //        ViewBag.yardimAlanID = yardimAlanId;
            //    }
            //    else if (u.userKullaniciAdi == gonulluAd)
            //    {
            //        var gonulluId = u.userId;
            //        ViewBag.gonulluID = gonulluId;
            //    }
            //}


            var gonderilmeTarihi = DateTime.Now;
            ViewBag.deneme = gonderilenId;

            string sonuc = mesajGonder1(gonderenId, gonderilenId, mesaj, gonderilmeTarihi, konu);

            if (sonuc == "Mesajiniz Gonderildi")
            {
                // return Json(gonderenId + "," + gonderilenId + "," + mesaj + "," + konu);
                //  return RedirectToAction("Index");
                //  TempData["sonuc"] = "Mesajiniz Gonderildi";
                //return RedirectToAction("UrunEkleme", "UrunEkleme");
                TempData["gonderilmeBilgisi"] = "Mesajiniz Gonderildi";
                return RedirectToAction("MesajlariGoruntuleme");
                //  ViewBag.sonucc = "Gonderildi";
            }
            else
            {
                // return Json(",");
                //   TempData["sonuc"] = "Mesajiniz Gonderildi";
                // return View();
                ViewBag.sonucc = "Gonderilemedi";
                return View();
            }
            // return View();
        }




        [HttpPost]
        public ActionResult Mesajlasma(int sender, int receiver, string mesaj, string konu)
        {
            var gonderilmeTarihi = DateTime.Now;
            string sonuc = mesajGonder1(sender, receiver, mesaj, gonderilmeTarihi, konu);
            //   ViewBag.sonuc = sonuc;
            if (sonuc == "Mesajiniz Gonderildi")
            {
                // return Json(gonderenId + "," + gonderilenId + "," + mesaj + "," + konu);
                //  return RedirectToAction("Index");
                TempData["sonuc"] = "Mesajiniz Gonderildi";
                return RedirectToAction("urunGoruntule", "UrunEkleme");
            }
            else
            {
                // return Json(",");
                TempData["sonuc"] = "Mesajiniz Gonderildi";
                return View();
            }
        }

        public string mesajGonder1(int gonderenId, int gonderilenId, string mesaj, DateTime gonderilmeTarihi, string konu)
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

        public ActionResult MesajlariGoruntuleme()
        {
            projectPaylasimEntities4 db = new projectPaylasimEntities4();
            int girisYapmisUserId = 0;
            DateTime mesajinGonderilmeTarihi = DateTime.Now;
            string girisYapmisUserAdi = string.Empty;
            if (Session["gonulluAdi"] != null)
            {
                girisYapmisUserAdi = (string)Session["gonulluAdi"];
            }

            if (Session["yardimAlanAdi"] != null)
            {
                girisYapmisUserAdi = (string)Session["yardimAlanAdi"];
            }

            foreach (user u in db.user)
            {
                if (u.userKullaniciAdi == girisYapmisUserAdi)
                {
                    girisYapmisUserId = u.userId;
                    ViewBag.girisYapmisUserId = girisYapmisUserId;
                    
                }
            }

            var userlar = db.user;

                     return View();
        }
    }
}