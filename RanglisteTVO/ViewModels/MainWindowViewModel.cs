using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using RanglisteTVO.Helper;
using RanglisteTVO.UI.Pages;

namespace RanglisteTVO.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            DelegateCommand ShowOverviewCommand;

            public MainWindowViewModel ()
            {
                ShowOverviewCommand = new DelegateCommand(LoadView(new ContestOverview()));
            }

            private void LoadView()
            {

            }
        }
    }
}
