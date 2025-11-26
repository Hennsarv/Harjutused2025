using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Inimene
    {
        public Inimene() { Id = 
                Inimesed.Count == 0 ? 1 :
                Inimesed.Max(x => x.Id) + 1; }

        public int Id { get; set; }
        public string Nimi { get; set; }
        public int Vanus { get; set; }

        public static List<Inimene> Inimesed = new List<Inimene>();

        public static void Init()
        {
            if (Inimesed.Count == 0)
            {
                Inimesed.Add(new Inimene { Nimi = "Henn", Vanus = 70 });
                Inimesed.Add(new Inimene { Nimi = "Henry", Vanus = 47 });
                Inimesed.Add(new Inimene { Nimi = "Kristjan", Vanus = 45 });
                ;
            }
        }
    }
}