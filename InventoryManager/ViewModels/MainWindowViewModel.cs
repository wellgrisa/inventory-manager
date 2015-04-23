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
                    TabItemTemplate = DashboardTabItemTemplate.Dashboard
                },
                new SidebarTabItem()
                {
                    Header = "Entradas",
                    TabItemTemplate = DashboardTabItemTemplate.Entries
                },
                new SidebarTabItem()
                {
                    Header = "Saídas",
                    TabItemTemplate = DashboardTabItemTemplate.Outwards
                },
                new SidebarTabItem()
                {
                    Header = "Cadastro",
                    TabItemTemplate = DashboardTabItemTemplate.Records
                },
                new SidebarTabItem()
                {
                    Header = "Relatórios",
                    TabItemTemplate = DashboardTabItemTemplate.Reports
                },
            };
        }
    }
}
