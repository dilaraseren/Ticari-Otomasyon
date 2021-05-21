using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Personels.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> p1 = (from x in c.Departmen.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.DepartmanAd,
                                           Value = x.Id.ToString()
                                       }).ToList();
            ViewBag.p2 = p1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorseli = "/Image/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmen.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var prs = c.Personels.Find(p.Id);
            prs.Ad = p.Ad;
            prs.Soyad = p.Soyad;
            prs.PersonelGorseli = p.PersonelGorseli;
            prs.DepartmanId = p.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
                
                
         }

      

    }
}