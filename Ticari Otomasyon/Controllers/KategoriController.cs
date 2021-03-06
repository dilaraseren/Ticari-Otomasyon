using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;


namespace Ticari_Otomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            c.Kategoris.Add(kategori);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = c.Kategoris.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktg = c.Kategoris.Find(kategori.Id);
            ktg.KategoriAdi = kategori.KategoriAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deneme()
        {
            Cascading cs = new Cascading();
            cs.Kategoriler = new SelectList(c.Kategoris, "Id", "KategoriAdi");
            cs.Urunler = new SelectList(c.Uruns, "Id", "Ad");
            return View(cs);
        }

        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.Kategori.Id equals y.Id
                               where x.Kategori.Id == p
                               select new
                               {
                                   Text = x.Ad,
                                   Value = x.Id.ToString()
                               }).ToList();

            return Json(urunlistesi, JsonRequestBehavior.AllowGet);
        }
    }
}