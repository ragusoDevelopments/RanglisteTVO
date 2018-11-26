using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationEngine.Commands
{
    public abstract class DelegateCommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        protected abstract void Execute(object parameter);

        protected abstract bool CanExecute(object parameter);
    }
}
