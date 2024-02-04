using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context context = new Context();
        public ActionResult Index()
        {
            var blogResim = context.Blogs.Take(4).ToList();
            return View(blogResim);
        }

        public ActionResult About()
        {

            return View();
        }

        public PartialViewResult Partial1()
        {
            var degerler = context.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {
            var degerler = context.Blogs.Where(x => x.ID==4).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial3()
        {
            var degerler = context.Blogs.ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial4()
        {
            var degerler = context.Blogs.Take(3).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial5()
        {
            var degerler = context.Blogs.Take(3).OrderByDescending(x=>x.ID).ToList();
            return PartialView(degerler);
        }
    }
}