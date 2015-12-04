using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xam.Ref.ViewModel.Helpers
{
    internal class Command : ICommand
    {
        private readonly Action<object> _action;
        

        public Command(Action<object> action)
        {
            if (action == null)
            { 
                throw new ArgumentNullException("action");
            }

            this._action = action;
        }

        public Command(Action action) : this(delegate(object o) { action(); })
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this._action(parameter);
        }
    }
}
