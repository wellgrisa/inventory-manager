using Domain;
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
    public class OutwardsViewModel : BaseMovimentViewModel<Outward>
    {
        public OutwardsViewModel(ProductService<Product> productService) : base(productService)
        {

        }
    }
}
