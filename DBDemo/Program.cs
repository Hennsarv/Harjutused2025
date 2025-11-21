using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDemo
{
    internal class Program
    {



        static void Main(string[] args)
        {

            //var t = new { Nimi = "Henn", Vanus = 70, Palk = 1000M };

            //Console.WriteLine(t.GetType().Name);

            //var t2 = new { Nimi = "Henn", Vanus = 70, PalkF = 1000F };
            //Console.WriteLine(t2);


            NorthwindEntities1 db = new NorthwindEntities1();

            // päring LINQ avaldisena
            var q = from prod in db.Products
                    where prod.UnitPrice > 20M
                    orderby prod.UnitPrice
                    select prod.ProductName// new { prod.ProductName, prod.UnitPrice, prod.ProductID }
                    ;

            // päring LINQ extensionitena
            var q1 = db.Products
                .Where(x => x.UnitPrice > 20M)
                .OrderBy(x => x.UnitPrice)
                .Select(x => new { x.ProductName, x.CategoryID, x.UnitPrice });
                ;

            Console.WriteLine(q);
            Console.WriteLine(q1);
            //
            var lq = q1.ToList();
            lq.ForEach(x => Console.WriteLine(x));

            var byCatId = lq.GroupBy(x => x.CategoryID);

            foreach(var cat in byCatId.OrderBy(x => x.Key.HasValue ?  x.Key : 9999999) ) 
            {
                Console.WriteLine($"Categooria nr {cat.Key}");
                foreach(var pro in cat)
                    Console.WriteLine(pro);

                Console.WriteLine("kategooria lõppes\n\n");
            }



            //            //db.Database.Log = System.Console.WriteLine;
            //            var q = db.Products.Where( x => !x.Discontinued)
            //                .Select(x => x.ProductName)
            //                .ToList();
            ////            foreach (var product in q) { Console.WriteLine(product); }

            //            var kalatooted = db.Categories.Find(8);
            //            if(kalatooted != null) { kalatooted.CategoryName = "Seafood"; }
            //            db.SaveChanges();

            //            foreach (var kala in kalatooted.Products

            //                .OrderByDescending(x => x.UnitPrice)

            //                .Select(x => new { x.ProductName, x.UnitPrice, x.ProductID, x.Laoseis }))
            //            {
            //                Console.WriteLine(kala);
            //                db.Products.Find(kala.ProductID).UnitPrice /= 2;
            //            }
            //            db.SaveChanges();
        }
    }

    partial class Product
    {
        public Decimal Laoseis => UnitPrice.Value * UnitsInStock.Value;
    }

}
