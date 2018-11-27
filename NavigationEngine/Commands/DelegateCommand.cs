using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace NavigationEngine.Commands
{
    public class DelegateCommand : DelegateCommandBase
    {
        Action execute;
        Func<bool> canExecute;

        public DelegateCommand(Action execute)
                       : this(execute, () => true)
        {
        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if(execute == null || canExecute == null)
            {
                throw new ArgumentException("Function cannot be null");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        protected override bool CanExecute(object parameter)
        {
            return canExecute();
        }

        protected override void Execute(object parameter)
        {
            execute();
        }
    }
}