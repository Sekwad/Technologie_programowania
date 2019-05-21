using System;
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
    public class DataService : IDisposable
    {
        private AdventureWorksDataContext Context { get; }

        public DataService()
        {
            Context = new AdventureWorksDataContext();
        }

        public DataService(string connection)
        {
            Context = new AdventureWorksDataContext(connection);
        }

        #region Create
    

        
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
        #endregion

        #region Update
        public void UpdateContent(int id, Klienci newKlient)
        {
            Klienci klient = GetContent(id).SingleOrDefault();

            klient.idK = newKlient.idK;
            klient.imieK = newKlient.imieK ;
            klient.nazwiskoK = newKlient.nazwiskoK ;
            klient.telefon = newKlient.telefon ;
            klient.adres = newKlient.adres ;

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
        #endregion

        [Conditional("DEBUG")]
        public void TruncateAllData()
        {
            Context.Partie.DeleteAllOnSubmit(Context.Partie);
            Context.Klienci.DeleteAllOnSubmit(Context.Klienci);
            Context.SubmitChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
