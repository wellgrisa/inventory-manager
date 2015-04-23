using InventoryManager.ViewModels.Sidebar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Initialize();
        }

        public List<SidebarTabItem> Tabs { get; set; }

        private void Initialize()
        {
            Tabs = new List<SidebarTabItem>
            {
                new SidebarTabItem()
                {
                    Header = "Inicial",
                    TabItemTemplate = SidebarTabItemTemplate.Dashboard
                },
                new SidebarTabItem()
                {
                    Header = "Entradas",
                    TabItemTemplate = SidebarTabItemTemplate.Entries
                },
                new SidebarTabItem()
                {
                    Header = "Saídas",
                    TabItemTemplate = SidebarTabItemTemplate.Outwards
                },
                new SidebarTabItem()
                {
                    Header = "Cadastro",
                    TabItemTemplate = SidebarTabItemTemplate.Records
                },
                new SidebarTabItem()
                {
                    Header = "Relatórios",
                    TabItemTemplate = SidebarTabItemTemplate.Reports
                },
            };
        }
    }
}
