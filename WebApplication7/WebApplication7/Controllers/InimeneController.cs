using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class InimeneController : Controller
    {
        public static List<Inimene> Inimesed = new List<Inimene>();

        // GET: Inimene
        public ActionResult Index()
        {
            return View(Inimesed);
        }

        // GET: Inimene/Details/5
        public ActionResult Details(int id)
        {
            Inimene inimene = Inimesed.FirstOrDefault(x => x.Id == id);
            return View(inimene);
        }

        // GET: Inimene/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inimene/Create
        [HttpPost]
        public ActionResult Create(Inimene inimene)
        {
            try
            {
                inimene.Id = 
                    Inimesed.Count() == 0 ? 1 :
                    
                    Inimesed.Max(x => x.Id)+1;

                Inimesed.Add(inimene);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inimene/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inimene/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inimene/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inimene/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
