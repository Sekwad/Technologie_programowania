using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_1_Kasyno
{
    public class DataContext
    {
        public Dictionary<int, Katalog> Gry { get; set; } = new Dictionary<int, Katalog>();

        public ObservableCollection<OpisStanu> OpisyStanu { get; set; } = new ObservableCollection<OpisStanu>();

        public List<Wykaz> Gracze { get; set; } = new List<Wykaz>();

        public ObservableCollection<Zdarzenie> Partie { get; set; } = new ObservableCollection<Zdarzenie>();

        public DataContext()
        {

        }
    }
}
