using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Siniflar;
namespace Travel.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
      
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            blg.Kategoriid = b.Kategoriid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi(Blog b)
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            return View("YorumGetir", yrm);             
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrmlr = c.Yorumlars.Find(y.ID);
            yrmlr.KullaniciAdi = y.KullaniciAdi;
            yrmlr.Mail = y.Mail;
            yrmlr.Yorum = y.Yorum;           
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult Iletisimlistele(iletisim d)
        {
            var iltsm = c.iletisims.ToList();
            return View(iltsm);
        }
        [Authorize]
        public ActionResult IletisimSil(int id)
        {
            var b = c.iletisims.Find(id);
            c.iletisims.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Iletisimlistele");
        }
        [Authorize]
        public ActionResult IletisimGetir(int id)
        {
            var ilets = c.iletisims.Find(id);
            return View("IletisimGetir", ilets);
        }
        [Authorize]
       
        public ActionResult HakkimizdaListele()
        {
            var hakkimizda = c.Hakkimizdas.ToList();
            return View(hakkimizda);
        }
        [Authorize]
        public ActionResult HakkimizdaGetir(int id)
        {
            var yrm = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", yrm);
        }
        [Authorize]
        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hkmda = c.Hakkimizdas.Find(h.ID);
            hkmda.FotoUrl = h.FotoUrl;
            hkmda.Aciklama = h.Aciklama;
            c.SaveChanges();
            return RedirectToAction("HakkimizdaListele");
        }
        [Authorize]
        public ActionResult HakkimizdaSil(int id)
        {
            var b = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(b);
            c.SaveChanges();
            return RedirectToAction("HakkimizdaListele");
        }
    }
}
