using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Bankowość_elektroniczna
{
    public class User
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public string KodPocztowyMiasto { get; set; }
        public string Email { get; set; }
        public string NumerTelefonu { get; set; }

        public User(string imie, string nazwisko, string ulica, string kodPocztowyMiasto, string email, string numerTelefonu)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Ulica = ulica;
            KodPocztowyMiasto = kodPocztowyMiasto;
            Email = email;
            NumerTelefonu = numerTelefonu;
        }

        public string GetFullName()
        {
            return Imie + " " + Nazwisko;
        }
    }
}
