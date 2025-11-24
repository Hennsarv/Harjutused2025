using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIsOnEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var henn = new Inimene { Nimi = "Henn", Vanus = 70 };
            var ants = new Inimene { Nimi = "Ants", Vanus = 60 };

            //henn.Vananes += (x) => Console.WriteLine($"{x.Nimi} sai vanemaks");
            //henn.Vananes += (x) => Console.WriteLine($"Soovime õnne sulle {x.Nimi}");

            ants.Pension += (x) => Console.WriteLine( $"ahoi {x} sul on aeg pensionile minna");
            henn.Juubel += (x) => Console.WriteLine( $"{x.Nimi} me kingime sulle nimelise kella juubli puhul");

            for (int i = 0; i < 20; i++)
            {
                henn.Vanus++;
                ants.Vanus++;
            }


            Console.WriteLine(henn);
            Console.WriteLine(ants);

        }
    }

    class Inimene
    {
        private int _vanus = 0;

        public event Action<Inimene> Vananes;
        public Action<Inimene> Juubel;
        public Action<Inimene> Pension;



        public string Nimi { get; set; }
        public int Vanus { get => _vanus; set {
                _vanus = value > _vanus ? value : _vanus;
                Vananes?.Invoke(this);

                if (this.Vanus % 25 == 0) Juubel?.Invoke(this);

                if (this.Vanus > 63) Pension?.Invoke(this);


            } }

        public override string ToString() => $"Inimene {Nimi} {Vanus} aastat vana";
    }
}
