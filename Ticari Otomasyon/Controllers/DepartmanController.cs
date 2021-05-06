using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var dpr = c.Departmen.Where(x => x.Durum == true).ToList();
            return View(dpr);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            c.Departmen.Add(departman);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DepartmanSil(int id)
        {
            var dp = c.Departmen.Find(id);
            dp.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dpr = c.Departmen.Find(id);
            return View("DepartmanGetir", dpr);
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dpr = c.Departmen.Find(departman.Id);
            dpr.DepartmanAd = departman.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var dgr = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = c.Departmen.Where(x => x.Id == id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(dgr);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personel = c.Personels.Where(x => x.Id == id).Select(y => y.Ad +" "+ y.Soyad).FirstOrDefault();
            ViewBag.dpers = personel;
            return View(degerler);
        }
    }
}