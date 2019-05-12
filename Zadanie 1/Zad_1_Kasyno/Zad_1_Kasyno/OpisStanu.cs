using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_1_Kasyno
{
    public class OpisStanu
    {
        public int Id { get; set; }
        public Katalog Gra { get; set; }

        public int IloscGraczy { get; set; }
        public bool CzySkonczona { get; set; }

        public double MnoznikWygranej { get; set; }

        public OpisStanu(int id, Katalog gra, int iloscGraczy, bool czySkonczona, double mnoznikWygranej)
        {
            Id = id;
            Gra = gra;
            IloscGraczy = iloscGraczy;
            CzySkonczona = czySkonczona;
            MnoznikWygranej = mnoznikWygranej;
        }
    }
}
