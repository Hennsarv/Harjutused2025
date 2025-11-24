using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinuLibrary;

namespace ClientServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("kes sa oled: ");
            var nimi = Console.ReadLine();
            var teine = new MinuKlass();
            var vastus = teine.Teretamine( nimi );
            Console.WriteLine( vastus );
        }
    }
}
