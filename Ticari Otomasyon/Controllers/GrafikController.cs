using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult GoogleChart()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Chart> UrunListesi()
        {
            List<Chart> snf = new List<Chart>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new Chart
                {
                    urunad = x.Ad,
                    stok = x.StokAdedi
                }).ToList();
            }

            return snf;

        }

        public ActionResult GoogleChart1()
        {
            return View();
        }

        public ActionResult GoogleChart2()
        {
            return View();
        }

    }
}