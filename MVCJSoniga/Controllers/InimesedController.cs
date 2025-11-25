using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;
using MVCJSoniga.Models;

namespace MVCJSoniga.Controllers
{
    public class InimesedController : Controller
    {
        List<Inimene> inimesed = Inimene.Load(HostingEnvironment.MapPath("~/Content/Inimesed.json"));

        public InimesedController()
        {

        }

        // GET: Inimesed
        public ActionResult Index()
        {
            return View(inimesed);
        }

        // GET: Inimesed/Details/5
        public ActionResult Details(int id)
        {
            return View(inimesed.FirstOrDefault(x => x.Id == id));
        }

        // GET: Inimesed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inimesed/Create
        [HttpPost]
        public ActionResult Create(Inimene inimene)
        {
            try
            {
                // TODO: Add insert logic here
                Inimene.Inimesed.Add(inimene);
                Inimene.Save();

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
            return View(inimesed.FirstOrDefault(x => x.Id == id));
        }

        // POST: Inimesed/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Inimene edited)
        {
            try
            {
                // TODO: Add update logic here
                Inimene vana = inimesed.FirstOrDefault(x => x.Id == id);
                if (vana != null)
                {
                    (vana.Name, vana.Vanus) = (edited.Name, edited.Vanus);
                    Inimene.Save();
                }
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

            return View(inimesed.FirstOrDefault(x => x.Id == id));
        }

        // POST: Inimesed/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                inimesed.Remove(inimesed.FirstOrDefault(x => x.Id == id));
                Inimene.Save();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
