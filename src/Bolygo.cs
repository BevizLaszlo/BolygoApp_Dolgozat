using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolygoApp.src
{
    internal class Bolygo
    {
        public string Nev { get; set; }
        public int Holdak { get; set; }
        public double TerfogatArany { get; set; }

        public Bolygo(string sor)
        {
            string[] data = sor.Split(';');
            Nev = data[0];
            Holdak = int.Parse(data[1]);
            TerfogatArany = double.Parse(data[2].Replace('.', ','));
        }
    }
}
