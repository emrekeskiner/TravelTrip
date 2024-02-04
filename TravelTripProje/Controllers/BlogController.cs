using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        Context context = new Context();
        BlogYorum blogYorum = new BlogYorum();
        public ActionResult Index()
        {
            blogYorum.Deger1 = context.Blogs.ToList();
            blogYorum.Deger3 = context.Blogs.Take(3).OrderByDescending(x=>x.Tarih).ToList();
           // var bloglar = context.Blogs.ToList();
            return View(blogYorum);
        }

        
        public ActionResult BlogDetay(int id)
        {
            // var blogbul = context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Deger1 = context.Blogs.Where(x => x.ID == id).ToList();
            blogYorum.Deger2 = context.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(blogYorum);
        }



        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            context.Yorumlars.Add(y);
            context.SaveChanges();
            return PartialView();
        }
    }
}