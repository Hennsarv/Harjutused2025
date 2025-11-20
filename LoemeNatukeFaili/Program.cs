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
            for (int j = 0; nimed.Length > j; j++) 
            {
                if (nimed[j].Contains("ProductName")) iNimetus = j;
                if (nimed[j].Contains("UnitPrice")) iHind = j;
                if (nimed[j].Contains("UnitsInStock")) iKogus = j;
            }

            decimal summa = 0;
            Console.WriteLine("Toode"+new string(' ', 55)+"Hind     "+ "Kogus     ");
            for(int i = 1; i <  read.Length; i++)
            {

                

                try
                {
                    var osad = read[i].Replace(@""",", @""";").Split(';'); // asendame ", ";
                                                                           //if (osad.Length < 2) continue;

                    string nimetus = osad[iNimetus].Replace(@"""", ""); // eemaldame jutumärgid
                    decimal hind = decimal.TryParse(osad[iHind].Replace(@"""", ""), out decimal _h) ? _h : 0;
                    decimal kogus = decimal.TryParse(osad[iKogus].Replace(@"""", ""), out decimal _k) ? _k : 0;
                    summa += hind * kogus;
                    Console.WriteLine($"{nimetus}{new string(' ', 60 - nimetus.Length)}{hind,10:F2}{kogus,10:F2}");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"vigane rida:{e.Message}");
                    throw e;
                }  
                finally
                {
                    Console.WriteLine("aga muidu on kõik OK");
                }
            
            }
            Console.WriteLine(new string('_',70));
            Console.WriteLine($"{new string(' ', 60)}{summa,10:F2}" );



            

        }
    }
}
