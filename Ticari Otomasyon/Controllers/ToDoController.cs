using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticari_Otomasyon.Models.Classes;

namespace Ticari_Otomasyon.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.Caris select x.Sehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;


            var todo = c.toDoLists.ToList();



            return View(todo);
        }
    }
}