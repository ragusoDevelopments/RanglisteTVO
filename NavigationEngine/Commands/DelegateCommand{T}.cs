using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationEngine.Commands
{
    public class DelegateCommand<T>: DelegateCommandBase
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public DelegateCommand(Action<object> execute)
                       : this(execute, (r) => true)
        {
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null || canExecute == null)
            {
                throw new ArgumentException("Function cannot be null");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        protected override bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        protected override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
