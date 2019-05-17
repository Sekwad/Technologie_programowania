using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad_1_Kasyno;

namespace Zad_1_Kasyno_Test
{
    class WypelnijBaze : Wypelnianie
    {
        public void Wypelnij(DataContext dataContext)
        {
            Katalog gra1 = new Katalog(1, "Poker", 3, 200);
            Katalog gra2 = new Katalog(2, "Ruletka", 5, 100);
            Katalog gra3 = new Katalog(3, "Black Jack", 2, 100);
            Katalog gra4 = new Katalog(4, "Jednoręki bandyta", 1, 10);

            dataContext.Gry.Add(gra1.Id, gra1);
            dataContext.Gry.Add(gra2.Id, gra2);
            dataContext.Gry.Add(gra3.Id, gra3);
            dataContext.Gry.Add(gra4.Id, gra4);


            Wykaz gracz1 = new Wykaz(1, "Krzysztof", "Kosmala", "56780187", "Łódzka");
            Wykaz gracz2 = new Wykaz(2, "Maciek", "Kozłowski", "56780666", "Pabianicka");
            Wykaz gracz3 = new Wykaz(3, "Tomasz", "Gromadko", "52231187", "Odrzanska");
            Wykaz gracz4 = new Wykaz(4, "Artur", "Badura", "87434887", "Joanny");

            dataContext.Gracze.Add(gracz1);
            dataContext.Gracze.Add(gracz2);
            dataContext.Gracze.Add(gracz3);
            dataContext.Gracze.Add(gracz4);

            OpisStanu stan1 = new OpisStanu(1, gra1, 4, false, 2);
            OpisStanu stan2 = new OpisStanu(2, gra2, 2, false, 1);
            OpisStanu stan3 = new OpisStanu(3, gra3, 4, true, 5);
            OpisStanu stan4 = new OpisStanu(4, gra4, 3, false, 2);

            dataContext.OpisyStanu.Add(stan1);
            dataContext.OpisyStanu.Add(stan2);
            dataContext.OpisyStanu.Add(stan3);
            dataContext.OpisyStanu.Add(stan4);

            Zdarzenie zdarznie1 = new Zdarzenie(1, stan3, gracz3, new DateTime(2018, 12, 13));
            Zdarzenie zdarznie2 = new Zdarzenie(2, stan1, gracz2, new DateTime(2019, 11, 13));
            Zdarzenie zdarznie3 = new Zdarzenie(3, stan4, gracz1, new DateTime(2019, 12, 13));
            Zdarzenie zdarznie4 = new Zdarzenie(4, stan2, gracz4, new DateTime(2011, 1, 13));

            dataContext.Partie.Add(zdarznie1);
            dataContext.Partie.Add(zdarznie2);
            dataContext.Partie.Add(zdarznie3);
            dataContext.Partie.Add(zdarznie4);

        }
    }
}
