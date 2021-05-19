using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var values = c.Caris.FirstOrDefault(x => x.Mail == mail);
            ViewBag.m = mail;
            return View(values);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["Mail"];
            var id = c.Caris.Where(x => x.Mail == mail.ToString()).Select(y => y.Id).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }


    }
}