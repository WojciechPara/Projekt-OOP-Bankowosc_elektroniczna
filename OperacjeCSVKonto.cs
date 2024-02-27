using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Projekt___Bankowość_elektroniczna
{
    internal class OperacjeCSVKonto
    {
        public List<Konto> DaneKont = new List<Konto>();

        public void Zapisz()
        {
            string sciezka = "konta.csv";
            
            using (var writer = new StreamWriter(sciezka))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            }))
            {
                csv.WriteRecords(DaneKont);
            }
        }

        public void Odczytaj()
        {
            string sciezka = "konta.csv";

            try
            {
                using (var reader = new StreamReader(sciezka))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                }))
                { 
                    var rekordy = csv.GetRecords<KontoCSV>();

                    foreach (var rekord in rekordy)
                    {
                        DaneKont.Add(new Konto(rekord.Imie, rekord.Nazwisko, rekord.Ulica, rekord.KodPocztowyMiasto, rekord.Email, rekord.NumerTelefonu, rekord.StanKonta, rekord.Login, rekord.Haslo, rekord.NumerRachunku));
                    }
                }
            }
            catch (Exception ex)
            {
                // złap wyjątek w przypadku braku pliku "konta.csv"
            }
        }
    }
}
