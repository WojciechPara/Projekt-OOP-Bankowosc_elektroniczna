using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Bankowość_elektroniczna
{
    internal class Transakcja
    {
        public string DataTransakcji;
        public double Kwota;
        public string Odbiorca;
        public string Numer;
        Konto konto;

        public Transakcja(Konto aktywneKonto)
        {
            konto = aktywneKonto;
        }

        public void WyslijPrzelew(string dataTransakcji, double kwota, string odbiorca, string numerKontaOdbiorcy)
        {
            DataTransakcji = dataTransakcji;
            Kwota = kwota;
            Odbiorca = odbiorca;
            Numer = numerKontaOdbiorcy;

            Console.WriteLine("Dnia " + dataTransakcji + " przelano " + kwota + " złotych odbiorcy " + odbiorca + " na numer rachunku " + numerKontaOdbiorcy + ".");
        }

        public void DoladujTelefon(string dataTransakcji, double kwota, string odbiorca, string numerTelefonuOdbiorcy)
        {
            DataTransakcji = dataTransakcji;
            Kwota = kwota;
            Odbiorca = odbiorca;
            Numer = numerTelefonuOdbiorcy;

            Console.WriteLine("Dnia " + dataTransakcji + " doładowano kwotą" + kwota + " złotych odbiorcy " + odbiorca + " na numer telefonu " + numerTelefonuOdbiorcy + ".");
        }
    }
}
