using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_1_Kasyno
{
    public class DataRepository
    {
        public DataRepository(IWypelnianie wyp)
        {
            wyp.Wypelnij(DataContext);
        }

        protected DataContext DataContext = new DataContext();

        #region Gracz
        public void DodajGracza(Wykaz gracz)
        {
            if (gracz != null)
                DataContext.Gracze.Add(gracz);
            else
                throw new ArgumentNullException();
        }
        public Wykaz PobierzGracza(int i)
        {
            if (DataContext.Gracze.Exists(x => x.Id == i))
                return DataContext.Gracze.First(x => x.Id == i);
            else
                throw new ArgumentNullException();
        }

        public List<Wykaz> PobierzWszystkichGraczy()
        {
            return DataContext.Gracze;
        }

        public bool UaktualnijGraczaPoId(int id, Wykaz nowyGracz)
        {
            if (nowyGracz != null)
            {
                if (DataContext.Gracze.Exists(x => x.Id == id))
                {
                    Wykaz gracz = DataContext.Gracze.First(x => x.Id == id);
                    gracz.Imie = nowyGracz.Imie;
                    gracz.Nazwisko = nowyGracz.Nazwisko;
                    gracz.Telefon = nowyGracz.Telefon;
                    gracz.Adres = nowyGracz.Adres;
                    return true;
                }
                return false;
            }
            else
                throw new ArgumentNullException();
        }


        public bool UsunGraczaPoId(int id)
        {
            if (DataContext.Gracze.Exists(x => x.Id == id))
            {
                Wykaz gracz = DataContext.Gracze.First(x => x.Id == id);
                return DataContext.Gracze.Remove(gracz);
            }
            return false;

        }

        public Wykaz PobierzGraczaPoId(int id)
        {
            if (DataContext.Gracze.Exists(x => x.Id == id))
            {

                return DataContext.Gracze.First(x => x.Id == id);
            }
            else
                throw new ArgumentNullException();

        }
        #endregion

        #region Gra

        public void DodajGre(Katalog gra)
        {
            if (gra != null)
            {
                DataContext.Gry.Add(gra.Id, gra);
            }
            else
                throw new ArgumentNullException();
        }

        public Katalog PobierzGrePoId (int id)
        {
            return DataContext.Gry[id];
        }

        public Dictionary <int,Katalog> PobierzWszystkieGry()
        {
            return DataContext.Gry;
        }

        public void UaktualnijGrePoId(int id, Katalog nowaGra)
        {
            if (nowaGra != null)
            {

                Katalog gra = DataContext.Gry[id];
                if (gra != null)
                {
                    gra.Nazwa = nowaGra.Nazwa;
                    gra.Wygrana = nowaGra.Wygrana;
                    gra.CenaWejsciowa = nowaGra.CenaWejsciowa;
                }
                else
                    throw new NullReferenceException();
            }
            else
                throw new ArgumentNullException();
        }

        public bool UsunGrePoId (int id)
        {
            return DataContext.Gry.Remove(id);
        }

        #endregion

        #region OpisStanu

        public void DodajOpisStanu(OpisStanu opisStanu)
        {
            if (opisStanu != null)
                DataContext.OpisyStanu.Add(opisStanu);
            else
                throw new ArgumentNullException();
        }

        public OpisStanu PobierzOpisStanuPoId(int id)
        {
            if (DataContext.OpisyStanu.Any(x => x.Id == id))
                return DataContext.OpisyStanu.First(x => x.Id == id);
            else
                return null;
        }

        public ObservableCollection <OpisStanu> PobierzWszystkieOpisStanu()
        {
            return DataContext.OpisyStanu;
        }

        public bool UaktualnijOpisStanuPoId(int id, OpisStanu nowyOpisStanu)
        {
            if (nowyOpisStanu != null)
            {
                if (DataContext.OpisyStanu.Any(x => x.Id == id))
                {
                    OpisStanu opisStanu = DataContext.OpisyStanu.First(x => x.Id == id);
                    opisStanu.Gra = nowyOpisStanu.Gra;
                    opisStanu.IloscGraczy = nowyOpisStanu.IloscGraczy;
                    opisStanu.MnoznikWygranej = nowyOpisStanu.MnoznikWygranej;
                    opisStanu.CzySkonczona = nowyOpisStanu.CzySkonczona;
                    return true;
                }
                return false;
            }
            else
                throw new ArgumentNullException();
        }

        public bool UsunOpisStanuPoId(int id)
        {
            if (DataContext.OpisyStanu.Any(x => x.Id == id))
            {
                OpisStanu ProductVariant = DataContext.OpisyStanu.First(x => x.Id == id);
                return DataContext.OpisyStanu.Remove(ProductVariant);
            }
            return false;
        }

        #endregion

        #region Partie

        public void DodajPartie(Zdarzenie partia)
        {
            if (partia != null)
                DataContext.Partie.Add(partia);
            else
                throw new ArgumentNullException();
        }

        public Zdarzenie PobierzPartiePoId (int id)
        {
            if (DataContext.Partie.Any(x => x.Id == id))
                return DataContext.Partie.First(x => x.Id == id);
            else
                return null;
        }

        public bool UaktualnijPartiePoId (int id, Zdarzenie nowaPartia)
        {
            if (nowaPartia != null)
            {
                if (DataContext.Partie.Any(x => x.Id == id))
                {
                    Zdarzenie partia = DataContext.Partie.First(x => x.Id == id);
                    partia.DataGry = nowaPartia.DataGry;
                    partia.Opisstanu = nowaPartia.Opisstanu;
                    partia.WygranaKwota = nowaPartia.WygranaKwota;
                    partia.Wykaz = nowaPartia.Wykaz;
                    return true;
                }
                return false;
            }
            else
                throw new ArgumentNullException();
        }

        public ObservableCollection<Zdarzenie> PobierzWszystkiePartie()
        {
            return DataContext.Partie;
        }

        public bool UsunPartiePoId(int id)
        {
            if (DataContext.Partie.Any(x => x.Id == id))
            {
                Zdarzenie partia = DataContext.Partie.First(x => x.Id == id);
                return DataContext.Partie.Remove(partia);
            }
            return false;
        }

        #endregion

    }
}
