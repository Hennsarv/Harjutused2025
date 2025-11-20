using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MInuteineproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // geneerikud kollektsioonid
            //int a = 7; int b = 5;string h = "Henn"; string s = "Sarv";
            //Console.WriteLine($"a={a} ja b={b} h={h} s= {s}");

            //Vaheta(ref a, ref b);
            //Vaheta(ref h, ref s);

            //Console.WriteLine($"a={a} ja b={b} h={h} s= {s}");

            List<int> list = new List<int>(40) { 1, 2, 3, 44, 5, 16, 77, 8, };
            //list.Add(77); list.Add(77); list.Add(77); list.Add(77); list.Add(77); list.Add(77); list.Add(77);
            //list.Add(77); list.Add(77);
            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.Capacity);

            //            foreach (var item in list) { Console.WriteLine(item); }

            // list on tore asi vaatame veel mõnd

            var sort = new SortedSet<int>(list);
            sort.Add(33); sort.Add(100); sort.Add(3);

            //            foreach (var item in sort) { Console.WriteLine(item); }
            List<string> strs = new List<string>();
            List<int[]> ints = new List<int[]>();
            List<List<int>> lists = new List<List<int>> { };

            // see oli sorted set

            Queue<int> queue = new Queue<int>();  // FIFO - first-in-first-out
            Stack<int> stack = new Stack<int>();  // LIFO - last-in-first-out

            queue.Enqueue(1);
            queue.Enqueue(7);
            queue.Enqueue(3);
            queue.Enqueue(8);
            while (queue.Count > 0) { Console.WriteLine(queue.Dequeue()); }

            stack.Push(11);
            stack.Push(77);
            stack.Push(33);
            stack.Push(88);
            while (stack.Count > 0) { Console.WriteLine(stack.Pop()); }


            Dictionary<int, string> dic = new Dictionary<int, string>()
            {
                { 1, "Henn" },
                { 12, "Ants" },
                { 17, "Peeter" },
            };


            Console.WriteLine(dic[12]);
            foreach (var d in dic) { Console.WriteLine(d); }

            Dictionary<string, int> palgad = new Dictionary<string, int>()
            {
                {"Henn", 10000 },
                {"Ants", 500 },
                {"Peeter", 2000 }
            };

            Console.WriteLine(palgad.TryGetValue("Joosep", out int palk) ? palk : 0);

            Console.WriteLine(palgad[dic[1]]);





        }

        public static void Vaheta<T>(ref T x, ref T y)
        {
            T t = x;
            x = y; y = t;
        }

    }
}
