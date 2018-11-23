using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using RanglisteTVO.Helper;

namespace RanglisteTVO
{
    public class NavigationEngine
    {
        private Grid _NavigationGrid = new Grid();
        public Grid NavigationFrame
        {
            get { return _NavigationGrid; }
            set
            {
                if(value != _NavigationGrid)
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
            public Button navButton;
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
        public NavigationEngine()
        {

        }

        /// <summary>
        /// Initializes a new instance of NavigationController
        /// </summary>
        /// <param name="navigationFrame">Frame in which the Navigation is to be shown</param>
        /// <param name="MainFrame">Frame in which the actual conten is to be shown</param>
        public NavigationEngine(Grid navigationFrame, Frame mainFrame)
        {
            NavigationFrame = navigationFrame;
            MainFrame = mainFrame;

            NavigationCommand = new DelegateCommand<object>(Navigate);
        }

        private void Navigate(object key)
        {
            RequestNavigation((string)key);
        }

        /// <summary>
        /// Adds a new View to the navigation
        /// </summary>
        /// <param name="contentPage">XAML Page to be displayed</param>
        /// <param name="title">Title which is displayed in Navigation and as windowtitle</param>
        /// <param name="parameter"></param>
        public void RegisterView(Page contentPage, string key, string title)
        {
            AddView(contentPage, key, title, title);
        }

        /// <summary>
        /// Adds a new View to the navigation
        /// </summary>
        /// <param name="contentPage">XAML Page to be displayed</param>
        /// <param name="title">Title which is displayed in Navigation and as windowtitle</param>
        /// <param name="parameter"></param>
        ///<param name="setMainWindowTitle">When true, the mainwindow's title gets set to the view's title</param>
        public void RegisterView(Page contentPage, string key, string title, bool setMainWindowTitle)
        {
            if (setMainWindowTitle)
            {
                AddView(contentPage, key, title, title);
            }
            else
            {
                AddView(contentPage, key, title, string.Empty);
            }

        }

        /// <summary>
        /// Adds a new View to the navigation
        /// </summary>
        /// <param name="contentPage">XAML Page to be displayed</param>
        /// <param name="title">Title which is displayed in Navigation and as windowtitle</param>
        ///<param name="mainWindowTitle">Vlaue gets set as the mainwindow's title</param>
        /// <param name="parameter"></param>
        public void RegisterView(Page contentPage, string key, string title, string mainWindowTitle)
        {
            AddView(contentPage, key, title, mainWindowTitle);
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

        private void AddView(Page content, string key, string title, string mainWindowTitle)
        {
            if (RegisteredViews.Where(v => v.key == key).Count() > 0)
            {
                throw new Exception(String.Format("The Key must be unique. '{0}' is already used. Please use another Key", key));
            }

            View view = new View { key = key, view = content, navTitle = title, mainWindowTitle = mainWindowTitle };

            view.navButton = AddNavButton(view);
            RegisteredViews.Add(view);

            RenderButtons();
        }

        private Button AddNavButton(View view)
        {
            Button b = new Button();
            b.Name = view.key;
            b.Content = view.navTitle;

            Binding binding = new Binding();
            binding.Path = new PropertyPath("NavigationCommand");
            b.SetBinding(Button.CommandProperty, binding);
            b.CommandParameter = view.key;

            return b;
        }

        private void RenderButtons()
        {
            NavigationFrame.Children.Clear();

            foreach (View v in RegisteredViews)
            {
                if (v.navButton != null)
                {
                    NavigationFrame.Children.Add(v.navButton);
                }
            }
        }
    }
}
