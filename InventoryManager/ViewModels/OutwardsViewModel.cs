using Domain;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    public class Outwards
    {
        public ObservableCollection<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public Outwards()
        {
            Products = new ObservableCollection<Product>(new List<Product>());

            AddCommand = new RelayCommand(AddCommandExecute);

            RemoveCommand = new RelayCommand(RemoveCommandExecute, o => SelectedProduct != null);

            SaveCommand = new RelayCommand(SaveCommandExecute);
        }

        private void AddCommandExecute(object obj)
        {
            Products.Add(new Product 
            {
                Name = "Nome",
                Description = "Descrição"
            });
        }

        private void RemoveCommandExecute(object obj)
        {
            Products.Remove(SelectedProduct);            
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

            MessageDialogResult result = await sender.ShowMessageAsync("Confirmar", "Você deseja realmente salvar a Entrada realizada?",
               MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                //TODO: Save Entry in database
            }                
        }
    }
}
