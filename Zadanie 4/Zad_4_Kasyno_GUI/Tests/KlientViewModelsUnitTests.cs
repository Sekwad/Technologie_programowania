using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestData;
using Xunit;
using Zad_4_Kasyno.ViewModels;

namespace Tests
{
    public class KlientViewModelsUnitTests : IClassFixture<DataRepositoryFixture>
    {
        private DataRepositoryFixture Fixture { get; set; }
    public KlientViewModelsUnitTests(DataRepositoryFixture fixture)
    {
        Fixture = fixture;
    }


    [Fact]
    public void ConstructorTest()
    {
        KlientViewModels viewModel = new KlientViewModels(DataRepositoryFixture.ConnectionString);

        try
        {
            Assert.Equal(0, viewModel.ID);
            Assert.NotNull(viewModel.Klienci);
            Assert.Empty(viewModel.Klienci);
            Assert.Null(viewModel.WybranyKlient);
            Assert.Equal(0, viewModel.ID);
            Assert.Equal(string.Empty, viewModel.Imie);
            Assert.Equal(string.Empty, viewModel.Nazwisko);
            Assert.Equal(string.Empty, viewModel.Adres);
            Assert.Equal(string.Empty, viewModel.Telefon);
        }
        finally
        {
            Fixture.ServiceUnderTest.TruncateAllData();
        }
    }
    [Fact]
    public void ClearCommandTest()
    {
            KlientViewModels viewModel = new KlientViewModels(DataRepositoryFixture.ConnectionString)
        {
                Imie = TestDataGenerator.klient3.imieK,
        };

            Assert.Equal(TestDataGenerator.klient3.imieK, viewModel.Imie);

        viewModel.ClearCommand.Execute(null);

        Assert.True(viewModel.ClearCommand.CanExecute(null));
        Assert.Equal(string.Empty, viewModel.Imie);
    }

    [Fact]
    public void DeleteCommandTest()
    {
            KlientViewModels viewModel = new KlientViewModels(DataRepositoryFixture.ConnectionString);
        viewModel.Klienci.Add(TestDataGenerator.klient3);
        viewModel.WybranyKlient = TestDataGenerator.klient3;

        try
        {
            Assert.Single(viewModel.Klienci);

            viewModel.DeleteCommand.Execute(null);

            Assert.True(viewModel.DeleteCommand.CanExecute(null));
            Assert.Empty(viewModel.Klienci);
        }
        finally
        {
            Fixture.ServiceUnderTest.TruncateAllData();
        }
    }

    [Fact]
    public void EditCommandTest()
    {
            KlientViewModels viewModel = new KlientViewModels(DataRepositoryFixture.ConnectionString);
        viewModel.WybranyKlient = TestDataGenerator.klient3;

        viewModel.EditCommand.Execute(null);

        Assert.Equal(TestDataGenerator.klient3.idK, viewModel.ID);
        Assert.Equal(TestDataGenerator.klient3.imieK, viewModel.Imie);
    }

    [Fact]
    public void UpdateCommandTest()
    {
            KlientViewModels viewModel = new KlientViewModels(DataRepositoryFixture.ConnectionString);
        viewModel.Klienci.Add(TestDataGenerator.klient3);
        viewModel.ID = 3;
            viewModel.Adres = "Lodz";

        try
        {
            Assert.Single(viewModel.Klienci);
            Assert.Equal(TestDataGenerator.klient3.adres, viewModel.Klienci.First().adres);
            Assert.True(viewModel.UpdateCommand.CanExecute(null));

            viewModel.UpdateCommand.Execute(null);

            Assert.Equal("Lodz", viewModel.Klienci.First().adres);
        }
        finally
        {
            Fixture.ServiceUnderTest.TruncateAllData();
        }

    }
    }

}

