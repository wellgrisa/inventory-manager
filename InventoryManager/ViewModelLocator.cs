using Domain;
using InventoryManager.ViewModels;
using InventoryManager.ViewModels.Records;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class ViewModelLocator
    {
        public DashboardViewModel DashboardViewModel
        {
            get
            {
                return new DashboardViewModel();
            }
        }

        public RecordsProductsViewModel RecordsProductsViewModel 
        {
            get 
            {
                return new RecordsProductsViewModel(); 
            } 
        }

        public RecordsCategoriesViewModel RecordsCategoriesViewModel
        {
            get
            {
                return new RecordsCategoriesViewModel();
            }
        }

        public RecordsUnitOfMeasuresViewModel RecordsUnitOfMeasuresViewModel 
        {
            get
            {
                return new RecordsUnitOfMeasuresViewModel();
            }
        }        

        public EntriesViewModel EntriesViewModel
        {
            get
            {
                return new EntriesViewModel(new ProductService<Product>());
            }
        }

        public RecordsViewModel RecordsViewModel
        {
            get
            {
                return new RecordsViewModel();
            }
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return new MainWindowViewModel();
            }
        }
    }
}
