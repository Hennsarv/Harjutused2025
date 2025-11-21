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
            Mast trump = Mast.Pada;
            Console.WriteLine(trump);
            Enum.GetNames(typeof(Mast)).ToList().ForEach(x => Console.WriteLine(x));

            int kaardiNr = 17;
            Console.WriteLine($"{(Mast)(kaardiNr/13)} {(Kaart)(kaardiNr%13)}");

            Omadus omadus = (Omadus)31;

            omadus ^= Omadus.Hiilgav;
            omadus ^= (Omadus.Punane | Omadus.Suur);

            omadus = Omadus.Sõjaveteran ^ Omadus.Puust;

            Random R = new Random();
            

            //var vastus = MessageBox.Show("Kuidas tund kulgeb", "Tere!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error); 

            

            Console.WriteLine((int)StringSplitOptions.None);

        }
    }

    enum Mast { Risti, Ruutu, Ärtu, Poti, Pada = 3 }
    enum Kaart { Kaks , Kolm, Neli, Viis, Kuus, Seitse, Kaheksa, Üheksa, Kümme, Soldat, Emand, Kuningas, Äss}

    [Flags] enum Omadus { Punane = 1, Suur = 2, Puust = 4, Kolisev = 8, Hiilgav = 16, Sõjaveteran = 23}
}
