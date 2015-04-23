using Domain;
using InventoryManager.Views;
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
    public class RecordsViewModel
    {
        private ProductService _entityService;

        public ProductService EntityService
        {
            get
            {
                if (_entityService == null)
                {
                    _entityService = new ProductService();
                }
                return _entityService;
            }
        }

        public ObservableCollection<Product> Products { get; set; }

        public Product SelectedProduct { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddSupplierCommand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand TestCommand { get; set; }

        public Entries Test { get; set; } 

        public Visibility SupplierVisibility { get; set; }

        public RecordsViewModel()
        {
            Products = new ObservableCollection<Product>(EntityService.GetProducts());

            AddCommand = new RelayCommand(AddCommandExecute);

            RemoveCommand = new RelayCommand(RemoveCommandExecute, o => SelectedProduct != null);

            SaveCommand = new RelayCommand(SaveCommandExecute);

            AddSupplierCommand = new RelayCommand(AddSupplierCommandExecute);

            AddProductCommand = new RelayCommand(AddProductCommandExecute);

            RefreshCommand = new RelayCommand(RefreshExecute);

            TestCommand = new RelayCommand(TestExecute);
        }

        private void TestExecute(object obj)
        {
            Test = new Entries();
        }

        private void RefreshExecute(object obj)
        {
            Refresh();
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

        private void AddEntity(MetroWindow window, TempFlyoutResolver flyoutEnum)
        {
            var flyout = window.Flyouts.Items[(int)flyoutEnum] as Flyout;
            
            flyout.IsOpen = !flyout.IsOpen;

            flyout.ClosingFinished -= flyout_ClosingFinished;

            flyout.ClosingFinished += flyout_ClosingFinished;            
        }

        private void flyout_ClosingFinished(object sender, RoutedEventArgs e)
        {
            var flyoutViewModel = (sender as Flyout).DataContext as CreateEditProductViewModel;

            if (flyoutViewModel != null && flyoutViewModel.IsSaved)
            {
                Refresh();

                flyoutViewModel.IsSaved = false;
            }
        }

        public void Refresh()
        {
            Products.Clear();

            EntityService.GetProducts().ToList().ForEach(x => Products.Add(x));            
        }
        
        private void AddSupplierCommandExecute(object obj)
        {
            AddEntity(obj as MetroWindow, TempFlyoutResolver.Supplier);
        }

        private void AddProductCommandExecute(object obj)
        {
            AddEntity(obj as MetroWindow, TempFlyoutResolver.Product);
        }    
    }

    public enum TempFlyoutResolver
    {
        Supplier = 0,
        Product = 1
    }
}
