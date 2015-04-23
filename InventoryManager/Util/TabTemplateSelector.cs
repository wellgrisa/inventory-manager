using InventoryManager.ViewModels;
using InventoryManager.ViewModels.Sidebar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManager.Util
{
    public class TabTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var sidebarTabItem = item as SidebarTabItem;

            Window window = Application.Current.MainWindow;

            return window.FindResource(sidebarTabItem.TabItemTemplate.ToString()) as DataTemplate;
        }
    }
}
