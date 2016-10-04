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
            //  projectPaylasimEntities4 db = new projectPaylasimEntities4();
            projectPaylasimEntities6 db = new projectPaylasimEntities6();
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

            foreach (user u in db.users)
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
            projectPaylasimEntities6 db = new projectPaylasimEntities6();
            int girisYapmisUserId = 0;
            string mesajListesi = string.Empty;
            string girisYapmisUserAdi = string.Empty;
            string girisliUserAdi = string.Empty;
            string gonderenUserId = string.Empty;
            string gonderenUserAdi = string.Empty;
            var gonderen = Request["gonderenID"];
            int gonderenId = int.Parse(gonderen);
            ViewBag.gonderen = gonderenId;
            string mesajGonderenId = string.Empty;
            string mesajGonderilenId = string.Empty;
            int listeUzunlugu = 0;
            if (Session["gonulluAdi"] != null)
            {
                girisYapmisUserAdi = (string)Session["gonulluAdi"];
            }

            if (Session["yardimAlanAdi"] != null)
            {
                girisYapmisUserAdi = (string)Session["yardimAlanAdi"];
            }

            foreach (user u in db.users)
            {
                if (u.userKullaniciAdi == girisYapmisUserAdi)
                {
                    girisYapmisUserId = u.userId;
                    ViewBag.girisYapmisUserId = girisYapmisUserId;
                    ViewBag.girisYapmisUserAdi = u.userAdi;
                }
            }

            foreach (user u in db.users)
            {
                if (u.userId == gonderenId)
                {
                    gonderenUserAdi = u.userAdi;
                    ViewBag.gonderenUserAdi = gonderenUserAdi;
                }
            }


            foreach (mesajlar mesaj in db.mesajlars)
            {
                if ((mesaj.gonderenId == girisYapmisUserId && mesaj.gonderilenId == gonderenID) || (mesaj.gonderilenId == girisYapmisUserId && mesaj.gonderenId == gonderenID))
                {
                    //foreach (user us in db.users)
                    //{
                    //    if (us.userId == mesaj.gonderenId)
                    //    {
                    //        mesajListesi += us.userAdi + ": ";
                    //    }
                    //    if (us.userId == gonderenId)
                    //    {
                    //        ViewBag.gonderilenAdi = us.userAdi;
                    //    }
                    //}

                    if (mesaj.gonderenId == gonderenId)
                    {
                        mesajListesi += gonderenUserAdi + " : ";
                    }
                    if (mesaj.gonderenId == girisYapmisUserId)
                    {
                        mesajListesi += ViewBag.girisYapmisUserAdi + " : ";
                    }
                    Convert.ToString(mesaj.gonderenId);
                    mesajGonderenId = mesaj.gonderenId + ",";
                    Convert.ToString(mesaj.gonderilenId);
                    mesajGonderilenId = mesaj.gonderilenId + ",";

                    mesajListesi += mesaj.mesajIcerik + "\r\n";

                }
                // ViewBag.mesajListesi = mesajListesi;
            }
            ViewBag.mesajListesi = mesajListesi;
            //foreach (user us in db.users)
            //{
            //    listeUzunlugu = mesajListesi.Count();
            //    //if (us.userId == mesaj.gonderenId)
            //    //{
            //    //    mesajListesi += us.userAdi + ": ";
            //    //}
            //    //if (us.userId == gonderenId)
            //    //{
            //    //    ViewBag.gonderilenAdi = us.userAdi;
            //    //}
            //}

            //        foreach (mesajlar mesaj in db.mesajlars)
            //        {
            //            if ((mesaj.gonderenId == girisYapmisUserId && mesaj.gonderilenId == gonderenID) || (mesaj.gonderilenId == girisYapmisUserId && mesaj.gonderenId == gonderenID))
            //            {
            //                foreach (user us in db.users)
            //                {
            //                    if (us.userId == mesaj.gonderenId)
            //                    {
            //                        mesajListesi += us.userAdi + ": ";
            //                    }
            //                    if(us.userId == gonderenId)
            //                    {
            //                        ViewBag.gonderilenAdi = us.userAdi;
            //                    }
            //                }
            //                mesajListesi += mesaj.mesajIcerik + "\r\n";

            //            }
            //            ViewBag.mesajListesi = mesajListesi;
            //        }
            //        ViewBag.girisYapmisUserId = girisYapmisUserId;
            //    }
            //}
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

        //[HttpPost]
        //public ActionResult Mesajlasma1(int gonderenId, int gonderilenId, string mesaj, string konu)
        //{

        //    var gonderilmeTarihi = DateTime.Now;
        //    string sonuc = mesajGonder1(gonderenId, gonderilenId, mesaj, gonderilmeTarihi, konu);

        //    if (sonuc == "Mesajiniz Gonderildi")
        //    {
        //        TempData["gonderilmeBilgisi"] = "Mesajiniz Gonderildi";
        //        return RedirectToAction("MesajlariGoruntuleme");
        //    }
        //    else
        //    {
        //        ViewBag.sonucc = "Gonderilemedi";
        //        return View();
        //    }
        //}




        [HttpPost]
        public ActionResult Mesajlasma(int sender, int receiver, string mesaj, string konu)
        {
            var gonderilmeTarihi = DateTime.Now;
            string sonuc = mesajGonder1(sender, receiver, mesaj, gonderilmeTarihi, konu);
            if (sonuc == "Mesajiniz Gonderildi")
            {
                TempData["sonuc"] = "Mesajiniz Gonderildi";
                return RedirectToAction("urunGoruntuleForYardimAlan", "UrunEkleme");
            }
            else
            {
                TempData["sonuc"] = "Mesajiniz Gonderildi";
                return View();
            }
        }

        public class Item
        {
            public string urunAdi { get; set; }
            public string urunSahibiAdi { get; set; }
            public string urunDurumu { get; set; }
            //public Status status { get; set; }

            //public enum Status
            //{
            //    Reserved,
            //    Available
            //}
        }


        //List<Item> items = new List<Item>();
        //public ActionResult ListeyeEkle(int urunSahibiId, int urunId, string urunAdi, int yardimAlanId, string yardimAlanAd)
        //{
        //    string urunSahibiAdi = "gamze";
        //    string urunDurumu = "2";
        //    Item item1 = new Item();
        //    item1.urunAdi = urunAdi;
        //    item1.urunSahibiAdi = urunSahibiAdi;
        //    item1.urunDurumu = urunDurumu;


        //    items.Add(item1);

        //    DateTime gonderilmeTarihi = DateTime.Now;
        //    string mesaj = yardimAlanAd + " adli kullanici " + urunId + " idye sahip " + urunAdi + " urununuzu rezerv etti.";
        //    string konu = "Urun Rezervesi - Onay";
        //    string sonuc = mesajGonder1(yardimAlanId, urunSahibiId, mesaj, gonderilmeTarihi, konu);
        //    return RedirectToAction("urunGoruntuleForYardimAlan","UrunEkleme");
        //}

        List<Item> items = new List<Item>();
        public ActionResult ListeyeEkle(int urunSahibiId, int urunId, string urunAdi, int yardimAlanId, string yardimAlanAd)
        {
            string urunSahibiAdi = "gamze";
            int sistemID = 3;
            projectPaylasimEntities6 db = new projectPaylasimEntities6();
            var urun1 = db.uruns.Single(x => x.urunId == urunId);
            urun1.urunDurumu = "2";
            db.SaveChanges();


            Item item1 = new Item();
            item1.urunAdi = urunAdi;
            item1.urunSahibiAdi = urunSahibiAdi;
            item1.urunDurumu = "2";


            items.Add(item1);

            DateTime gonderilmeTarihi = DateTime.Now;
            string mesaj = yardimAlanAd + " adli kullanici " + urunId + " idye sahip " + urunAdi + " urununuzu rezerv etti.";
            string konu = "Urun Rezervesi - Onay";
            string sonuc = mesajGonder1(sistemID, urunSahibiId, mesaj, gonderilmeTarihi, konu);
            return RedirectToAction("urunGoruntuleForYardimAlan", "UrunEkleme");
        }

        public string mesajGonder1(int gonderenId, int gonderilenId, string mesaj, DateTime gonderilmeTarihi, string konu)
        {
            try
            {
                projectPaylasimEntities6 database = new projectPaylasimEntities6();
                mesajlar mesaj1 = new mesajlar();
                mesaj1.gonderenId = gonderenId;
                mesaj1.gonderilenId = gonderilenId;
                mesaj1.mesajIcerik = mesaj;
                mesaj1.mesajKonusu = konu;
                mesaj1.gonderilmeTarihi = gonderilmeTarihi;
                database.mesajlars.Add(mesaj1);
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
            projectPaylasimEntities6 db = new projectPaylasimEntities6();
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
            var users = db.users.ToList();
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
            var mesajListesi = db.mesajlars.ToList();
            ViewBag.mesajListesi = mesajListesi;

            return View();
        }


        [HttpPost]
        public ActionResult mesajiGonderme(string kimden, string kime, string mesajKonusu, string mesajIcerik)
        {
            projectPaylasimEntities6 database = new projectPaylasimEntities6();
            mesajlar gonderilcekMesaj = new mesajlar();
            gonderilcekMesaj.gonderenId = Convert.ToInt32(kimden);
            gonderilcekMesaj.gonderilenId = Convert.ToInt32(kime);
            gonderilcekMesaj.mesajIcerik = mesajIcerik;
            gonderilcekMesaj.mesajKonusu = mesajKonusu;
            gonderilcekMesaj.gonderilmeTarihi = DateTime.Now;
            database.mesajlars.Add(gonderilcekMesaj);
            database.SaveChanges();
            return RedirectToAction("MesajlariGoruntule");
        }

        public ActionResult MesajlariGoruntuleme()
        {
            projectPaylasimEntities6 db = new projectPaylasimEntities6();
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

            foreach (user u in db.users)
            {
                if (u.userKullaniciAdi == girisYapmisUserAdi)
                {
                    girisYapmisUserId = u.userId;
                    ViewBag.girisYapmisUserId = girisYapmisUserId;

                }
            }

            var userlar = db.users;

            return View();
        }
    }
}