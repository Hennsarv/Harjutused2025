using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassiJaObjektid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Esimene osa
            //Console.WriteLine(Inimene.RahvaArv);

            //Inimene i = Inimene.Create("35503070211"); // { Nimi = "Henn"};
            //i.Nimi = "Henn";

            //i = Inimene.Create("35503070211"); // { Nimi = "Henn"};

            //if (i != null) { 
            //i.Nimi = "Teinehenn";
            //}
            ////Console.WriteLine(Inimene.RahvaArv);

            //foreach (var ix in Inimene.Register.Values) Console.WriteLine(ix); 
            #endregion

            Loom l = new Loom("krokodill");
            Loom e = new Loom();

            Koduloom kl = new Koduloom("Punik", "lehm");

            Koer k = new Koer("Pontu");

            //k.Häälitse();

            Kass ka = new Kass("Nurri");
            ka.Häälitse();
                ka.Silita().Häälitse();
            ka.SikutaSabast().Häälitse();

            foreach (var item in Loom.Loomaaed) Console.WriteLine(item.ToString());

            Loom.Loomaaed.ForEach(x => x.Häälitse());
            var esimeneLoomTextina = (Loom.Loomaaed[0]).ToString();

            Sepik s = new Sepik();
            Lõuna(ka);

            var koerad = new SortedSet<Koer>
            {
                new Koer("Pauka"),
                new Koer("Polla"),
                new Koer("Tatsu")
            };

            koerad.Add(k);
            foreach (var item in koerad) Console.WriteLine(item);

            


        }

        static void Lõuna(object x)
        {
            //ISöödav amps = x as ISöödav;
            //amps?.Söö();

            if (x is ISöödav söödavx) söödavx.Söö();

        }

    }

    class Loom
    {
        public string Liik;

        public Loom() : this("tundmatu") { }

        public Loom(string liik) { Liik = liik; Loomaaed.Add(this); }

        public override string ToString() => $"loom liigist {this.Liik}";

        public static List<Loom> Loomaaed = new List<Loom>() { };

        public virtual Loom Häälitse() {Console.WriteLine($"{this} teeb koledat häält"); return this; }



    }

    class Koduloom : Loom
    {
        public string Nimi;

        public Koduloom(string nimi, string liik) : base(liik) => Nimi = nimi;
        

        public override string ToString() => $"{this.Liik} {Nimi}";
    }

    class Koer : Koduloom, ISöödav, IComparable
    {
        public string Tõug;
        public Koer(string nimi, string tõug = "krants") : base(nimi, "koer") => (Tõug,Nimi) = (tõug,nimi); 

        public int CompareTo(object obj)
        {
            return obj is Koer kobject ? this.Nimi.CompareTo(kobject.Nimi) : 1; 
        }

        public override Loom Häälitse() { Console.WriteLine($"{Nimi} haugub"); return this; }

        public void Söö() => Console.WriteLine($"Koer {Nimi} pistetakse nahka"); 
    }

    class Kass : Koduloom
    {
        public string KassiTõug;
        public Kass(string nimi, string kassitõug = "angoora") : base(nimi, "kass") { KassiTõug = kassitõug; }

        private bool tuju = false;

        public Kass SikutaSabast() { tuju = false; return this; }
        public Kass Silita() {tuju = true; return this; }

        public override Loom Häälitse() 
            {
            Console.WriteLine(tuju? $"Kiisu {Nimi} lööb nurru" : $"{Nimi} kräunub");
            return this;
            }
    }


    interface ISöödav
    {
        void Söö();
    }

    class Sepik : ISöödav
    {
        public void Söö()
        {
            Console.WriteLine("Keegi nosib sepikut");
        }
    }



    class Inimene
    {
        public string Nimi; // { get; set; }
        public int Vanus; // { get; set; }
        public string IK;

        public static List<Inimene> Rahvas = new List<Inimene>();

        public static Dictionary<string, Inimene> Register = new Dictionary<string, Inimene>();

        private Inimene(string ik) { IK = ik; Register.Add(ik, this); }

        public static Inimene Create(string ik) => 
            Register.ContainsKey(ik) ? null : new Inimene(ik);

        public static int RahvaArv => Rahvas.Count;

        public override string ToString() => $"Inimene {Nimi}";

    }



}
