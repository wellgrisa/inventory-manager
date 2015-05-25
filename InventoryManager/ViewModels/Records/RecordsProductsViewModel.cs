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
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<UnitOfMeasure> UnitOfMeasures { get; set; }

        public RecordsProductsViewModel()
        {
            Categories = new ObservableCollection<Category>(_entityService.GetAll<Category>());
            UnitOfMeasures = new ObservableCollection<UnitOfMeasure>(_entityService.GetAll<UnitOfMeasure>());
        }

        //public override ObservableCollection<Product> PopulateEntities()
        //{
        //    return new ObservableCollection<Product>(_entityService.GetAll("Category", "UnitOfMeasure"));
        //}

        public override void AddCommandExecute(object obj)
        {
            Entities.Add(new ProductViewModel
            {
                Category = Categories.FirstOrDefault() ?? new Category(),
                UnitOfMeasure = UnitOfMeasures.FirstOrDefault() ?? new UnitOfMeasure()
            });
        }

        public override void OnSave()
        {
            //foreach (var entity in Entities)
            //{
            //    entity.CategoryID = entity.Category.ID;
            //    entity.UnitOfMeasureID = entity.UnitOfMeasure.ID;
            //    entity.Category = null;
            //    entity.UnitOfMeasure = null;
            //}

            base.OnSave();
        }
    }    
}
