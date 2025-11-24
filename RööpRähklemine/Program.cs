using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RööpRähklemine
{
    internal class Program
    {
        static Random R = new Random();

        static void Main() { MainA(); Console.ReadKey(); }
        async static void MainA()
        {
            // 1.vja 2. TaskRun() - lihtsalt paralleelselt paneme toimima pärast ootame muud - kaks varianti
            //Task.Run(() => Teine(0)); Task.Run(() => Teine(1)); Task.Run(() => Teine(2));
            //Enumerable.Range(1, 5).ToList().ForEach(x => Task.Run(() => Teine(x)));

            // 3. Paneme async meetodid käima ja ootame, kui kõik on lõpetanud - kaks varianti
            //var tasks = Enumerable.Range(1, 5).Select(x => Kolmas(x)).ToArray();
            //await Task.WhenAll(tasks);

            //var t1 = Kolmas(1);
            //var t2 = Kolmas(2);
            //var t3 =  Kolmas(3);
            //await Task.WhenAll(t1, t2, t3);

            // 4. KAsutame async funktsioone - pärast ootame neilt tulemusi
            //var ts = Enumerable.Range(1, 5).Select(async i => new { nr = i, kaua = await Neljas(i) }).ToList();
            //ts.ForEach(x => Console.WriteLine( $"thread {x.Result.nr} kestis {x.Result.kaua}"));

            var tasks4 = Enumerable.Range(1,5).Select(async i => new {nr = i, kaua = await Neljas(i)});
            var res = await Task.WhenAll(tasks4);
            res.ToList().ForEach(i => Console.WriteLine($"thread {i.nr} kestis {i.kaua}"));

            // 5. Kasutame PLinq (paralleel LINQ ja arvutame paralleelselt - tavalisi funktsioone)
            //Enumerable.Range(1, 16).AsParallel().ForAll(x => Console.WriteLine($"thread {x} kestab {Viies(x)}"));

            Console.ReadKey();


        }

        static void Teine(int mitmes = 0)
        {
            var algus = DateTime.Now;
            Console.WriteLine($"Thread {mitmes} alustas");
            Thread.Sleep(R.Next(2000,5000));
            Console.WriteLine($"Thread {mitmes} lõpetas kestis {(DateTime.Now -algus).TotalMilliseconds:N0}");

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
