using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using NavigationEngine.Commands;

namespace NavigationEngine
{
    public class NavigationController
    {
        private Grid _NavigationGrid = new Grid();
        public Grid NavigationGrid
        {
            get { return _NavigationGrid; }
            set
            {
                if (value != _NavigationGrid)
                {
                    _NavigationGrid = value;
                    _NavigationGrid.DataContext = this;
                }
            }
        }

        public Frame MainFrame
        {
            get;
            set;
        }

        public struct View
        {
            public string key;
            public Page view;
            public string navTitle;
            public string mainWindowTitle;
            public string container;
            public Button navButton;
        }

        private List<Container> _RegisteredContainers = new List<Container> { new Container { key = RootContainerName, parentContainerKey = null } };
        public List<Container> RegisteredContainers
        {
            get { return _RegisteredContainers; }
            set
            {
                if (_RegisteredContainers != value)
                {
                    _RegisteredContainers = value;
                }
            }
        }

        private List<View> _RegisteredViews = new List<View>();
        public List<View> RegisteredViews
        {
            get
            {
                return _RegisteredViews;
            }

            set
            {
                if (_RegisteredViews != value)
                {
                    _RegisteredViews = value;
                }
            }
        }

        public DelegateCommand<object> NavigationCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of NavigationController
        /// </summary>
        public NavigationController()
        {
            NavigationCommand = new DelegateCommand<object>((key) => RequestNavigation((string)key));
        }

        /// <summary>
        /// Initializes a new instance of NavigationController
        /// </summary>
        /// <param name="navigationFrame">Frame in which the Navigation is to be shown</param>
        /// <param name="MainFrame">Frame in which the actual conten is to be shown</param>
        public NavigationController(Grid navigationFrame, Frame mainFrame) : this()
        {
            NavigationGrid = navigationFrame;
            MainFrame = mainFrame;

        }

        /// <summary>
        /// Registeres a new Container in the given parent Contaienr
        /// </summary>
        /// <param name="key">Unique identifyer for the container</param>
        /// <param name="parentKey">The parent Container's key</param>
        public void RegisterContainer(string key, string title, string parentKey)
        {
            AddContainer(key, parentKey, title);
        }

        /// <summary>
        /// Registeres a new Container in RootContainer
        /// </summary>
        /// <param name="key">Unique identifyer for the container</param>
        public void RegisterContainer(string key, string title)
        {
            RegisterContainer(key, title, RootContainerName);
        }

        /// <summary>
        /// Adds a new View to the navigation
        /// </summary>
        /// <param name="contentPage">XAML Page to be displayed</param>
        /// <param name="title">Title which is displayed in Navigation and as windowtitle</param>
        /// <param name="key">Unique yey for this view</param>
        /// <param name="containerKey">Key of the container you want the navigation button to appear in. Set it to null if you do not want to use containers.</param>
        public void RegisterView(Page contentPage, string key, string containerKey, string title)
        {
            AddView(contentPage, key, containerKey, title, title);
        }

        /// <summary>
        /// Adds a new View to the navigation
        /// </summary>
        /// <param name="contentPage">XAML Page to be displayed</param>
        /// <param name="title">Title which is displayed in Navigation and as windowtitle</param>
        /// <param name="key">Unique key for this view</param>
        ///<param name="setMainWindowTitle">When true, the mainwindow's title gets set to the view's title</param>
        /// <param name="containerKey">Key of the container you want the navigation button to appear in. Set it to null if you do not want to use containers.</param>
        public void RegisterView(Page contentPage, string key, string containerKey, string title, bool setMainWindowTitle)
        {
            if (setMainWindowTitle)
            {
                AddView(contentPage, key, containerKey, title, title);
            }
            else
            {
                AddView(contentPage, key, containerKey, title, string.Empty);
            }

        }

        /// <summary>
        /// Adds a new View to the navigation
        /// </summary>
        /// <param name="contentPage">XAML Page to be displayed</param>
        /// <param name="title">Title which is displayed in Navigation and as windowtitle</param>
        ///<param name="mainWindowTitle">Value gets set as the mainwindow's title</param>
        /// <param name="key">unique key for this View</param>
        /// <param name="containerKey">Key of the container you want the navigation button to appear in. Set it to null if you do not want to use containers.</param>
        public void RegisterView(Page contentPage, string key, string containerKey, string title, string mainWindowTitle)
        {
            AddView(contentPage, key, containerKey, title, mainWindowTitle);
        }

        /// <summary>
        /// Tries to Navigate to the requested view, remember that yourt view hast to be registered
        /// </summary>
        /// <param name="key">The view's Key</param>
        public void RequestNavigation(string key)
        {
            if (RegisteredViews.Where(v => v.key == key).Count() != 1)
            {
                throw new Exception(string.Format("No View with Key '{0}' found. Your view has to be registered. Use NavigationEngine.RegisterView(...) to do so.", key));
            }

            MainFrame.Content = RegisteredViews.Where(v => v.key == key).FirstOrDefault().view;
        }

        private void AddContainer(string key, string parentKey, string title)
        {
            if (RegisteredContainers.Where(c => c.key == key).Count() > 0)
            {
                throw new Exception(String.Format("The Key must be unique. '{0}' is already used.", key));
            }
            else if (RegisteredContainers.Where(c => c.key == parentKey).Count() > 1)
            {
                throw new Exception(String.Format("There is no container with the key '{0}' found. Please register that first.", key));
            }
            else if (title == null)
            {
                title = "";
            }

            RegisteredContainers.Add(new Container { key = key, parentContainerKey = parentKey, title = title });
        }

        private void AddView(Page content, string key, string containerKey, string title, string mainWindowTitle)
        {
            if (RegisteredViews.Where(v => v.key == key).Count() > 0)
            {
                throw new Exception(String.Format("The Key must be unique. '{0}' is already used. Please use another Key", key));
            }

            if (string.IsNullOrWhiteSpace(containerKey))
            {
                containerKey = RootContainerName;
            }

            View view = new View { key = key, view = content, navTitle = title, mainWindowTitle = mainWindowTitle };

            view.navButton = AddNavButton(view);
            RegisteredViews.Add(view);

            RenderNavigation();
        }

        private static string RootContainerName = "RootContainer";

        private Button AddNavButton(View view)
        {
            Button b = new Button();
            b.Name = view.key;
            b.Content = view.navTitle;

            b.SetBinding(Button.CommandProperty, nameof(NavigationCommand));
            b.CommandParameter = view.key;

            return b;
        }

        public void RenderNavigation()
        {
            NavigationGrid.Children.Clear();

            StackPanel s = new StackPanel();
            s.HorizontalAlignment = HorizontalAlignment.Left;
            s.Name = RootContainerName;

            s.Children.Add(RegisteredContainers.Where(c => c.key == RootContainerName).FirstOrDefault().GetXAMLStructure(RegisteredContainers));

            NavigationGrid.Children.Add(s);

            //foreach (View v in RegisteredViews)
            //{
            //    if (v.navButton != null)
            //    {
            //        NavigationGrid.Children.Add(v.navButton);
            //    }
            //}
        }
    }
}