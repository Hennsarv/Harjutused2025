using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inimene i1 = new Inimene { Name = "Henn", Age = 70 };
            Inimene i2 = new Inimene("Peeter Suur", 200);

            for(int i = 0;i < 100 ; i++)
            {

                using(Inimene ihii = new Inimene { Name = $"Inimene nr {i}", Age = i*i })
                {
                    System.Threading.Thread.Sleep(1000);
                }


            }

        }
    }

    class Inimene : IDisposable
    {
        private bool disposedValue;

        public int Id { get; set; } = 0;
        public string Name { get; set; } = "tundmatu";
        public int Age { get; set; } = 0;
        public override string ToString() => $"inimene {Name} vanusega {Age}";

        public byte[] Raha { get; set; } = new byte[200];

        public Inimene() {
            Console.WriteLine($"Luakse inimene! {this}");
        } // construktor

        public Inimene(string nimi, int vanus) : this() => (Name, Age) = (nimi, vanus);



        ~Inimene() // destructor
        {
            Dispose(disposing: false);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    Raha = null;
                    Console.WriteLine($"{this} lahkub lavalt {disposing}");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                Console.WriteLine($"{this} lahkub lavalt {disposing}");
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Inimene()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
