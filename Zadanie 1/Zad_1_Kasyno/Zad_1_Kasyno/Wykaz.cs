using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_1_Kasyno
{

    public class Wykaz
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public Wykaz(int id, string imie, string nazwisko, string telefon, string adres)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Telefon = telefon;
            Adres = adres;
        }

        public override string ToString()
        {
            return string.Format("Id: {0} Imie: {1}, Nazwisko: {2}, Tel: {3}, Adres: {4}",Id,Imie,Nazwisko,Telefon,Adres);
        }


    }
}
