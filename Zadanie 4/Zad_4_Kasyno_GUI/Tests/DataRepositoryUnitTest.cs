using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class DataRepositoryUnitTest 
    {
        private DataRepositoryFixture Fixture { get; set; }
        public DataRepositoryUnitTest()
        {
            Fixture = new DataRepositoryFixture();
        }

        [Fact]
        public void CRUDTest()
        {
            try
            {
                int id = -1;
                IEnumerable<Klienci> listFromBase = Fixture.ServiceUnderTest.GetAllContent();
                Assert.Empty(listFromBase);

                int count = listFromBase.Count();

                //Create
                Fixture.ServiceUnderTest.AddKlient(out id, TestDataGenerator.klient1);
                Assert.Equal(count+1, listFromBase.Count());
                Fixture.ServiceUnderTest.AddKlient(out id, TestDataGenerator.klient2);
                Assert.Equal(2, id);
                Assert.Equal(2, listFromBase.Count());

                Assert.Equal(1, listFromBase.ElementAt(0).idK);
                Assert.Equal("Sebastian", listFromBase.ElementAt(0).imieK);
                Assert.Equal(2, listFromBase.ElementAt(1).idK);
                Assert.Equal("Krzysztof", listFromBase.ElementAt(1).imieK);

                //Read
                Klienci cFromBase = Fixture.ServiceUnderTest.GetContent(1).SingleOrDefault();
                Assert.Equal(1, cFromBase.idK);
                Assert.Equal("Sebastian", cFromBase.imieK);

                //Update
                Fixture.ServiceUnderTest.UpdateContent(2, TestDataGenerator.klient1);
                cFromBase = Fixture.ServiceUnderTest.GetContent(2).SingleOrDefault();
                Assert.Equal(2, cFromBase.idK);
                Assert.Equal("Krzysztof", cFromBase.imieK);

                //Delete
                Fixture.ServiceUnderTest.DeleteContent(2);
          

                Assert.Single(listFromBase);
                Assert.Equal(1, listFromBase.ElementAt(0).idK);
                Assert.Equal("Sebastian", listFromBase.ElementAt(0).imieK);
            }
            finally
            {
                Fixture.ServiceUnderTest.TruncateAllData();
            }
        }
    }
}
