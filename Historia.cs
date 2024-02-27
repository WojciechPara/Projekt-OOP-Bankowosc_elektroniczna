using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Bankowość_elektroniczna
{
    internal class Historia
    {
        public static List<Transakcja> historiaTransakcji = new List<Transakcja>();

        public static void Dodaj(Transakcja transakcja)
        { 
            historiaTransakcji.Add(transakcja);
        }

        public static void WyswietlHistorie()
        { 
            foreach (var trans in historiaTransakcji)
            {
                Console.WriteLine("Odbiorca: " + trans.Odbiorca + ", Kwota: " + trans.Kwota + ", Numer rachunku odbiorcy: " + trans.Numer);
            }
        }
    }
}
