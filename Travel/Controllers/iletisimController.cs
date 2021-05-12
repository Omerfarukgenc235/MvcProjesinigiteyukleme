using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models.Siniflar;
namespace Travel.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Iletisim()
        {
            var degerler = c.iletisims.ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Iletisim(iletisim y)
        {
            c.iletisims.Add(y);
            c.SaveChanges();
            return View();
        }
    }
}