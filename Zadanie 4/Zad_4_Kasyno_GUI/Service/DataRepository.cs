﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zad4_4_Kasyno_GUI;
using Data;

namespace Zad4_4_Kasyno_GUI.Service
{
    public class DataRepository : IDisposable
    {
        private AdventureWorksDataContext Context { get; }

        public DataRepository()
        {
            Context = new AdventureWorksDataContext();
        }

        public DataRepository(string connection)
        {
            Context = new AdventureWorksDataContext(connection);
        }

        #region Create

        public void AddKlient(out int id,  Klienci klient)
        {
            Klienci nowyKlient = new Klienci()
            {
                
                imieK = klient.imieK,
                nazwiskoK = klient.nazwiskoK,
                adres = klient.adres,
                telefon = klient.telefon,
                portfel = klient.portfel
            };
            
            Context.Klienci.InsertOnSubmit(nowyKlient);
            Context.SubmitChanges();
            id = nowyKlient.idK;
            
            
        }

        public void AddGra (out int id, Gry gra)
        {
            Gry nowaGra = new Gry()
            {
                nazwa = gra.nazwa,
                wygrana = gra.wygrana,
                cenaWejsciowa = gra.cenaWejsciowa

            };
            Context.Gry.InsertOnSubmit(nowaGra);
            Context.SubmitChanges();
            id = nowaGra.idG;
        }

      

        #endregion

        #region Read
        public IEnumerable<Klienci> GetContent(int id)
        {
            return from _klienci in Context.Klienci
                   where _klienci.idK.Equals(id)
                   select _klienci;
        }

        public IEnumerable<Klienci> GetAllContent()
        {
            return from _klienci in Context.Klienci
                   select _klienci;
        }

        public IEnumerable<Gry> GetGra(int id)
        {
            return from _gry in Context.Gry
                   where _gry.idG.Equals(id)
                   select _gry;
        }

        public IEnumerable<Gry> GetAllGry()
        {
            return from _gry in Context.Gry
                   select _gry;
        }

        #endregion



        #region Update
        public void UpdateContent(int id, Klienci newKlient)
        {
            
            Klienci klient = GetContent(id).SingleOrDefault();

            //klient.idK = newKlient.idK;
            klient.imieK = newKlient.imieK;
            klient.nazwiskoK = newKlient.nazwiskoK;

            if (!newKlient.telefon.Equals(klient.telefon))
            {
                klient.telefon = newKlient.telefon; 
            }

            klient.adres = newKlient.adres;
            klient.portfel = newKlient.portfel;
        
            Context.SubmitChanges();
        }

        public void UpdateGra (int id, Gry nowaGra)
        {
            Gry gra = GetGra(id).SingleOrDefault();
            gra.nazwa = nowaGra.nazwa;
            gra.wygrana = nowaGra.wygrana;
            gra.cenaWejsciowa = nowaGra.cenaWejsciowa;
            Context.SubmitChanges();
        }
        #endregion

        #region Delete
        public void DeleteContent(int id)
        {
            Klienci klient = GetContent(id).SingleOrDefault();
            IEnumerable<Partie> partie = from _Partie in Context.Partie
                                                           where _Partie.idK.Equals(klient.idK)
                                                           select _Partie;

            foreach (Partie item in partie)
            {
                Context.Partie.DeleteOnSubmit(item);
            }

            Context.Klienci.DeleteOnSubmit(klient);

            Context.SubmitChanges();
        }

        public void DeleteGra(int id)
        {
            Gry gra = GetGra(id).SingleOrDefault();
            IEnumerable<OpisyStanu> partie = from _Partie in Context.OpisyStanu
                                         where _Partie.idG.Equals(gra.idG)
                                         select _Partie;

            foreach (OpisyStanu item in partie)
            {
                Context.OpisyStanu.DeleteOnSubmit(item);
            }

            Context.Gry.DeleteOnSubmit(gra);

            Context.SubmitChanges();
        }
        #endregion

        [Conditional("DEBUG")]
        public void TruncateAllData()
        {
            Context.Partie.DeleteAllOnSubmit(Context.Partie);
            Context.Klienci.DeleteAllOnSubmit(Context.Klienci);
            Context.Gry.DeleteAllOnSubmit(Context.Gry);
            //Context.OpisyStanu.DeleteAllOnSubmit(Context.OpisyStanu);
            Context.SubmitChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
