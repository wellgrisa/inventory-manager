using Domain;
using InventoryManager.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryManager.ViewModels
{
    public abstract class CreateEditEntityViewModel<T>
        where T : Entity
    {
        protected EntityService _entityService;
        
        public bool IsSaved { get; set; }

        public T CurrentEntity { get; set; }

        public ICommand SaveCommand { get; set; }

        protected TempFlyoutResolver Flyout { get; set; }

        public virtual string ConfirmationMessage
        {
            get
            { 
                return "Deseja realmente salvar?"; 
            }
        }
        
        public CreateEditEntityViewModel()
        {
            SaveCommand = new RelayCommand(SaveCommandExecute);
        }

        private void SaveCommandExecute(object obj)
        {
            ShowMessageDialog(obj as MetroWindow);
        }

        private async void ShowMessageDialog(MetroWindow sender)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Sim",
                NegativeButtonText = "Não",
                ColorScheme = MetroDialogColorScheme.Accented
            };

            MessageDialogResult result = await sender.ShowMessageAsync("Confirmar", ConfirmationMessage,
               MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                var affectedRecords = _entityService.Save(CurrentEntity);

                IsSaved = affectedRecords > 0;                

                var flyout = sender.Flyouts.Items[(int)Flyout] as Flyout;

                flyout.IsOpen = false;
            }
        }
    }
}
