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
        public override void AddCommandExecute(object obj)
        {
            Entities.Add(new Category
            {
                Name = "Nome"
            });
        }
    }
}
