using Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.ViewModels
{
    public class DashboardViewModel
    {
        public ObservableCollection<Product> ProductsOutOfStock { get; set; }
        public ObservableCollection<Product> ProductsAboveStock { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        public DashboardViewModel()
        {
            ProductsOutOfStock = new ObservableCollection<Product>(new List<Product> 
            { 
            });

            ProductsAboveStock = new ObservableCollection<Product>(new List<Product> 
            {                
            });

            Products = new ObservableCollection<Product>(new List<Product> 
            { 
              
            });
        }
    }
}
