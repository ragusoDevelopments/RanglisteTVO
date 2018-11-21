using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace RanglisteTVO.Helper
{
    public class DelegateCommand : DelegateCommandBase
    {
        public DelegateCommand(Action<object> execute)
                       : this(execute, (r) => true)
        {
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute): base(execute, canExecute)
        {
            if(execute == null || canExecute == null)
            {
                throw new ArgumentException("Function cannot be null");
            }
        }
    }
}