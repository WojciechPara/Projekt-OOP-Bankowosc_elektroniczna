using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Bankowość_elektroniczna
{
    public class Komunikaty
    {
        public static Dictionary<string, string> Teksty = new Dictionary<string, string> {
            { "menuPowitalne", "Witaj w bankowości internetowej, wybierz akcję:\n\n1.Zaloguj się\n2.Utwórz nowe konto\n3.Wyjdź z aplikacji\n\nWybór: "},
            { "menuGłówne", "Wybierz akcję:\n\n1.Mój profil\n2.Rachunki\n3.Karty\n4.Kredyty\n5.Lokaty\n6.Transakcje\n7.Historia\n8.Kontakt\n9.Mój portfel\n0.Wyloguj\n\nWybór: "},
            { "menuMójProfil", "Mój profil\n\nWybierz akcję:\n1.Wyświetl informacje o koncie\n2.Zmień dane\n3.Wstecz\n\nWybór: " },
            { "menuEdycjaMójProfil", "Jakie dane chcesz zmienić?\n\n1.Nazwisko\n2.Ulica\n3.Kod pocztowy i miasto\n4.Email\n5.Numer telefonu\n6.Wstecz\n\nWybór: " },
            { "menuTransakcje", "Transakcje\n\nWybierz akcję:\n1.Nowy przelew\n2.Doładowanie telefonu\n3.Wstecz\n\nWybór: " },


        };

        public static void WyswietlKomunikat(string komunikat)
        {
            Console.Write(Teksty[komunikat]);
        }

        
    }
}
