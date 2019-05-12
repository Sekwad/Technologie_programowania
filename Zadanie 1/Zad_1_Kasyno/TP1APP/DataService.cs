using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad_1_Kasyno;

namespace TP1APP
{
    class DataService
    {
        private DataRepository dataRepository;

        public DataService(DataRepository data)
        {
            dataRepository = data;
        }

        #region Wypisywanie
        public void WypiszGraczy(List<Wykaz> gracze)
        {
            foreach (Wykaz c in gracze)
                Console.WriteLine(c.ToString());
        }

        public void WypiszGry(Dictionary<int, Katalog> gry)
        {
            foreach (Katalog k in gry.Values)
                Console.WriteLine(k.ToString());
        }

        public void WypiszOpisyStanu(ObservableCollection<OpisStanu> opis)
        {
            foreach (OpisStanu o in opis)
                Console.WriteLine(o.ToString());
        }

        public void WypiszZdarzenia(ObservableCollection<Zdarzenie> zdarznie)
        {
            foreach (Zdarzenie z in zdarznie)
                Console.WriteLine(z.ToString());
        }

        public void WypiszWszystko()
        {
            Console.WriteLine("Gracze");
            WypiszGraczy(dataRepository.PobierzWszystkichGraczy());
            Console.WriteLine("Gry");
            WypiszGry(dataRepository.PobierzWszystkieGry());
            Console.WriteLine("Zdarzenia");
            WypiszZdarzenia(dataRepository.PobierzWszystkiePartie())
                ;
            //WypiszOpisyStanu(dataRepository.PobierzWszystkieOpisyStanu());
        }
        #endregion

        #region OpisStanu

        public OpisStanu DodajOpisStanu(int id, Katalog gra, int iloscGraczy, bool czySkonczona, double mnoznikWygranej)
        {
            OpisStanu opis = new OpisStanu(id, gra, iloscGraczy, czySkonczona, mnoznikWygranej);
            dataRepository.DodajOpisStanu(opis);
            return opis;
        }

        public void PobierzOpisStanuPoId(int id)
        {
            dataRepository.PobierzOpisStanuPoId(id);
        }

        public void UaktualnijOpisStanuPoId(int id, int nowyId, Katalog gra, int iloscGraczy, bool czySkonczona, double mnoznikWygranej)
        {
            OpisStanu opis = DodajOpisStanu(nowyId, gra, iloscGraczy, czySkonczona, mnoznikWygranej);
            dataRepository.UaktualnijOpisStanuPoId(id, opis);
        }
        public void UsunOpisStanuPoId(int id)
        {
            dataRepository.UsunOpisStanuPoId(id);
        }
        #endregion

   
    }
}
