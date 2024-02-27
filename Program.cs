using System;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Channels;

namespace Projekt___Bankowość_elektroniczna
{
    internal class Program : Komunikaty
    {
        static void Main(string[] args)
        {
            // wyświetlanie polskich znaków w konsoli
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool zalogowany = false;
            Konto aktywneKonto;
            ListaKont listaKont = new ListaKont();

            // załaduj listę kont z pliku CSV
            listaKont.Odczytaj();

            while (!zalogowany)
            {
                // menu powitalne
                WyswietlKomunikat("menuPowitalne");
                string wyborEkranPowitalny = Console.ReadLine();
                Console.Clear();

                if (wyborEkranPowitalny == "1")
                {
                    // menu logowania
                    Console.Write("Login: ");
                    string login = Console.ReadLine();
                    Console.Write("Haslo: ");
                    string haslo = Console.ReadLine();

                    // przeszukaj plik CSV i porównaj login i hasło 
                    aktywneKonto = listaKont.ZnajdzKonto(login, haslo);
                    Console.Clear();

                    if (aktywneKonto != null)
                    {
                        // jeśli istnieje takie konto to zaloguj
                        zalogowany = true;
                        Console.WriteLine("Pomyślnie zalogowano.");
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                    else
                    {
                        // jeśli nie istnieje to powróć do menu
                        Console.WriteLine("Nieprawidłowe dane logowania.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                    }

                    while (zalogowany)
                    {
                        // zalogowano na konto
                        WyswietlKomunikat("menuGłówne");
                        string wyborMenuGlowne = Console.ReadLine();
                        Console.Clear();

                        switch (wyborMenuGlowne)
                        {
                            case "1":
                                // zakładka Mój Profil
                                while (true)
                                {
                                    // menu
                                    WyswietlKomunikat("menuMójProfil");
                                    string wyborMojProfil = Console.ReadLine();
                                    Console.Clear();

                                    if (wyborMojProfil == "1")
                                    {
                                        // wyświetlenie informacji o koncie
                                        Console.WriteLine(aktywneKonto.ToString());
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        continue;
                                    }
                                    else if (wyborMojProfil == "2")
                                    {
                                        // zmiana danych
                                        while (true)
                                        {
                                            WyswietlKomunikat("menuEdycjaMójProfil");
                                            string wyborEdycjaMojProfil = Console.ReadLine();
                                            Console.Clear();

                                            if (wyborEdycjaMojProfil == "1")
                                            {
                                                // nazwisko
                                                Console.Write("Podaj nowe nazwisko: ");
                                                string noweNazwisko = Console.ReadLine();
                                                aktywneKonto.user.Nazwisko = noweNazwisko;
                                                listaKont.ZmienNazwisko(aktywneKonto.Login, noweNazwisko);
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                            else if (wyborEdycjaMojProfil == "2")
                                            {
                                                // ulica
                                                Console.Write("Podaj nową ulicę i numer domu: ");
                                                string nowaUlica = Console.ReadLine();
                                                aktywneKonto.user.Ulica = nowaUlica;
                                                listaKont.ZmienUlice(aktywneKonto.Login, nowaUlica);
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                            else if (wyborEdycjaMojProfil == "3")
                                            {
                                                // kod pocztowy i miasto
                                                Console.Write("Podaj nowy kod pocztowy i miasto: ");
                                                string nowyKodPocztowyIMiasto = Console.ReadLine();
                                                aktywneKonto.user.KodPocztowyMiasto = nowyKodPocztowyIMiasto;
                                                listaKont.ZmienKodPocztowyIMiasto(aktywneKonto.Login, nowyKodPocztowyIMiasto);
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                            else if (wyborEdycjaMojProfil == "4")
                                            {
                                                // email
                                                Console.Write("Podaj nowy adres email: ");
                                                string nowyEmail = Console.ReadLine();
                                                aktywneKonto.user.Email = nowyEmail;
                                                listaKont.ZmienEmail(aktywneKonto.Login, nowyEmail);
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                            else if (wyborEdycjaMojProfil == "5")
                                            {
                                                // numer telefonu
                                                Console.Write("Podaj nowy numer telefonu: ");
                                                string nowyNumerTelefonu = Console.ReadLine();
                                                aktywneKonto.user.NumerTelefonu = nowyNumerTelefonu;
                                                listaKont.ZmienNumerTelefonu(aktywneKonto.Login, nowyNumerTelefonu);
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                            else if (wyborEdycjaMojProfil == "6")
                                            {
                                                // wstecz
                                                Console.Clear();
                                                break;

                                            }
                                            else
                                            {
                                                // nieprawidłowy wybór
                                                Console.WriteLine("Nieprawidłowy wybór.");
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                            
                                        }
                                        Console.Clear();
                                        continue;

                                    }
                                    else if (wyborMojProfil == "3")
                                    {
                                        // wstecz
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        // nieprawidłowy wybór
                                        Console.WriteLine("Nieprawidłowy wybór.");
                                        Thread.Sleep(1500);
                                        Console.Clear();
                                        break; 
                                    }
                                }
                                Console.Clear();
                                break;
                            case "2":
                                // zakładka Rachunki
                                Console.WriteLine("Rachunki\n\nRachunek numer: " + aktywneKonto.NumerRachunku + " - stan konta: " + aktywneKonto.StanKonta + " PLN.");
                                Thread.Sleep(5000);
                                Console.Clear();
                                break;
                            case "3":
                                // zakładka Karty
                                Console.WriteLine("Karty\n");
                                Karty.InformacjaOKartach();
                                Thread.Sleep(5000);
                                Console.Clear();
                                break;
                            case "4":
                                // zakładka Kredyty
                                Console.WriteLine("Kredyty\n");
                                Kredyty.InformacjaOKredytach();
                                Thread.Sleep(5000);
                                Console.Clear();
                                break;
                            case "5":
                                // zakładka Lokaty
                                Console.WriteLine("Lokaty\n");
                                Lokaty.InformacjaOLokatach();
                                Thread.Sleep(5000);
                                Console.Clear();
                                break;
                            case "6":
                                // zakładka Transakcje
                                while (true)
                                {
                                    WyswietlKomunikat("menuTransakcje");
                                    string wyborTransakcje = Console.ReadLine();
                                    DateTime dzisiaj = DateTime.Today;
                                    string dzisiajString = dzisiaj.ToString("yyyy-MM-dd");
                                    Console.Clear();

                                    if (wyborTransakcje == "1")
                                    {
                                        // Przelew
                                        Transakcja transakcja = new Transakcja(aktywneKonto);

                                        while (true)
                                        {
                                            Console.Write("Podaj kwotę przelewu: ");
                                            double kwotaPrzelewu = Convert.ToDouble(Console.ReadLine());
                                            bool dostepneSrodki = aktywneKonto.SprawdzDostepneSrodki(kwotaPrzelewu);
                                            
                                            if (dostepneSrodki)
                                            {
                                                Console.Write("Podaj dane odbiorcy: ");
                                                string odbiorcaPrzelewu = Console.ReadLine();
                                                Console.Write("Podaj numer rachunku odbiorcy: ");
                                                string rachunekOdbiorcy = Console.ReadLine();
                                                transakcja.WyslijPrzelew(dzisiajString, kwotaPrzelewu, odbiorcaPrzelewu, rachunekOdbiorcy);
                                                Historia.Dodaj(transakcja);
                                                listaKont.ZmienStanKonta(aktywneKonto.Login, kwotaPrzelewu);
                                                Console.WriteLine("\nŚrodki po transakcji: " + aktywneKonto.StanKonta + " PLN");
                                                Thread.Sleep(5000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Nie posiadasz wystarczających środków na koncie.");
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    } 
                                    else if (wyborTransakcje == "2")
                                    {
                                        // Doładowanie telefonu
                                        Transakcja transakcja = new Transakcja(aktywneKonto);

                                        while (true)
                                        {
                                            Console.Write("Podaj kwotę doładowania [5, 10, 30, 50, 100]: ");
                                            double kwotaDoladowania = Convert.ToDouble(Console.ReadLine());
                                            bool dostepneSrodki = aktywneKonto.SprawdzDostepneSrodki(kwotaDoladowania);
                                            Console.Write("Podaj odbiorcę: ");
                                            string odbiorcaDoladowania = Console.ReadLine();

                                            if (dostepneSrodki)
                                            {
                                                Console.Write("Podaj numer telefonu: ");
                                                string numerTelefonuOdbiorcy = Console.ReadLine();
                                                transakcja.DoladujTelefon(dzisiajString, kwotaDoladowania, odbiorcaDoladowania, numerTelefonuOdbiorcy);
                                                Historia.Dodaj(transakcja);
                                                listaKont.ZmienStanKonta(aktywneKonto.Login, kwotaDoladowania);
                                                Console.WriteLine("\nŚrodki po transakcji: " + aktywneKonto.StanKonta + " PLN");
                                                Thread.Sleep(5000);
                                                Console.Clear();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Nie posiadasz wystarczających środków na koncie.");
                                                Thread.Sleep(1500);
                                                Console.Clear();
                                                continue;
                                            }
                                        }
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        // nieprawidłowy wybór
                                        Console.WriteLine("Nieprawidłowy wybór.");
                                        Thread.Sleep(1500);
                                        Console.Clear();
                                        continue;
                                    }
                                }
                                Console.Clear();
                                break;
                                
                            case "7":
                                // zakładka Historia (transakcji)
                                Console.WriteLine("Historia\n");
                                Historia.WyswietlHistorie();
                                Thread.Sleep(5000);
                                Console.Clear();
                                break;
                            case "8":
                                // zakładka Kontakt (z Bankiem)
                                Console.WriteLine("Kontakt\n");
                                Console.Write("Wyślij wiadomość do obsługi Banku: ");
                                string wiadomosc = Console.ReadLine();
                                Console.WriteLine("\nWiadomość o treści: " + wiadomosc + ", została wysłana. Kopia wiadomości została przesłana również na Pani/Pana " +
                                    "adres email: " + aktywneKonto.user.Email + ". Prosimy czekać na kontakt pracownika obsługi Banku.");
                                Thread.Sleep(5000);
                                Console.Clear();
                                break;
                            case "9":
                                // zakładka Mój Portfel
                                Console.WriteLine("Mój portfel\n\nKonto osobiste\nWłaściciel konta: " + aktywneKonto.user.GetFullName() + "\nNumer rachunku: " 
                                    + aktywneKonto.NumerRachunku + "\nStan konta: " + aktywneKonto.StanKonta + " PLN");
                                Thread.Sleep(5000);
                                Console.Clear();
                                break;
                            case "0":
                                // wylogowanie się z konta
                                Console.WriteLine("Pomyślnie wylogowano.");
                                zalogowany = false;
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                            default:
                                // nieprawidłowy wybór
                                Console.WriteLine("Nieprawidłowy wybór.");
                                Thread.Sleep(1500);
                                Console.Clear();
                                break;
                        }
                    }
                }
                else if (wyborEkranPowitalny == "2")
                {
                    // ekran rejestracji nowego konta
                    Console.WriteLine("Formularz rejestracyjny\n");
                    Console.Write("Imię: ");
                    string imie = Console.ReadLine();
                    Console.Write("Nazwisko: ");
                    string nazwisko = Console.ReadLine();
                    Console.Write("Ulica [np. 'Wojska Polskiego 1/123']: ");
                    string ulica = Console.ReadLine();
                    Console.Write("Kod pocztowy i Miasto [np. '00-001 Warszawa']: ");
                    string kodPocztowyMiasto = Console.ReadLine();
                    Console.Write("Adres email [ np. 'jan.kowalski@domena.pl' ]: ");
                    string email = Console.ReadLine();
                    Console.Write("Numer telefonu [ np. '0048111222333' ]: ");
                    string numerTelefonu = Console.ReadLine();
                    Console.Write("Początkowy stan konta: ");
                    double stanKonta = Convert.ToDouble(Console.ReadLine());
                    string login;

                    while (true)
                    {   
                        // sprawdź w pliku CSV czy login nie został już przez kogoś zarejestrowany
                        Console.Write("Login: ");
                        login = Console.ReadLine();

                        if (listaKont.ZnajdzLogin(login) != null)
                        {
                            Console.WriteLine("\nTaki Login już istnieje. Podaj inny login.");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    Console.Write("Haslo: ");
                    string haslo = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Konto zostało pomyślnie utworzone.\n");
                    aktywneKonto = new Konto(imie, nazwisko, ulica, kodPocztowyMiasto, email, numerTelefonu, stanKonta, login, haslo);
                    listaKont.DodajKonto(aktywneKonto);
                    listaKont.Zapisz();
                    Thread.Sleep(1500);
                    Console.Clear();
                    continue;
                }
                else if (wyborEkranPowitalny == "3")
                {
                    // wyjście z programu
                    Console.WriteLine("Zakończenie działania programu.");
                    Thread.Sleep(1500);
                    return;
                }
                else
                {
                    // nieprawidłowy wybór na ekranie powitalnym
                    Console.WriteLine("Nieprawidłowy wybór.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
