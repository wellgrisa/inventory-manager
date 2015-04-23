using InventoryManager.ViewModels;
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

        public EntriesViewModel EntriesViewModel
        {
            get
            {
                return new EntriesViewModel(new ProductService());
            }
        }

        public RecordsViewModel RecordsViewModel
        {
            get
            {
                return new RecordsViewModel();
            }
        }

        public CreateEditProductViewModel CreateEditProductViewModel
        {
            get
            {
                return new CreateEditProductViewModel(new ProductService());
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
