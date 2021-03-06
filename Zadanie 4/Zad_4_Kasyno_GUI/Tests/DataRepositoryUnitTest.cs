﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class DataRepositoryUnitTest : IClassFixture<DataRepositoryFixture>
    {
        private DataRepositoryFixture Fixture { get; set; }
        public DataRepositoryUnitTest(DataRepositoryFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void CRUDTest()
        {
            try
            {
                int id=-1;
                IEnumerable<Klienci> listFromBase = Fixture.ServiceUnderTest.GetAllContent();
                Assert.Empty(listFromBase);
                
                int count = listFromBase.Count();

                //Create
                Fixture.ServiceUnderTest.AddKlient(out id, TestDataGenerator.Klient1);
                Assert.Equal(count+1, listFromBase.Count());
                Fixture.ServiceUnderTest.AddKlient(out id, TestDataGenerator.Klient2);
                
               
                Assert.Equal(2, listFromBase.Count());               
                Assert.Equal("Sebastian", listFromBase.ElementAt(0).imieK);
                Assert.Equal("Krzysztof", listFromBase.ElementAt(1).imieK);

                //Read
                Klienci cFromBase = Fixture.ServiceUnderTest.GetContent(12).SingleOrDefault();
                
                Assert.Equal("Sebastian", cFromBase.imieK);
                Assert.Equal("Sebastian", listFromBase.ElementAt(0).imieK);

                //Update
                Fixture.ServiceUnderTest.UpdateContent(12, TestDataGenerator.Klient1);
                cFromBase = Fixture.ServiceUnderTest.GetContent(12).SingleOrDefault();
                Assert.Equal(12, cFromBase.idK);
                Assert.Equal("Sebastian", cFromBase.imieK);

                //Delete
                Fixture.ServiceUnderTest.DeleteContent(12);
          

                Assert.Single(listFromBase);
                Assert.Equal("Krzysztof", listFromBase.ElementAt(0).imieK);
            }
            finally
            {
                Fixture.ServiceUnderTest.TruncateAllData();
            }
        }

    }
}
