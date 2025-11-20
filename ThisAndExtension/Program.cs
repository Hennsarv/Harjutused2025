using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

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
            WriteLine($"õ={õ} ö={ö}");
            Ehee.Naljakas(ref õ, ref ö);
            Console.WriteLine($"õ={õ} ö={ö}");
            Ehee.Naljakas(ref õ, ref õ);
            Console.WriteLine($"õ={õ} ö={ö}");

            var arvud = new[] { 1, 2, 3, 4, 5, 6, 7 };
            Ehee.LiidaMitu(7, arvud);
            Ehee.Liida(x: 1M, tegur: 2M, y: 3);
            var tulem = arvud.LiidaKokku(); // value tuple

            int ihii = arvud.LiidaKokku().summa;

            Console.WriteLine($"summa tuli {tulem.summa} kokku oli {tulem.mitu}");

            //Tuple<int, string> asi = new Tuple<int, string>(70, "Henn"); // Tuple generic tüüp


            //Func<int, bool> fff = (x) => x > 3;  // see on funktsioon mis ütleb kas int > 3
            //Action<int> aaa = (x) => Console.WriteLine(x);

            arvud.Where((x) => x > 3).ForEach((x) => Console.WriteLine(x));

            // LINQ extensionid
            // .Where()   .Select()    .OrerBy    Take    Skip


            "Henn,Peeter,Toomas,Tiit,Jaagup".Split(',')
                .Skip(2)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            "1,2,3,4,5,6,7,loll,8,9".Split(',')
                .Select(x => int.TryParse(x, out int _x) ? _x : -1)
                .Where(x => x >= 0)
                .Select(x => x*x)
                .ForEach(x => Console.Write($"\t{x}"));

            // LINQ expressionid

            (from i in arvud where i % 2 == 0 select i * i).ForEach(x => Console.WriteLine(x));
            arvud.Where(x => x %2 == 0).Select(x => x*x).ForEach(x => Console.WriteLine(x));

            // Language Integrated Query


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

        public static void Naljakas(ref int a, ref int b) 
        {
            a++; b++;
        }

        public static int Liida(int x, int y) => x + y;
        public static decimal Liida(decimal x, decimal y, decimal tegur = 1) => (x + y) * tegur;
        public static decimal Liida(decimal x, int y) => x + y;
        public static decimal Liida(int x, decimal y) => x + y;
    
        public static int LiidaMitu(int x, params int[] juurde) => x + (juurde.Sum());

        public static (int summa,int mitu) LiidaKokku(this IEnumerable<int> juurde)
        {
            int s = 0; int c = 0;
            foreach (var x in juurde)  (s, c) = (s+x, c+1);
            return (s, c);
        }

        public static bool KasPaaris (int x) => x%2 == 0;
        public static bool KAsJagubKolmega (int x) => x%3 == 0;

        //public static IEnumerable<int> Millised(this IEnumerable<int> arvud, Func<int,bool> pred) 
        //{ 
        //    foreach(var x in arvud) if(pred(x)) yield return x;
        //}

        public static void ForEach<T>(this IEnumerable<T> mass, Action<T> act)
        {
            foreach (var x in mass) { act(x); }
        }

        //public static IEnumerable<T> Take<T>(this IEnumerable<T> mass, int mitu)
        //{
        //    foreach(var x in mass) { if (--mitu < 0) break; yield return x; }
        //}
        //public static IEnumerable<T> Skip<T>(this IEnumerable<T> mass, int mitu)
        //{
        //    foreach (var x in mass) { if (--mitu < 0) yield return x; }
        //}

    }

}
