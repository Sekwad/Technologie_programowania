using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestData
{
    internal class TestDataGenerator
    {
        internal static Klienci Klient1 { get; set; } = new Klienci()
        {
            idK = 1,
            imieK = "Sebastian",
            nazwiskoK = "Marcinkowski",
            adres = "Brzeziny",
            telefon = "123456789",
        };

        internal static Klienci Klient2 { get; set; } = new Klienci()
        {
            idK = 2,
            imieK = "Krzysztof",
            nazwiskoK = "Kosmala",
            adres = "Lodz",
            telefon = "123456798",
        };

        internal static Klienci Klient3 { get; set; } = new Klienci()
        {
            idK = 3,
            imieK = "Bartosz",
            nazwiskoK = "Bolczak",
            adres = "Lodz",
            telefon = "123457689",
        };
    }
}
