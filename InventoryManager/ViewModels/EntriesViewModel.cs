using Domain;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PropertyChanged;
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
    public class EntriesViewModel
    {
        public ObservableCollection<ProductViewModel> EntryProducts { get; set; }

        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel SelectedProduct { get; set; }

        private ProductService<Product> _productService;

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public EntriesViewModel(ProductService<Product> productService)
        {
            _productService = productService;

            EntryProducts = new ObservableCollection<ProductViewModel>(new List<ProductViewModel>());

            Products = new ObservableCollection<Product>(productService.GetAll());

            AddCommand = new RelayCommand(AddCommandExecute);

            RemoveCommand = new RelayCommand(RemoveCommandExecute, o => SelectedProduct != null);

            SaveCommand = new RelayCommand(SaveCommandExecute);
        }

        private void AddCommandExecute(object obj)
        {
            EntryProducts.Add(new ProductViewModel());
        }

        private void RemoveCommandExecute(object obj)
        {
            EntryProducts.Remove(SelectedProduct);
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
                var entry = new Entry();

                EntryProducts.ToList().ForEach(x => entry.Products.Add(new ProductMoviment
                {
                    ProductID = x.ID,
                    Quantity = x.Quantity
                }));

                _productService.SaveEntry(entry);

                Clean();
            }
        }

        private void Clean()
        {
            EntryProducts.Clear();
        }
    }

    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Quantity { get; set; }
    }
}
