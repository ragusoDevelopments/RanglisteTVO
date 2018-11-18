using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RanglisteTVO
{
    public class NavigationController
    {
        public Frame NavigationFrame
        {
            get;
            set;
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
        }

        public List<View> RegisteredViews = new List<View>();

        /// <summary>
        /// Initializes a new instance of NavigationController
        /// </summary>
        public NavigationController()
        {

        }

        /// <summary>
        /// Initializes a new instance of NavigationController
        /// </summary>
        /// <param name="navigationFrame">Frame in which the Navigation is to be shown</param>
        /// <param name="MainFrame">Frame in which the actual conten is to be shown</param>
        public NavigationController(Frame navigationFrame, Frame mainFrame)
        {
            NavigationFrame = navigationFrame;
            MainFrame = mainFrame;
        }

        /// <summary>
        /// Adds a new View to the navigation
        /// </summary>
        /// <param name="contentPage">XAML Page to be displayed</param>
        /// <param name="title">Title which is displayed in Navigation and as windowtitle</param>
        /// <param name="parameter"></param>
        public void RegisterView(Page contentPage, string key, string title)
        {
            if (RegisteredViews.Where(v => v.key == key).Count() > 0)
            {
                throw new Exception(String.Format("The Key must be unique. '{0}' is already used. Please use another Key", key));
            }

            RegisteredViews.Add(new View { key = key, view = contentPage, navTitle = title, mainWindowTitle = title });
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
            if (RegisteredViews.Where(v => v.key == key).Count() > 0)
            {
                throw new Exception(String.Format("The Key must be unique. '{0}' is already used. Please use another Key", key));
            }

            if (setMainWindowTitle)
            {
                RegisteredViews.Add(new View { key = key, view = contentPage, navTitle = title, mainWindowTitle = title });
            }
            else
            {
                RegisteredViews.Add(new View { key = key, view = contentPage, navTitle = title, mainWindowTitle = null });
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
            if (RegisteredViews.Where(v => v.key == key).Count() > 0)
            {
                throw new Exception(String.Format("The Key must be unique. '{0}' is already used. Please use another Key", key));
            }

            RegisteredViews.Add(new View { key = key, view = contentPage, navTitle = title, mainWindowTitle = mainWindowTitle });
        }
    }
}
