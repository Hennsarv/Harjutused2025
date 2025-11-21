using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnummideMaailm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            var kaardid = Enumerable.Range(0, 52).OrderBy(x => R.NextDouble());
            int ix = 0;
            Console.WriteLine(kaardid
                .Select(x => $"\t{(Mast)(x/13)} {(Kaart)(x%13)} {(ix++%4 == 3 ? "\n":"")}")
                .Join(""));

            ix = 0;
            var käed = kaardid.ToLookup(x => (ix++)%4).Select(x => x.OrderBy(y => y).Select(y => y.AsCard()).ToArray()).ToArray();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"\t{käed[j][i]}");
                }
                Console.WriteLine();
            }

        }
    }

    enum Mast { Risti, Ruutu, Ärtu, Poti, Pada = 3 }
    enum Kaart { Kaks , Kolm, Neli, Viis, Kuus, Seitse, Kaheksa, Üheksa, Kümme, Soldat, Emand, Kuningas, Äss}

    [Flags] enum Omadus { Punane = 1, Suur = 2, Puust = 4, Kolisev = 8, Hiilgav = 16, Sõjaveteran = 23}

    static class E
    {
        public static string Join<T>(this IEnumerable<T> mass, string sep) => string.Join(sep, mass);

        public static string AsCard(this int k) => $"{(Mast)(k/13)} {(Kaart)(k%13)}";
    }

}
