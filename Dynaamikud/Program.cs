using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;


namespace Dynaamikud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic x;

            x = "hobune";
            Console.WriteLine(x);
            x = 77;
            Console.WriteLine(x.GetType().Name);

            string y = "hobune";
            Console.WriteLine(y.GetType().Name);

            dynamic Tasku = new Bag();

            Tasku.Nimi = "Henn";
            Tasku.Vanus = 70;
            Tasku["Palk"] = 5000;
            Tasku.Palk = 5000;




            Tasku.Vanus++;

            Console.WriteLine($"taskus on {Tasku.Nimi} vanusega {Tasku.Vanus}");

            Punkt p = new Punkt(3, 4);
            Console.WriteLine(p);

            Punkt p2 = (7, 8);
            Console.WriteLine(p2);

            p2 += 70;

            

            Console.WriteLine(p+p2+100);

            Inimene i1 = new Inimene() { Nimi = "Henn", Vanus = 70 };
            Inimene i2 = new Inimene("Peeter Suur", 353);
            Inimene i3 = ("Toomas Linnupoeg", 44);

            Inimene malle = ("Keegi Malle", 40);
            Inimene laps = i3 + malle;
            laps.Nimi = "Kristofer";
            Console.WriteLine(laps);

            var keda = "Isa";
            var see = laps[keda];

        }
    }

    class Bag : DynamicObject
    {
        readonly dynamic bag;

        public Bag() => bag = new Dictionary<string, dynamic>();

        public Bag(dynamic dict) => bag = dict;


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            switch (bag)
            {
                case IDictionary<string, object> d:
                    result = d.ContainsKey(binder.Name) ? d[binder.Name] : null;
                    return true;
                default:
                    result = bag[binder.Name];
                    return true;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bag[binder.Name] = value;
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var key = indexes[0]?.ToString();
            switch (bag)
            {
                case IDictionary<string, object> d:
                    result = d.ContainsKey(key) ? d[key] : null;
                    return true;
                default:
                    result = bag[key];
                    return true;
            }

        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            var key = indexes[0]?.ToString();

            switch (bag)
            {
                case IDictionary<string, object> d:
                    d[key] = value;
                    return true;

                default:
                    bag[key] = value;
                    return true;
            }
        }




    }

    class Inimene
    {
        string _miski;

        public string Nimi { get; set; }
        public int Vanus { get; set; }

        public Inimene Isa { get; set; }
        public Inimene Ema { get; set; }

        public string Miski
        {
            get { return _miski; }
            set { _miski = value; }
        }

        public Inimene() { }

        public Inimene(string nimi, int vanus) => (Nimi, Vanus) = (nimi, vanus);
        // {Nimi = nimi; Vanus = vanus;}

        public static implicit operator Inimene((string nimi, int vanus) inimene) => new Inimene(inimene.nimi, inimene.vanus);


        public static Inimene operator+ (Inimene isa, Inimene ema) => new Inimene() { Isa = isa, Ema = ema  };

        public override string ToString() => $"inimene {Nimi} isa {Isa.Nimi} ema {Ema.Nimi}";

        public Inimene this[string vanem] { get
            { return vanem == null ? null : vanem == "Isa" ? Isa : vanem == "Ema" ? Ema : null; }

            set { 
                switch(vanem)
                {
                    case "Isa": this.Isa = value; break;
                    case "Ema": this.Ema = value; break;
                }

            }
        }

    }

    struct Punkt
    {
        int x;
        int y;

        public Punkt(int x, int y) => (this.x, this.y) = (x, y);

        public override string ToString() => $"{x},{y}";

        public static implicit operator Punkt((int x, int y) p) => new Punkt(p.x, p.y);

        public static implicit operator Punkt(string s) => 
            string.IsNullOrEmpty(s) ? new Punkt(0,0) :
            new Punkt(int.TryParse(s.Split(',')[0], out int _x) ? _x : 0,
                      int.TryParse((s+",").Split(',')[1], out int _y) ? _y : 0);

        public static implicit operator Punkt(int x) => new Punkt(x, 0);


        public static Punkt operator+ (Punkt px, Punkt py) => new Punkt(px.x+py.x, px.y+py.y);

    }

}
