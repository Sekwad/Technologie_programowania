using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Zad4_4_Kasyno_GUI.Service;
using Data;
using System.IO;

namespace Zad_4_Kasyno.Models
{
    public class ListaKlientow
    {
        private static string DBRelativePath { get; set; } = @"KasynoT.mdf";
        private static string TestingWorkingFolder { get; set; } = Environment.CurrentDirectory;
        private static string DBPath { get; set; } = Path.Combine(TestingWorkingFolder, DBRelativePath);
        public static string ConnectionString { get; set; } = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DBPath};Integrated Security = True; Connect Timeout = 30;";
        private DataRepository _DataRepository { get; set; } = new DataRepository(ConnectionString);
        private readonly List<Klienci> _klienci = new List<Klienci>();

        public IEnumerable<Klienci> KlienciFromModel
        {
            get
            {
                return new List<Klienci>(_klienci);
            }
        }

        public ListaKlientow()
        {
            _klienci.AddRange(GetAllKlienci());
        }

        public ListaKlientow(string connection)
        {
            _DataRepository = new DataRepository(connection);
            _klienci.AddRange(GetAllKlienci());
        }

        internal void AddKlient(out int id, Klienci Klient)
        {
            _DataRepository.AddKlient(out id, Klient);
        }

        internal IEnumerable<Klienci> GetAllKlienci()
        {
            return _DataRepository.GetAllContent();
        }

        internal void DeleteKlient(Klienci Klient)
        {
            _DataRepository.DeleteContent(Klient.idK);
        }

        internal void UpdateKlient(Klienci Klient)
        {
            _DataRepository.UpdateContent(Klient.idK, Klient);
        }


    }
}
