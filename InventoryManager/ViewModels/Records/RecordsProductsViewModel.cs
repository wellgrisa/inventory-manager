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
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryManager.ViewModels.Records
{
    public class RecordsProductsViewModel : RecordTestBaseViewModel<ProductViewModel, Product>
    {
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
        public ObservableCollection<UnitOfMeasureViewModel> UnitOfMeasures { get; set; }

        public RecordsProductsViewModel()
        {
            Categories = new ObservableCollection<CategoryViewModel>(_entityService.GetAll<Category>().MapTo<CategoryViewModel>());
            UnitOfMeasures = new ObservableCollection<UnitOfMeasureViewModel>(_entityService.GetAll<UnitOfMeasure>().MapTo<UnitOfMeasureViewModel>());
        }

        public override void AddCommandExecute(object obj)
        {
            Entities.Add(new ProductViewModel
            {
                Category = Categories.FirstOrDefault() ?? new CategoryViewModel(),
                UnitOfMeasure = UnitOfMeasures.FirstOrDefault() ?? new UnitOfMeasureViewModel()
            });
        }
    }    
}
