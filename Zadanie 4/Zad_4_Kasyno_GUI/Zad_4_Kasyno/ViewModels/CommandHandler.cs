using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zad_4_Kasyno.ViewModels
{
    public class CommandHandler : ICommand
    {
        private Action _Action { get; set; }
        private Func<bool> _CanExecute { get; set; }
        public event EventHandler CanExecuteChanged;

        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _Action = action;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public void Execute(object parameter)
        {
            _Action();
        }

    }
}
