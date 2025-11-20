using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassJaProperty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inimene henn = new Inimene { Nimi = "Henn" , Vanus = 70 };

            henn.Vanus++;

            henn.Vanus--;
            int hennuvanus = henn.Vanus;

            Console.WriteLine(henn);

            Console.WriteLine(Inimene.RahvaArv);

            foreach (var i in Inimene.Inimesed) Console.WriteLine(i);

            //            foreach(var x in MinuList()) Console.WriteLine(x);

            int[] palgad = { 1000, 255, 3000, 199 };
            foreach(var p in PaarisList(palgad)) Console.WriteLine(p);


        }

        static IEnumerable<int> PaarisList(IEnumerable<int> arvud)
        {
            
            foreach (var i in arvud) { if(i % 2 == 0) yield return i; }
        }

    }

    class Inimene
    {
        private int _vanus = 0;

        public int Vanus  // property
        {
            get { return _vanus; }
            set { _vanus = value > _vanus ? value : _vanus; }
        }

        public string Nimi { set; get; } = "tundmatu";
        //public int GetVanus() => _vanus;
        //public void SetVanus(int vanus) => _vanus =  vanus > _vanus ? vanus : _vanus;

        public override string ToString() => $"{Nimi} vanusega {_vanus}";


        static List<Inimene> inimenes= new List<Inimene>();
        public Inimene() => inimenes.Add(this); 

        public static int RahvaArv => inimenes.Count;

        public static IEnumerable<Inimene> Inimesed => inimenes;
    }

}
