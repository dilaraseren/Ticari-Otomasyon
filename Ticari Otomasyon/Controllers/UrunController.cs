using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.Ad.Contains(p));
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> p1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAdi,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.p2 = p1;
            return View();

        }

        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunSil(int id)
        {
            var p = c.Uruns.Find(id);
            p.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id) 
        {
            List<SelectListItem> p1 = (from x in c.Kategoris.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.KategoriAdi,
                                           Value = x.Id.ToString()
                                       }).ToList();
            ViewBag.p2 = p1;
            var u = c.Uruns.Find(id);
            return View("UrunGetir", u);
        }


        public ActionResult UrunGuncelle(Urun p) 
        {
            var urun = c.Uruns.Find(p.Id);
            urun.UrunGorseli = p.UrunGorseli;
            urun.StokAdedi = p.StokAdedi;
            urun.SatisFiyati = p.SatisFiyati;
            urun.Marka = p.Marka;
            urun.AlısFiyati = p.AlısFiyati;
            urun.Durum = p.Durum;
            urun.Ad = p.Ad;
            urun.KategoriId = p.KategoriId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var deger = c.Uruns.ToList();
            return View(deger);
        }
     
            
    }   
}