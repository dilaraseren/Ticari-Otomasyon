using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var values = c.Mesajs.Where(x => x.Alıcı== mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Caris.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.CariId == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = c.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => (decimal?)y.ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
            var toplamurunsayisi = c.SatisHarekets.Where(x => x.CariId == mailid).Sum(y => (decimal?)y.Adet);
            ViewBag.toplamurunsayisi = toplamurunsayisi;
            var adsoyad = c.Caris.Where(x => x.Mail == mail).Select(y => y.Ad + " " + y.Soyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View(values);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["Mail"];
            var id = c.Caris.Where(x => x.Mail == mail.ToString()).Select(y => y.Id).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var mesajlar = c.Mesajs.Where(x => x.Alıcı == mail).OrderByDescending(x => x.MesajId).ToList();
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var mesajlar = c.Mesajs.Where(x => x.Gönderici == mail).OrderByDescending(x => x.MesajId).ToList();
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajs.Where(x => x.MesajId == id).ToList();
            var mail = (string)Session["Mail"];
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["Mail"];
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesaj m)
        {
            var mail = (string)Session["Mail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderici = mail;
            c.Mesajs.Add(m);
            c.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;

            k = k.Where(y => y.TakipKodu.Contains(p));

            return View(k.ToList());
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["Mail"];
            var id = c.Caris.Where(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
            var caribul = c.Caris.Find(id);
            return PartialView("Partial1",caribul);
        }

        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajs.Where(x => x.Gönderici == "admin").ToList();
            return PartialView(veriler);
        }

        public ActionResult CariBilgiGuncelle(Cari cr)
        {
            var cari = c.Caris.Find(cr.Id);
            cari.Ad = cr.Ad;
            cari.Soyad = cr.Soyad;
            cari.Sifre = cr.Sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}