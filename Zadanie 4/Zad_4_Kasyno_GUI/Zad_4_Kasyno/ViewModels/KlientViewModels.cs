using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad_4_Kasyno.Models;
using Zad4_4_Kasyno_GUI;
using Data;

namespace Zad_4_Kasyno.ViewModels
{
    public class KlientViewModels : ObservedObject
    {
        
        private ListaKlientow _klienciModel;
        private ListaKlientow _KlienciModel
        {
            get
            {
                return _klienciModel;
            }
            set
            {
                _klienciModel = value;
                Klienci = new ObservableCollection<Klienci>(value.KlienciFromModel);
            }
        }

        private ObservableCollection<Klienci> _klienci;
        public ObservableCollection<Klienci> Klienci
        {
            get
            {
                return _klienci;
            }
            set
            {
                _klienci = value;
                OnPropertyChanged("Klienci");
            }
        }

        private Klienci _wybranyKlient;
        public Klienci WybranyKlient
        {
            get
            {
                return _wybranyKlient;
            }
            set
            {
                _wybranyKlient = value;
                OnPropertyChanged("SelectedCustomer");
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private int id = 0;

            public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged("ID"); }
        }

        private string nazwisko = string.Empty;
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; OnPropertyChanged("Nazwisko"); }
        }

        private string imie = string.Empty;
        public string Imie
        {
            get { return imie; }
            set { imie = value; OnPropertyChanged("Imie"); }
        }

        private string adres = string.Empty;
        public string Adres
        {
            get { return adres; }
            set { adres = value; OnPropertyChanged("Adres"); }
        }

        private string telefon = string.Empty;
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; OnPropertyChanged("Telefon"); }
        }


        public CommandHandler AddCommand { get; private set; }
        public CommandHandler UpdateCommand { get; private set; }
        public CommandHandler EditCommand { get; private set; }
        public CommandHandler DeleteCommand { get; private set; }
        public CommandHandler ClearCommand { get; private set; }


        public KlientViewModels()
        {
            _KlienciModel = new ListaKlientow();

            AddCommand = new CommandHandler(AddKlient, () => true);
            UpdateCommand = new CommandHandler(UpdateCustomer, () => true);
            EditCommand = new CommandHandler(EditCustomer, () => true);
            DeleteCommand = new CommandHandler(DeleteCustomer, () => WybranyKlient != null);
            ClearCommand = new CommandHandler(ClearTextBoxes, () => true);
        }

        public KlientViewModels(string connection)
        {
            _KlienciModel = new ListaKlientow(connection);

            AddCommand = new CommandHandler(AddKlient, () => true);
            UpdateCommand = new CommandHandler(UpdateCustomer, () => true);
            EditCommand = new CommandHandler(EditCustomer, () => true);
            DeleteCommand = new CommandHandler(DeleteCustomer, () => WybranyKlient != null);
            ClearCommand = new CommandHandler(ClearTextBoxes, () => true);
        }

        #region Commands

        private void AddKlient()
        {
            
            
            Klienci klient = new Klienci()
            {
                idK = this.ID,
                imieK = this.Imie,
                nazwiskoK = this.Nazwisko,
                telefon = this.Telefon,
                adres = this.Adres
            };

            Task taskAdd = Task.Run(() => { _KlienciModel.AddKlient(out id,  klient); });
            taskAdd.Wait();

            klient.idK = ID;
            

            Klienci.Add(klient);
        }

        private void EditCustomer()
        {
            ID = WybranyKlient.idK;
            Imie = WybranyKlient.imieK;
            Nazwisko = WybranyKlient.nazwiskoK;
            Adres = WybranyKlient.adres;
            Telefon = WybranyKlient.telefon;
            
        }

        private void UpdateCustomer()
        {
            Klienci klient = new Klienci()
            {
                idK = this.ID,
                imieK = this.Imie,
                nazwiskoK = this.Nazwisko,
                telefon = this.Telefon,
                adres = this.Adres
            };

            Task.Run(() => { _KlienciModel.UpdateKlient(klient); });
            Klienci nowyKlient = Klienci.SingleOrDefault(c => c.idK == klient.idK);
            nowyKlient.imieK = klient.imieK;
            nowyKlient.nazwiskoK = klient.nazwiskoK;
            nowyKlient.telefon = klient.telefon;
            nowyKlient.adres = klient.adres;

        }

        private void DeleteCustomer()
        {
            Task.Run(() => { _KlienciModel.DeleteKlient(WybranyKlient); });
            Klienci.Remove(WybranyKlient);
            ID = Klienci.Count + 1;
        }

        private void ClearTextBoxes()
        {
            ID = Klienci.Count+1;
            Imie = string.Empty;
            Nazwisko = string.Empty;
            Telefon = string.Empty;
            Adres = string.Empty;
            
        }
        #endregion
    }
}
