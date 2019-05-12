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

        #region Zdarzenia

        public Zdarzenie DodajZdarzenie(int id, OpisStanu opisStanu, Wykaz wykaz, DateTime dataGry)
        {
            Zdarzenie z = new Zdarzenie(id, opisStanu, wykaz, dataGry);
            dataRepository.DodajPartie(z);
            return z;
        }

        public void PobierzZdarzeniePoId(int id)
        {
            dataRepository.PobierzPartiePoId(id);
        }

        public void UaktualnijZdarzeniePoId(int id, int noweId, OpisStanu opisStanu, Wykaz wykaz, double ilosc, DateTime dataGry)
        {
            Zdarzenie z = DodajZdarzenie(noweId, opisStanu, wykaz, dataGry);
            dataRepository.UaktualnijPartiePoId(id, z);
        }
        public void UsunZdarzeniePoId(int id)
        {
            dataRepository.UsunPartiePoId(id);
        }
        #endregion

        #region Gry

        public Katalog DodajGre(int id, string nazwa, int iloscGraczy, double stawka)
        {
            Katalog k = new Katalog(id, nazwa, iloscGraczy, stawka);
            dataRepository.DodajGre(k);
            return k;
        }

        public void PobierzGrePoId(int id)
        {
            dataRepository.PobierzGrePoId(id);
        }

        public void UaktualnijGrePoId(int id, int noweId, string nazwa, int iloscGraczy, double stawka)
        {
            Katalog k = DodajGre(noweId, nazwa, iloscGraczy, stawka);
            dataRepository.UaktualnijGrePoId(id, k);
        }

        public void UsunKsiazkePoId(int id)
        {
            dataRepository.UsunGrePoId(id);
        }
        #endregion

        #region Gracz
        public Wykaz DodajGracza(int id, string imie, string nazwisko, string telefon, string adres)
        {
            Wykaz cz = new Wykaz(id, imie, nazwisko, telefon, adres);
            dataRepository.DodajGracza(cz);
            return cz;

        }

        public void PobierzGraczaPoId(int id)
        {
            dataRepository.PobierzGraczaPoId(id);
        }

        public void UaktualnijGraczaNaId(int id, int noweId, string imie, string nazwisko, string telefon, string adres)
        {
            Wykaz gr = DodajGracza(noweId, imie, nazwisko, telefon, adres);
            dataRepository.UaktualnijGraczaPoId(id, gr);
        }

        public void UsunGraczaPoID(int id)
        {
            dataRepository.UsunGraczaPoId(id);
        }
        #endregion

        #region Wyszukiwanie danych

        public void WyszukajPoImieniu(string name)
        {
            foreach (Wykaz w in dataRepository.PobierzWszystkichGraczy())
            {
                if (name == w.Imie)
                {
                    Console.WriteLine(w.ToString());
                }
            }
        }

        public void WyszukajPoNazwisku(string name)
        {
            foreach (Wykaz w in dataRepository.PobierzWszystkichGraczy())
            {
                if (name == w.Nazwisko)
                {
                    Console.WriteLine(w.ToString());
                }
            }
        }

        public void WyszukajPoTelefonie(string name)
        {
            foreach (Wykaz w in dataRepository.PobierzWszystkichGraczy())
            {
                if (name == w.Telefon)
                {
                    Console.WriteLine(w.ToString());
                }
            }
        }

        public void WyszukajPoAdresie(string name)
        {
            foreach (Wykaz w in dataRepository.PobierzWszystkichGraczy())
            {
                if (name == w.Adres)
                {
                    Console.WriteLine(w.ToString());
                }
            }
        }

        public void WyszukajPoNazwie(string name)
        {
            foreach (Katalog k in dataRepository.PobierzWszystkieGry().Values)
            {
                if (name == k.Nazwa)
                {
                    Console.WriteLine(k.ToString());
                }
            }
        }

        #endregion
    }
}
