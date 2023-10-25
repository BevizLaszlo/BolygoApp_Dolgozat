using BolygoApp.src;
using System.Text;

namespace BolygoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Bolygo> bolygok = new();
            using (StreamReader sr = new(path: @"..\..\..\src\solsys.txt", encoding: Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                    bolygok.Add(new Bolygo(sr.ReadLine()));
            }

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"\t3.1: {bolygok.Count} bolygó van a naprendszerben");
            Console.WriteLine($"\t3.2: a naprendszerben a bolygóknak átlagosan {bolygok.Sum(p => p.Holdak) / (double)bolygok.Count} holdja van");
            Console.WriteLine($"\t3.3: a legnagyobb térfogatú bolígó a {bolygok.OrderBy(p => p.TerfogatArany).Last().Nev}");
            Console.Write("\t3.4: írd be a keresett bolygó nevét: ");
            string bolygo = Console.ReadLine();
            bool vanBolygo = false;
            foreach (Bolygo b in bolygok)
            {
                if (b.Nev.ToLower() == bolygo.ToLower())
                {
                    vanBolygo = true;
                    break;
                }
            }
            Console.WriteLine($"\t\t{(vanBolygo ? "van" : "sajnos nincs")} ilyen bolygó a naprendszerben");
            Console.Write("\t3.4: Írj be egy egész számot: ");

            int holdSzam = int.Parse( Console.ReadLine() );
            string bolygokHolddal = "[";
            foreach (Bolygo b in bolygok)
                if (b.Holdak > holdSzam) bolygokHolddal += $"{b.Nev}, ";
            bolygokHolddal = bolygokHolddal.Remove(bolygokHolddal.Length - 2);
            bolygokHolddal += "]";

            Console.WriteLine($"\t\ta következő bolygókna van {holdSzam}-nál/-nél több holdja:");
            Console.WriteLine($"\t\t{bolygokHolddal}");
        }
    }
}