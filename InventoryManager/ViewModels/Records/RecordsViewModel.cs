using Domain;
using InventoryManager.ViewModels.Sidebar;
using InventoryManager.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InventoryManager.ViewModels
{
    public class RecordsViewModel
    {
        public List<SidebarTabItem> Tabs { get; set; }        
        
        public RecordsViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            Tabs = new List<SidebarTabItem>
            {
                new SidebarTabItem()
                {
                    Header = "Produtos",
                    TabItemTemplate = RecordsTabItemTemplate.Products
                },
                new SidebarTabItem()
                {
                    Header = "Categorias",
                    TabItemTemplate = RecordsTabItemTemplate.Categories
                },
                new SidebarTabItem()
                {
                    Header = "Unidades de Medida",
                    TabItemTemplate = RecordsTabItemTemplate.UnitOfMeasures
                },
                new SidebarTabItem()
                {
                    Header = "Pessoa Física",
                    TabItemTemplate = RecordsTabItemTemplate.PhysicalPeople
                },
                new SidebarTabItem()
                {
                    Header = "Pessoa Jurídica",
                    TabItemTemplate = RecordsTabItemTemplate.LegalPeople
                },
            };
        }                          
    }
}
