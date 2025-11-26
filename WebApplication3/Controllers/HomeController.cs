using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Change(string tabel, string field, string value, int id)
        {
            if(tabel == "Inimene") {
                if(field == "Nimi")
                {
                    Inimene inimene = Inimene.Inimesed.FirstOrDefault(x => x.Id == id);
                    if (inimene != null) inimene.Nimi = value;
 
                }
            }
            return Json(new { ok = true, message = "korrus"});
                
        }

    }
}