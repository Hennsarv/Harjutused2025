using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class InimesedController : Controller
    {
        

        // GET: Inimesed
        public ActionResult Index()
        {
            Inimene.Init();
            return View(Inimene.Inimesed);
        }

        // GET: Inimesed/Details/5
        public ActionResult Details(int id)
        {
            var inimene = Inimene.Inimesed.Where(x => x.Id == id).SingleOrDefault();
            return View(inimene);
        }

        // GET: Inimesed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inimesed/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Inimene.Inimesed.Add(new Inimene { Nimi = collection["Nimi"], Vanus = int.Parse(collection["Vanus"]) });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inimesed/Edit/5
        public ActionResult Edit(int id)
        {
            var inimene = Inimene.Inimesed.Where(x => x.Id == id).SingleOrDefault();
            return View(inimene);
        }

        // POST: Inimesed/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Inimene editable)
        {
            try
            {
                // TODO: Add update logic here
                var inimene= Inimene.Inimesed.Where(x => x.Id == id).SingleOrDefault();
                if (inimene != null) { inimene.Nimi = editable.Nimi; inimene.Vanus = editable.Vanus; }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inimesed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inimesed/Delete/5
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
