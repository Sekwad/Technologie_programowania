using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_1_Kasyno
{
    class Katalog
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Wygrana { get; set; }
        public double CenaWejsciowa { get; set; }

        public Katalog(int id, string nazwa, int iloscGraczy, double stawka)
        {
            Id = id;
            Nazwa = nazwa;
            Wygrana = iloscGraczy;
            CenaWejsciowa = stawka;
        }

    }
}
