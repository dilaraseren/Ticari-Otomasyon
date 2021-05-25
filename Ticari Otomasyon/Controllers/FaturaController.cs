using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return View();
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);

        }

        public ActionResult FaturaGuncelle(Fatura f)
        {
            var fatura = c.Faturas.Find(f.Id);
            fatura.SeriNo = f.SeriNo;
            fatura.SiraNo = f.SiraNo;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {

            var fatura = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            var ftr = c.Faturas.Where(x => x.Id == id).Select(y => y.SeriNo + " " + y.SiraNo).FirstOrDefault();
            ViewBag.ftrs = ftr;
            return View(fatura);

        }


        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

      
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Dinamik()
        {
            Dinamik d = new Dinamik();
            d.deger1 = c.Faturas.ToList();
            d.deger2 = c.FaturaKalems.ToList();
            return View(d);
        }

        public ActionResult FaturaKaydet(string SeriNo, string SiraNo, DateTime Tarih, string VergiDairesi,
            string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {
            Fatura f = new Fatura();
            f.SeriNo = SeriNo;
            f.SiraNo = SiraNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturas.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.FaturaId = x.Id;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}