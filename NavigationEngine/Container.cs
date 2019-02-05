using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NavigationEngine
{
    public class Container
    {

        public string key;
        public string parentContainerKey;
        public string title;

        public UIElement GetXAMLStructure(List<Container> RegisteredContainers, List<View> RegisteredViews)
        {
            //create and add current container
            StackPanel s = new StackPanel();
            s.Name = this.key;
            s.Margin = new System.Windows.Thickness(5, 0, 0, 0);

            TextBlock t = new TextBlock();
            t.Text = this.title;
            t.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            t.FontSize = 15;

            s.Children.Add(t);

            //create and add navcontrols for current container
            RegisteredViews.Where(vw=>vw.container == this.key).ToList().ForEach((v) =>
            {
                s.Children.Add(v.navButton);
            });

            //Repeat for each child container
            UIElement e = null;
            
            RegisteredContainers.Where(c => c.parentContainerKey == this.key).ToList().ForEach((container) =>
            {
                e = container.GetXAMLStructure(RegisteredContainers, RegisteredViews);

                if (e != null)
                {
                    s.Children.Add(e);
                }
            });

            return s;
        }

    }
}
