using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public static class E
    {
        internal static List<Category> categories = null;

        public static Category Category(this int categoryId) => categories.FirstOrDefault(x => x.CategoryID == categoryId);

    }



    public class MyController : Controller
    {
        protected northwindEntities1 db = new northwindEntities1("Pa$$w0rd");

        
        protected List<Category> Categories => E.categories ?? (E.categories = db.Categories.ToList());
        protected void ResetCategories() => E.categories = null;
        // LAzy initialized puhver

    }
}