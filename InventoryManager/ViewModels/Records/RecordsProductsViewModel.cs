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
    public class RecordsProductsViewModel : RecordBaseViewModel<Product>
    {
        

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<UnitOfMeasure> UnitOfMeasures { get; set; }

        public RecordsProductsViewModel()
        {
            Categories = new ObservableCollection<Category>(_productService.GetAll<Category>());
            UnitOfMeasures = new ObservableCollection<UnitOfMeasure>(_productService.GetAll<UnitOfMeasure>());
        }

        public override ObservableCollection<Product> PopulateEntities()
        {
            return new ObservableCollection<Product>(_productService.GetAll("Category", "UnitOfMeasure"));
        }

        public override void AddCommandExecute(object obj)
        {
            Entities.Add(new Product
            {
                Name = "Nome"
            });
        }        
    }    
}
