
#region usingud
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace Suured
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0) Console.WriteLine("mulle antud parameetrid"); /* blokk lauseid*/

            if (false)
            {
                var ehee = "Hobune";
                Console.WriteLine(ehee);
            }
            else if (args.Length > 10) Console.WriteLine("mulle on antud liiga palju");
            else
            {
                var c1 = new Oluline();
            }

            int x = 7;
            while (true)
            {
                Console.WriteLine();

                if (x-- < 0)
                {
                    break; ;
                }
            }
            do
            {
                break;
            } while (true);


            for (var i = 0; i < 10 /*terminator*/  ;  /*iterrator*/   i++)
            {
                Console.WriteLine();
            }


            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    {
                        Console.WriteLine("joome");
                        int uhu = 0;
                        break;
                    }
                case DayOfWeek.Saturday:
                    Console.WriteLine("käime saunas");
                    goto case DayOfWeek.Sunday;
                case DayOfWeek.Tuesday:
                    {
                        Console.WriteLine("teeme poppi");
                        int uhu = 0;
                        break;
                    }
                default:
                    Console.WriteLine("läheme tööle");
                    break;

            }


        }

        static void Miskimuu()
        {
            int ohoo = 0;
            int h = ohoo * ohoo;


        }

    }

    class Teine
    {

    }

    class Hobune
    {

    }
}
