using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad4_4_Kasyno_GUI.Service;

namespace Tests.TestData
{
    public class DataRepositoryFixture : IDisposable
    {
        private static string DBRelativePath { get; set; } = @"TestData\AdventureTest.mdf";
        private static string TestingWorkingFolder { get; set; } = Environment.CurrentDirectory;
        private static string DBPath { get; set; } = Path.Combine(TestingWorkingFolder, DBRelativePath);
        public static string ConnectionString { get; set; } = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DBPath};Integrated Security = True; Connect Timeout = 30;";

        public DataRepository ServiceUnderTest { get; }

        public DataRepositoryFixture()
        {
            ServiceUnderTest = new DataRepository(ConnectionString);
            ServiceUnderTest.TruncateAllData();
        }

        public void Dispose()
        {
            ServiceUnderTest.Dispose();
        }

    }
}
