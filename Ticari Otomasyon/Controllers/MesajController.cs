﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        Context c = new Context();
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var mesajlar = c.Mesajs.Where(x => x.Alıcı == mail).OrderByDescending(x => x.Tarih).ToList();
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var mesajlar = c.Mesajs.Where(x => x.Gönderici == mail).OrderByDescending(x => x.Tarih).ToList();
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajs.Where(x => x.MesajId == id).ToList();
            var mail = (string)Session["Mail"];
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajs.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajs.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesaj m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderici = mail;

            c.Mesajs.Add(m);
            c.SaveChanges();
            return View();
        }
    }
}