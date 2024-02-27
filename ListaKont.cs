using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Bankowość_elektroniczna
{
    internal class ListaKont : OperacjeCSVKonto
    {
        public void DodajKonto(Konto konto)
        {
            this.DaneKont.Add(konto);
        }

        public Konto ZnajdzKonto(string login, string haslo)
        {
            return this.DaneKont.Find(konto => konto.Login == login && konto.Haslo == haslo);
        }

        public Konto ZnajdzRachunek(string numerRachunku)
        {
            return this.DaneKont.Find(konto => konto.NumerRachunku == numerRachunku);
        }

        public Konto ZnajdzLogin(string login)
        {
            return this.DaneKont.Find(konto => konto.Login == login);
        }

        public void ZmienNazwisko(string login, string noweNazwisko)
        {
            int indeksKonta = this.DaneKont.IndexOf(ZnajdzLogin(login));
            DaneKont[indeksKonta].user.Nazwisko = noweNazwisko;
            Zapisz();
        }
        
        public void ZmienUlice(string login, string nowaUlica)
        {
            int indeksKonta = this.DaneKont.IndexOf(ZnajdzLogin(login));
            DaneKont[indeksKonta].user.Ulica = nowaUlica;
            Zapisz();
        }

        public void ZmienKodPocztowyIMiasto(string login, string nowyKodPocztowyIMiasto)
        {
            int indeksKonta = this.DaneKont.IndexOf(ZnajdzLogin(login));
            DaneKont[indeksKonta].user.KodPocztowyMiasto = nowyKodPocztowyIMiasto;
            Zapisz();
        }

        public void ZmienEmail(string login, string nowyEmail)
        {
            int indeksKonta = this.DaneKont.IndexOf(ZnajdzLogin(login));
            DaneKont[indeksKonta].user.Email = nowyEmail;
            Zapisz();
        }

        public void ZmienNumerTelefonu(string login, string nowyNumerTelefonu)
        {
            int indeksKonta = this.DaneKont.IndexOf(ZnajdzLogin(login));
            DaneKont[indeksKonta].user.NumerTelefonu = nowyNumerTelefonu;
            Zapisz();
        }

        public void ZmienStanKonta(string login, double kwotaTransakcji)
        {
            int indeksKonta = this.DaneKont.IndexOf(ZnajdzLogin(login));
            DaneKont[indeksKonta].StanKonta -= kwotaTransakcji;
            Zapisz();
        }
    }
}
