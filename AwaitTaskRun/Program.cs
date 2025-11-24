using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitTaskRun
{
    internal class Program
    {
        static Random R = new Random();
        // täna veel teema sul proovida - teeme mitut asja korraga

        static void Main()
        {
            MainA();
            Console.ReadKey();
        }
        async static void MainA()
        {
            //Task.Run(() => Teine(1)); Task.Run(() => Teine(2)); Task.Run(() => Teine(3));
            Enumerable.Range(1, 7).ToList().ForEach(x => Task.Run(() => Teine(x)));

            //var t1 = Kolmas(1);
            //var t2 = Kolmas(2);
            //var t3 = Kolmas(3);
            //await Task.WhenAll(t1, t2, t3);
            var tasks = Enumerable.Range(1,7).Select(x => Kolmas(x+30)).ToArray();
            await Task.WhenAll(tasks);
            var tasks4 = Enumerable.Range(1, 5).Select(async i => new { nr = i, kaua = await Neljas(i+40) });
            var res = await Task.WhenAll(tasks4);
            res.ToList().ForEach(i => Console.WriteLine($"thread {i.nr} kestis {i.kaua}"));

            Enumerable.Range(1, 16).AsParallel().ForAll(x => Console.WriteLine($"thread {x+50} kestab {Viies(x+50)}"));


        }

        static void Teine(int mitmes)
        {
            var algus = DateTime.Now;
            Console.WriteLine($"Thread {mitmes} alustas");
            Thread.Sleep(R.Next(2000, 5000));
            Console.WriteLine($"Thread {mitmes} lõpetas kestis {(DateTime.Now - algus).TotalMilliseconds:N0}");
        }

        static async Task Kolmas(int mitmes = 0)
        {
            var algus = DateTime.Now;
            Console.WriteLine($"Thread {mitmes} alustas");
            await Task.Delay(R.Next(2000, 5000));
            Console.WriteLine($"Thread {mitmes} lõpetas kestis {(DateTime.Now - algus).TotalMilliseconds:N0}");
            //return mitmes;
        }

        static async Task<double> Neljas(int mitmes = 0)
        {
            var algus = DateTime.Now;
            Console.WriteLine($"Thread {mitmes} alustas");
            await Task.Delay(R.Next(2000, 5000));
            return (DateTime.Now - algus).TotalMilliseconds;
        }

        static double Viies(int mitmes = 0)
        {
            var algus = DateTime.Now;
            Console.WriteLine($"Thread {mitmes} alustas");
            Thread.Sleep(R.Next(2000, 5000));
            return (DateTime.Now - algus).TotalMilliseconds;

        }


    }
}
