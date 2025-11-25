using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace MVCJSoniga.Models
{
    public class Inimene
    {
        public Inimene() { this.Id = Inimesed.Count == 0 ? 1 : Inimesed.Max(x => x.Id) + 1; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Vanus { get; set; }

        static string _filename;// = Server.MapPath("~/Content/Inimesed.json");

        public static List<Inimene> Load(string filename) 
            => Inimesed = JsonConvert.DeserializeObject<List<Inimene>>(File.ReadAllText(_filename = filename));

        public static List<Inimene> Inimesed = new List<Inimene>();

        public static void Save() => File.WriteAllText(_filename, JsonConvert.SerializeObject(Inimesed));

    }
}