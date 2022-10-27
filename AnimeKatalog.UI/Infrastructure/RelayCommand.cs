using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnimeKatalog.UI.Infrastructure
{
    public class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Predicate<object> _predicate;


        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            _action = action;
            _predicate = predicate;
        }


        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _predicate == null ? true : _predicate.Invoke(parameter);

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}
