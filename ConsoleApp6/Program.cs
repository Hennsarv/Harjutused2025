namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Loom loom = new Loom();
            loom.Jooks();

            Kass kass = new Kass();
            kass.Jooks(); kass.Jooks();
            kass.Jooks().Jooks();


            string näide = "Henn Sarv on tore poiss";

            näide.Split(' ')[1].ToUpper().Trim().Prindi().ToLower().Prindi();


        }
    }

    class Loom
    {
        public virtual Loom Jooks()
        {
            Console.WriteLine("Loom jookseb");
            return this;
        }
    }

    class Koduloom : Loom
    {
    }

    class Kass : Koduloom
    {
        public override Kass Jooks()
        {
            Console.WriteLine("Kiisu kõnnib");
            return this;
        }
    }

    static class StringExtensions
    {
        public static string Prindi(this string s)
        {
            Console.WriteLine(s);
            return s;
        }

    }

}
