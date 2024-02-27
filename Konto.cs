using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt___Bankowość_elektroniczna
{
    public class Konto
    {
        public string NumerRachunku { get; set; }
        public double StanKonta { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public List<string> Konta { get; set; }
        public User user { get; set; }

        public Konto(string login, string haslo) 
        {
            Login = login;
            Haslo = haslo;
        }

        public Konto(string imie, string nazwisko, string ulica, string kodPocztowyMiasto, string email, string numerTelefonu, double stanKonta, string login, string haslo, string numerRachunku)
        {
            Login = login;
            Haslo = haslo;
            NumerRachunku = numerRachunku;
            StanKonta = stanKonta;
            Konta = new List<string>();
            user = new User(imie, nazwisko, ulica, kodPocztowyMiasto, email, numerTelefonu);
        }

        public Konto(string imie, string nazwisko, string ulica, string kodPocztowyMiasto, string email, string numerTelefonu, double stanKonta, string login, string haslo)
        {
            Login = login;
            Haslo = haslo;
            UtworzNumerKonta();
            StanKonta = stanKonta;
            Konta = new List<string>();
            user = new User(imie, nazwisko, ulica, kodPocztowyMiasto, email, numerTelefonu);
        }

        private void UtworzNumerKonta()
        {
            ListaKont listaKont = new ListaKont();
            string losujNumerRachunku;
            while (true)
            {
                var random = new Random();
                string losowyNumerR = Convert.ToString(random.Next(10000000, 19999999));
                losujNumerRachunku = "24999999999999999"+losowyNumerR;
                if (listaKont.ZnajdzRachunek(losujNumerRachunku) == null)
                {
                    break;
                }
            }
            NumerRachunku = losujNumerRachunku;
        }

        public override string ToString()
        {
            return user.GetFullName() + "\n" + user.Ulica + "\n" + user.KodPocztowyMiasto + "\n" + user.Email + "\n" + user.NumerTelefonu + "\n" + NumerRachunku + "\n" + StanKonta + " PLN"; 
        }

        public bool SprawdzDostepneSrodki(double kwota)
        {
            return kwota <= StanKonta;
        }
    }
} 
