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
            // uus näide 

            Ahaa ahaa = new Ahaa { Yks = 4, Kaks = 7 };
            Console.WriteLine(ahaa.Sum());
            Console.WriteLine(Ahaa.SumX(ahaa));
            
            // need kaks rida teevad TÄPSELT üht ja sama
            Console.WriteLine(Ehee.SumY(ahaa));
            Console.WriteLine(ahaa.SumY());

            //"..\\..\\Program.cs".ReadAllLines().ToList().ForEach(x => Console.WriteLine(x));

            int õ = 7; int ö = 8;
            Console.WriteLine($"õ={õ} ö={ö}");
            Ehee.Naljakas(ref õ, ref ö);
            Console.WriteLine($"õ={õ} ö={ö}");
            Ehee.Naljakas(ref õ, ref õ);
            Console.WriteLine($"õ={õ} ö={ö}");


        }
    }

    class Ahaa
    {
        public int Yks { get; set; }
        public int Kaks { get; set; }

        public int Sum() => this.Kaks + this.Yks;

        public static int SumX(Ahaa ahaa) => ahaa.Yks + ahaa.Kaks;

    }

    static class Ehee
    {
        public static int SumY(this Ahaa ahaa) => ahaa.Yks + ahaa.Kaks;

        public static string[] ReadAllLines(this string filename) => System.IO.File.ReadAllLines(filename);

        public static void Naljakas (ref int a, ref int b)
        {
            a++; b++;
        }

    }

}
