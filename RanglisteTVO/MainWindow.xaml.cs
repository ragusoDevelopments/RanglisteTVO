using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RanglisteTVO.ViewModels;

namespace RanglisteTVO
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();

            //mainFrame.Content = new UI.Pages.ContestOverview();
            App.navEngine.MainFrame = mainFrame;
            App.navEngine.NavigationGrid = navigationFrame;

            App.navEngine.RegisterView(new UI.Pages.ContestOverview(), "ContestOverview", null ,"Übersicht");

            App.navEngine.RegisterContainer("objects", "Objekte");
            App.navEngine.RegisterView(new UI.Pages.EditObjectsShell(), "Participant", "objects", "Teilnehmer");
            App.navEngine.RenderNavigation();
        }
    }
}
