using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();

        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x => x.StokAdedi).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x => x.StokAdedi <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.SatisFiyati descending select x.Ad).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Uruns orderby x.SatisFiyati ascending select x.Ad).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x => x.Ad == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x => x.Ad == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;

            var deger13 = c.Uruns.Where(u => u.Id == (c.SatisHarekets.GroupBy(x => x.UrunId)
            .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.Ad).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;

            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = deger15;

            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;


            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Caris
                        group x by x.Sehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };

            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };

            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Personels.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                        group x by x.Marka into g
                        select new SinifGrup3
                        {
                            marka = g.Key,
                            sayi = g.Count()
                        };

            return PartialView(sorgu.ToList());
        }

        public PartialViewResult Partial5()
        {
            var sorgu = c.Kategoris.ToList();
            return PartialView(sorgu);
        }
    }
}
