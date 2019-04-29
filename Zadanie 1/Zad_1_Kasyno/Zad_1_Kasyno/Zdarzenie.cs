using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_1_Kasyno
{
    class Zdarzenie
    {
        public int Id { get; set; }
        public OpisStanu Opisstanu { get; set; }
        public Wykaz Wykaz { get; set; }
        public double WygranaKwota { get; set; }
        public DateTime DataGry { get; set; }

        public Zdarzenie(int id, OpisStanu opisstanu, Wykaz wykaz, DateTime dataGry)
        {
            Id = id;
            Opisstanu = opisstanu;
            Wykaz = wykaz;
            DataGry = dataGry;
            WygranaKwota = opisstanu.MnoznikWygranej * opisstanu.Gra.Wygrana;
        }
    }
}
