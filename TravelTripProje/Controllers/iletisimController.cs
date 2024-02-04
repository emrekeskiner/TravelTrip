using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class iletisimController : Controller
    {
        Context context = new Context();
        // GET: iletisim
        public ActionResult iletisim()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MesajEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MesajEkle(iletisim p)
        {
            var mesaj = context.iletisims.Add(p);
            context.SaveChanges();
            return RedirectToAction("iletisim");
        }
    }
}