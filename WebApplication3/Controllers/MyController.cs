using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MyController : Controller
    {
        protected northwindEntities1 db = new northwindEntities1("Pa$$w0rd");


    }
}