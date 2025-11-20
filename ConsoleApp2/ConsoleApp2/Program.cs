using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            northwindEntities ne = new northwindEntities();
            ne.Products.Select(x => new {x.ProductName, x.UnitPrice}).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
