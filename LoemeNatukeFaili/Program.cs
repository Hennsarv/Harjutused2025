using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LoemeNatukeFaili
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string dirName = @"C:\Users\sarvi\OneDrive\PowerBI\sqlcsv";

            string prodFile = @"..\..\Data\products.csv";
            string[] read = File.ReadAllLines(prodFile);


            var nimed = read[0].Split(',');
            int iNimetus = 0;
            int iHind = 0;
            int iKogus = 0;
            int iCatid = 0;
            for (int j = 0; nimed.Length > j; j++) 
            {
                if (nimed[j].Contains("ProductName")) iNimetus = j;
                if (nimed[j].Contains("UnitPrice")) iHind = j;
                if (nimed[j].Contains("UnitsInStock")) iKogus = j;
                if (nimed[j].Contains("Category")) iCatid= j;
            }

            decimal summa = 0;
            //Console.WriteLine("Toode"+new string(' ', 55)+"Hind     "+ "Kogus     ");
            var tooteList = read.Skip(1)
                .Where(x => x.Length > 5)
                .Select(x => x.Replace(@""",", ";").Replace(@"""", ""))
                .Select(x => x.Split(';'))
                .Select(x => new
                {
                    Catid = int.TryParse(x[iCatid], out int _cat) ? _cat : 0, 
                    Nimetus = x[iNimetus],
                    Hind = decimal.TryParse(x[iHind], out decimal _hind) ? _hind : 0,
                    Kogus = decimal.TryParse(x[iKogus], out decimal _kogus) ? _kogus : 0,
                })
                .ToList();
                ;
            //tooteList.ForEach(x => Console.WriteLine(x));

            var byCat = tooteList.ToLookup(x => x.Catid);
            foreach (var cat in byCat) 
            { 
                Console.WriteLine($"Kategooria: {cat.Key}");
                foreach (var pro in cat) Console.WriteLine(pro);

                var tooteid = cat.Count();
                var laoseis = cat.Sum(x => x.Hind * x.Kogus);

                Console.WriteLine($"selle cat-s on {tooteid} toodet ja laos neid {laoseis} raha eest");

            }


            #region Vana Versioon
            //for(int i = 1; i < 0; i++) //  read.Length; i++)
            //{
            //    try
            //    {
            //        var osad = read[i].Replace(@""",", @""";").Split(';'); // asendame ", ";
            //                                                               //if (osad.Length < 2) continue;

            //        string nimetus = osad[iNimetus].Replace(@"""", ""); // eemaldame jutumärgid
            //        decimal hind = decimal.TryParse(osad[iHind].Replace(@"""", ""), out decimal _h) ? _h : 0;
            //        decimal kogus = decimal.TryParse(osad[iKogus].Replace(@"""", ""), out decimal _k) ? _k : 0;
            //        int catid = int.TryParse(osad[iCatid].Replace(@"""", ""), out int _c) ? _c : 0;
            //        summa += hind * kogus;
            //        Console.WriteLine($"{nimetus}{new string(' ', 60 - nimetus.Length)}{hind,10:F2}{kogus,10:F2}");



            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine($"vigane rida:{e.Message}");
            //        throw e;
            //    }  
            //    finally
            //    {
            //        Console.WriteLine("aga muidu on kõik OK");
            //    }

            //}
            //Console.WriteLine(new string('_',70));
            //Console.WriteLine($"{new string(' ', 60)}{summa,10:F2}" );

            #endregion




        }
    }
}
