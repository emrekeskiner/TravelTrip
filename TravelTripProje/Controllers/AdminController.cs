using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult YeniBlog()
        {
           
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult YeniBlog(Blog p1)
        {
            context.Blogs.Add(p1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogSil(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogGetir(int id)
        {
            var blog = context.Blogs.Find(id);
            
            return View(blog);
        }
        [Authorize]
        public ActionResult BlogGuncelle(Blog p)
        {
            var blog = context.Blogs.Find(p.ID);
            blog.Aciklama = p.Aciklama;
            blog.Baslik = p.Baslik;
            blog.Tarih = p.Tarih;
            blog.BlogImage = p.BlogImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var degerler = context.Yorumlars.ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(yorum);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult YorumGetir(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            
            return View(yorum);
        }
        [Authorize]
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yorum = context.Yorumlars.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult iletisim()
        {
            var degerler = context.iletisims.ToList();

            return View(degerler);
        }

        [Authorize]
        public ActionResult Hakkimizda()
        {
            var degerler = context.Hakkimizdas.FirstOrDefault();

            return View(degerler);
        }

        [Authorize]
        public ActionResult HakkimizdaGuncelle(Hakkimizda p)
        {
            var hakkimizda = context.Hakkimizdas.Find(p.ID);
            hakkimizda.FotoUrl = p.FotoUrl;
            hakkimizda.Aciklama = p.Aciklama;
            context.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
    }
}