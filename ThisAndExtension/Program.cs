using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThisAndExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Ahaa
    {
        public int Yks { get; set; }
        public int Kaks { get; set; }

        public int Sum() => Kaks + Yks;

        public static int SumX(Ahaa ahaa) => ahaa.Yks + ahaa.Kaks;

    }

}
