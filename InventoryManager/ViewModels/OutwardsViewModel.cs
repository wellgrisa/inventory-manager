using Domain;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Reports.Moviments;
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
        public ICommand ReportCommand { get; set; }        

        public OutwardsViewModel(ProductService<Product> productService) : base(productService)
        {
            ReportCommand = new RelayCommand(ReportCommandExecute);
        }

        private void ReportCommandExecute(object obj)
        {
            var report = new MovimentsReport(MovimentType.Outward);

            report.Show();
        }
    }
}
