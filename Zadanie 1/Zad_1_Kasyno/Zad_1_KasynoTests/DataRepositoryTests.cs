using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad_1_Kasyno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad_1_Kasyno_Test;

namespace Zad_1_Kasyno.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        [TestMethod()]
        public void PobierzGraczaTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Wykaz gracz5 = new Wykaz(5, "Maciek", "Bolczak", "87434287", "Belchatow");
            repoTest.DodajGracza(gracz5);
            Assert.AreEqual(gracz5, repoTest.PobierzGraczaPoId(5));
        }

        [TestMethod()]
        public void DodajGraczaTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkichGraczy().Count);
            Wykaz gracz5 = new Wykaz(4, "Maciek", "Bolczak", "87434287", "Belchatow");
            repoTest.DodajGracza(gracz5);
            Assert.AreEqual(5, repoTest.PobierzWszystkichGraczy().Count);
        }


        [TestMethod()]
        public void PobierzWszystkichGraczyTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkichGraczy().Count);
        }

        [TestMethod()]
        public void UaktualnijGraczaPoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Wykaz nowyGracz = new Wykaz(5, "Maciek", "Bolczak", "87134287", "Belchatow");
            Wykaz gracz = repoTest.PobierzGraczaPoId(1);

            Assert.AreNotEqual(gracz.Id , nowyGracz.Id );
            Assert.AreNotEqual(gracz.Imie , nowyGracz.Imie );
            Assert.AreNotEqual(gracz.Nazwisko , nowyGracz.Nazwisko );
            Assert.AreNotEqual(gracz.Telefon , nowyGracz.Telefon );
            Assert.AreNotEqual(gracz.Adres , nowyGracz.Adres );

            Assert.AreNotEqual(false , repoTest.UaktualnijGraczaPoId(1, nowyGracz ));

            Assert.AreNotEqual(gracz.Id, nowyGracz.Id);
            Assert.AreEqual(gracz.Imie, nowyGracz.Imie);
            Assert.AreEqual(gracz.Nazwisko, nowyGracz.Nazwisko);
            Assert.AreEqual(gracz.Telefon, nowyGracz.Telefon);
            Assert.AreEqual(gracz.Adres, nowyGracz.Adres);
        }

        [TestMethod()]
        public void UsunGraczaPoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkichGraczy().Count);
            Assert.AreNotEqual(false, repoTest.UsunGraczaPoId(1));
            Assert.AreEqual(3, repoTest.PobierzWszystkichGraczy().Count);

        }



        [TestMethod()]
        public void DodajGreTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkieGry().Count);
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            repoTest.DodajGre(gra5);
            Assert.AreEqual(5, repoTest.PobierzWszystkieGry().Count);
        }

        [TestMethod()]
        public void PobierzGrePoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkieGry().Count);
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            repoTest.DodajGre(gra5);
            Assert.AreEqual(gra5, repoTest.PobierzGrePoId(5));
        }

        [TestMethod()]
        public void PobierzWszystkieGryTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkieGry().Count);
        }

        [TestMethod()]
        public void UaktualnijGrePoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Katalog nowaGra = new Katalog(5, "Kosci", 1, 50);
            Katalog gra = repoTest.PobierzGrePoId(1);

            Assert.AreNotEqual(gra.Id , nowaGra.Id );
            Assert.AreNotEqual(gra.Nazwa , nowaGra.Nazwa );
            Assert.AreNotEqual(gra.Wygrana , nowaGra.Wygrana );
            Assert.AreNotEqual(gra.CenaWejsciowa , nowaGra.CenaWejsciowa );

            repoTest.UaktualnijGrePoId(1, nowaGra);

            Assert.AreNotEqual(gra.Id, nowaGra.Id);
            Assert.AreEqual(gra.Nazwa, nowaGra.Nazwa);
            Assert.AreEqual(gra.Wygrana, nowaGra.Wygrana);
            Assert.AreEqual(gra.CenaWejsciowa, nowaGra.CenaWejsciowa);

        }

        [TestMethod()]
        public void UsunGrePoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkieGry().Count);
            Assert.AreEqual(true, repoTest.UsunGrePoId(1));
            Assert.AreEqual(3, repoTest.PobierzWszystkieGry().Count);
        }

        [TestMethod()]
        public void DodajOpisStanuTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkieOpisStanu().Count);
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            OpisStanu stan5 = new OpisStanu(5, gra5, 5, false, 1);
            repoTest.DodajOpisStanu(stan5);
            Assert.AreEqual(5, repoTest.PobierzWszystkieOpisStanu().Count);
        }

        [TestMethod()]
        public void PobierzOpisStanuPoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            OpisStanu stan5 = new OpisStanu(5, gra5, 5, false, 1);
            repoTest.DodajOpisStanu(stan5);
            Assert.AreEqual(stan5, repoTest.PobierzOpisStanuPoId(5));
        }

        [TestMethod()]
        public void PobierzWszystkieOpisStanuTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkieOpisStanu().Count);

        }

        [TestMethod()]
        public void UaktualnijOpisStanuPoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            OpisStanu nowyStan = new OpisStanu(5, gra5, 5, false, 1);
            OpisStanu stan = repoTest.PobierzOpisStanuPoId(1);

            Assert.AreNotEqual(stan.Id, nowyStan.Id);
            Assert.AreNotEqual(stan.IloscGraczy , nowyStan.IloscGraczy );
            Assert.AreNotEqual(stan.Gra, nowyStan.Gra);
            Assert.AreNotEqual(stan.MnoznikWygranej , nowyStan.MnoznikWygranej );

            Assert.AreEqual(true , repoTest.UaktualnijOpisStanuPoId(1,nowyStan) );

            Assert.AreNotEqual(stan.Id, nowyStan.Id);
            Assert.AreEqual(stan.CzySkonczona, nowyStan.CzySkonczona);
            Assert.AreEqual(stan.IloscGraczy, nowyStan.IloscGraczy);
            Assert.AreEqual(stan.MnoznikWygranej, nowyStan.MnoznikWygranej);
            Assert.AreEqual(stan.Gra, nowyStan.Gra);
        }

        [TestMethod()]
        public void UsunOpisStanuPoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkieOpisStanu().Count);
            Assert.AreNotEqual(false, repoTest.UsunOpisStanuPoId(1));
            Assert.AreEqual(3, repoTest.PobierzWszystkieOpisStanu().Count);
        }

        [TestMethod()]
        public void DodajPartieTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkiePartie().Count);
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            OpisStanu stan5 = new OpisStanu(5, gra5, 5, false, 1);
            Wykaz gracz5 = new Wykaz(4, "Maciek", "Bolczak", "87434287", "Belchatow");
            Zdarzenie partia5 = new Zdarzenie(5, stan5, gracz5, new DateTime(2019, 5, 13));
            repoTest.DodajPartie(partia5);
            Assert.AreEqual(5, repoTest.PobierzWszystkiePartie().Count);
        }

        [TestMethod()]
        public void PobierzPartiePoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkiePartie().Count);
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            OpisStanu stan5 = new OpisStanu(5, gra5, 5, false, 1);
            Wykaz gracz5 = new Wykaz(4, "Maciek", "Bolczak", "87434287", "Belchatow");
            Zdarzenie partia5 = new Zdarzenie(5, stan5, gracz5, new DateTime(2019, 5, 13));
            repoTest.DodajPartie(partia5);
            Assert.AreEqual(partia5, repoTest.PobierzPartiePoId(5));
        }

        [TestMethod()]
        public void UaktualnijPartiePoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkiePartie().Count);
            Katalog gra5 = new Katalog(5, "Kosci", 1, 50);
            OpisStanu stan5 = new OpisStanu(5, gra5, 5, false, 1);
            Wykaz gracz5 = new Wykaz(4, "Maciek", "Bolczak", "87434287", "Belchatow");
            Zdarzenie nowaPartia = new Zdarzenie(5, stan5, gracz5, new DateTime(2019, 5, 13));
            Zdarzenie partia = repoTest.PobierzPartiePoId(1);

            Assert.AreNotEqual(partia.Id , nowaPartia.Id );
            Assert.AreNotEqual(partia.Opisstanu , nowaPartia. Opisstanu);
            Assert.AreNotEqual(partia.WygranaKwota , nowaPartia.WygranaKwota );
            Assert.AreNotEqual(partia.Wykaz , nowaPartia.Wykaz );
            Assert.AreNotEqual(partia.DataGry , nowaPartia.DataGry );

            Assert.AreEqual(true, repoTest.UaktualnijPartiePoId(1, nowaPartia));

            Assert.AreNotEqual(partia.Id, nowaPartia.Id);
            Assert.AreEqual(partia.Opisstanu, nowaPartia.Opisstanu);
            Assert.AreEqual(partia.WygranaKwota, nowaPartia.WygranaKwota);
            Assert.AreEqual(partia.Wykaz, nowaPartia.Wykaz);
            Assert.AreEqual(partia.DataGry, nowaPartia.DataGry);
        }

        [TestMethod()]
        public void PobierzWszystkiePartieTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkiePartie().Count);
        }

        [TestMethod()]
        public void UsunPartiePoIdTest()
        {
            DataRepository repoTest = new DataRepository(new WypelnijBaze());
            Assert.AreEqual(4, repoTest.PobierzWszystkiePartie().Count);
            Assert.AreNotEqual(false, repoTest.UsunPartiePoId(1));
            Assert.AreEqual(3, repoTest.PobierzWszystkiePartie().Count);
        }
    }
}