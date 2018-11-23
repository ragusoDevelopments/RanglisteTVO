using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using RanglisteTVO.Helper;
using RanglisteTVO.UI.Pages;

namespace RanglisteTVO.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public DelegateCommand ShowOverviewCommand { get; set; }

        public MainWindowViewModel()
        {
            ShowOverviewCommand = new DelegateCommand(LoadView);
        }

        private void LoadView()
        {
            App.navController.RequestNavigation("ContestOverview");
        }
    }
}
