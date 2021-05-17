using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            UrunDetay ud = new UrunDetay();
            // var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            ud.Deger1 = c.Uruns.Where(x => x.Id == 1).ToList();
            ud.Deger2 = c.Detays.Where(y => y.DetayId == 1).ToList();
            return View(ud);

        }
    }
}