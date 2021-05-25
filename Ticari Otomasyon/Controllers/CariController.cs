using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Caris.Where(x => x.Durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult YeniCari(Cari p)
        {
            p.Durum = true;
            c.Caris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CariSil(int id) 
        {

            var p = c.Caris.Find(id);
            p.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id )
        {
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cari p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Caris.Find(p.Id);
            cari.Ad = p.Ad;
            cari.Soyad = p.Soyad;
            cari.Sehir = p.Sehir;
            cari.Mail = p.Mail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cr = c.Caris.Where(x => x.Id == id).Select(y => y.Ad + " " + y.Soyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);

        }

    }
}