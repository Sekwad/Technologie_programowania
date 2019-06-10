using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad4_4_Kasyno_GUI.Service;

namespace Zad_4_Kasyno.Models
{
    public class ListaGier
    {
        private static string DBRelativePath { get; set; } = @"KasynoT.mdf";
        private static string TestingWorkingFolder { get; set; } = Environment.CurrentDirectory;
        private static string DBPath { get; set; } = Path.Combine(TestingWorkingFolder, DBRelativePath);
        public static string ConnectionString { get; set; } = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DBPath};Integrated Security = True; Connect Timeout = 30;";
        private DataRepository _DataRepository { get; set; } = new DataRepository(ConnectionString);
        private readonly List<Gry> _gry = new List<Gry>();

        public IEnumerable<Gry> GryFromModel
        {
            get
            {
                return new List<Gry>(_gry);
            }
        }

        public ListaGier()
        {
            _gry.AddRange(GetAllGry());
        }

        public ListaGier(string connection)
        {
            _DataRepository = new DataRepository(connection);
            _gry.AddRange(GetAllGry());
        }

        internal void AddGra(out int id, Gry gra)
        {
            _DataRepository.AddGra(out id, gra);
        }

        internal IEnumerable<Gry> GetAllGry()
        {
            return _DataRepository.GetAllGry();
        }

        internal void DeleteKlient(Gry gra)
        {
            _DataRepository.DeleteGra(gra.idG);
        }

        internal void UpdateKlient(Gry gra)
        {
            _DataRepository.UpdateGra(gra.idG, gra);
        }
    }
}
