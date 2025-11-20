using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kolmas_Teisendused_Tehted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // millised arvutüübid veel on

            ulong x = 0xffff_ffff_ffff_ffff;

            double d = double.MaxValue;
            var d2 = Double.Epsilon;

            float f = float.MaxValue;
            float f2 = 4.7F;

            Console.WriteLine($"d={d} e={d2} f={f} e={f2}");

            var m = 4; ;

            decimal dec = decimal.MaxValue;
            Console.WriteLine(Decimal.MinValue);

            dec = 4M;
            m = (int)4L;   // casting tehe lubab mul ARVE! omistada vastupidi suurusesuguluspuud

            m = (int)7F;

            // kuidas kirjutada arvu

            // tehted (ja mitte ainult arvudega)

            // TEhted IGASUGU ASJADEGA on C-tüüpi keele alus 

            



            // kuidas teisendada arve

            // kõike alati castimnguga ei saa

            //Console.Write("anna üks arv: ");
            ////int arv = int.Parse(Console.ReadLine());

            //int arv = int.TryParse(Console.ReadLine(), out int arv_) ? arv_ : 0;


            Console.Write("millal sa sündisid:");
            //DateTime synd = DateTime.Parse(Console.ReadLine());
            DateTime synd = DateTime.TryParse(Console.ReadLine(), CultureInfo.GetCultureInfo("fi-fi"), DateTimeStyles.None ,out DateTime synd_) ? synd_ : DateTime.Now.AddDays(-1);
            Console.WriteLine(synd);

            var tunnused = Tunnused.punane | Tunnused.kolisev;
            Console.WriteLine(tunnused ^ Tunnused.kolisev);


        }



    }


    [Flags]public enum Tunnused { punane=1, puust=2, kolisev=4}

    public class MyBitArray
    {
        private readonly uint[] _data;
        public int Length { get; }

        public MyBitArray(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));

            Length = length;
            int uintCount = (length + 31) / 32;
            _data = new uint[uintCount];
        }

        public bool this[int index]
        {
            get => Get(index);
            set => Set(index, value);
        }

        public bool Get(int index)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            int word = index / 32;
            int bit = index % 32;

            return ((_data[word] >> bit) & 1) != 0;
        }

        public void Set(int index, bool value)
        {
            if (index < 0 || index >= Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            int word = index / 32;
            int bit = index % 32;
            uint mask = 1u << bit;

            if (value)
                _data[word] |= mask;
            else
                _data[word] &= ~mask;
        }

        public void SetAll(bool value)
        {
            uint v = value ? 0xFFFFFFFFu : 0u;
            for (int i = 0; i < _data.Length; i++)
                _data[i] = v;
        }

        public void Clear() => SetAll(false);

        public MyBitArray Clone()
        {
            var clone = new MyBitArray(Length);
            Array.Copy(_data, clone._data, _data.Length);
            return clone;
        }
    }


}
