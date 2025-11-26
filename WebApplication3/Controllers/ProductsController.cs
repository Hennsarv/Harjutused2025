using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WebApplication3.Models
{
    [MetadataType(typeof(ProductMetadata))]
    partial class Product
    {
        public decimal Laoseis => (this.UnitPrice.HasValue ? this.UnitPrice.Value : 0) * (this.UnitsInStock.HasValue ? this.UnitsInStock.Value : 0) ;
    }
    
    public class ProductMetadata
    {
        [Display(Name ="Tootenimi")]
        public string ProductName { get; set; }
    }

    partial class northwindEntities1
    {
        public northwindEntities1(string pwd)
    : base("name=northwindEntities1")
        {
            var conn = (System.Data.SqlClient.SqlConnection)this.Database.Connection;
            var cs = new System.Data.SqlClient.SqlConnectionStringBuilder(conn.ConnectionString);
            cs.Password= pwd;
            conn.ConnectionString = cs.ToString();
        }
    }
}


namespace WebApplication3.Controllers
{

    public class ProductsController : MyController
    {
        //private northwindEntities1 db = new northwindEntities1("Pa$$w0rd");

        // GET: Products
        public ActionResult Index(string sortby = "ProductId", string direction = "Up")
        {
            //var products = db.Products.ToList().OrderBy(x => x.ProductID); //.ToList();

            ViewBag.sortby = sortby;
            ViewBag.direction = direction;

            var sort = sortby+direction;

            var products = db.Products;  //.OrderBy(x => x)   .AsEnumerable();
                
            var sortedproducts =
                  sort == "UnitPriceUp" ? products.OrderBy(x => x.UnitPrice)
                : sort == "ProductNameUp" ? products.OrderBy(x => x.ProductName)
                :  sort == "UnitPriceDown" ? products.OrderByDescending(x => x.UnitPrice)
                : sort == "ProductNameDown" ? products.OrderByDescending(x => x.ProductName)
                : products.OrderBy(x => x.ProductID);


            return View(sortedproducts);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,State")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,State")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
