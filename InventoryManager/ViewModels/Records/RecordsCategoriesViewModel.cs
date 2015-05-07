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
using System.Windows.Input;

namespace InventoryManager.ViewModels.Records
{
    public class RecordsCategoriesViewModel : RecordBaseViewModel<Category>
    {
        public  ObservableCollection<categoryViewModel> EntitiesA { get; set; }

        public RecordsCategoriesViewModel()
        {
            EntitiesA = new ObservableCollection<categoryViewModel>();
        }

        public override void AddCommandExecute(object obj)
        {
            Entities.Add(new Category
            {
                Name = "Nome"
            });
        }

        public override void OnSave()
        {
            base.OnSave();
        }
    }

    [PropertyChanged.ImplementPropertyChanged]
    public class categoryViewModel
    {
        public string Name { get; set; }
    }
}
