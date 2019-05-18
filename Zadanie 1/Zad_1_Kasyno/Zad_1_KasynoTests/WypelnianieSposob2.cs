using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad_1_Kasyno;

namespace Zad_1_Kasyno_Test
{
    public class WypelnianieSposob2 : IWypelnianie
    {

        int IleRekordow;
        Random r;
        int rInt;
        Random r1 = new Random();
        public WypelnianieSposob2(int IleRekordow)
        {

            this.IleRekordow = IleRekordow;
            r = new Random();
            rInt = r.Next(0, IleRekordow);

        }
        public void Wypelnij(DataContext dataContext)
        {
            for (int i = 0; i < IleRekordow; i++)
            {


                Katalog gra1 = new Katalog(1, Faker.NameFaker.FirstName(), r1.Next(0, 5), r1.Next(0, 200));
                dataContext.Gry.Add(gra1.Id, gra1);
                Wykaz gracz1 = new Wykaz(i, Faker.NameFaker.FirstName(), Faker.NameFaker.LastName(), Faker.PhoneFaker.Phone(), Faker.LocationFaker.StreetName());
                dataContext.Gracze.Add(gracz1);



                OpisStanu stan1 = new OpisStanu(i, gra1, r1.Next(1, 5), false, r1.Next(0, 20));
                dataContext.OpisyStanu.Add(stan1);

                var randHelper3 = r.Next(0, IleRekordow);

                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;

               
                Zdarzenie zdarznie1 = new Zdarzenie(i, stan1, gracz1, start.AddDays(r.Next(range)));
                dataContext.Partie.Add(zdarznie1);
            }
        }


    }
}
