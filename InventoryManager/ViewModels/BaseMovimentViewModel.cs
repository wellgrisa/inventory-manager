using Domain;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Reports.Moviments;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using System.Windows.Input;

namespace InventoryManager.ViewModels
{
    public abstract class BaseMovimentViewModel<T> where T : Moviment
    {
        #region Attributes
        private ProductService<Product> _productService;
        #endregion

        #region Properties

        public ObservableCollection<ProductViewModel> MovimentProducts { get; set; }

        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<PhysicalPerson> PhysicalPeople { get; set; }

        public ObservableCollection<LegalPerson> LegalPeople { get; set; }

        public Person SelectedPerson { get; set; }

        public ProductViewModel SelectedProduct { get; set; }

        public abstract MovimentType MovimentType { get;}

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand ReportCommand { get; set; }

        #endregion

        #region Constructor
        public BaseMovimentViewModel(ProductService<Product> productService)
        {
            _productService = productService;

            MovimentProducts = new ObservableCollection<ProductViewModel>(new List<ProductViewModel>());

            Products = new ObservableCollection<Product>(productService.GetAll());

            PhysicalPeople = new ObservableCollection<PhysicalPerson>(productService.GetAll<PhysicalPerson>());

            LegalPeople = new ObservableCollection<LegalPerson>(productService.GetAll<LegalPerson>());

            SetupCommandHandlers();
        }
        
        #endregion

        private void SetupCommandHandlers()
        {
            AddCommand = new RelayCommand(AddCommandExecute);

            RemoveCommand = new RelayCommand(RemoveCommandExecute, o => SelectedProduct != null);

            SaveCommand = new RelayCommand(SaveCommandExecute);

            ReportCommand = new RelayCommand(ReportCommandExecute);
        }

        private void AddCommandExecute(object obj)
        {
            MovimentProducts.Add(new ProductViewModel());
        }

        private void RemoveCommandExecute(object obj)
        {
            MovimentProducts.Remove(SelectedProduct);
        }

        private void SaveCommandExecute(object obj)
        {
            ShowMessageDialog(obj as MetroWindow);
        }

        private void ReportCommandExecute(object obj)
        {
            ToggleFlyout((obj as MetroWindow).Flyouts, 0);
        }

        private void ToggleFlyout(FlyoutsControl flyouts, int index)
        {
            var flyout = flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }

        private async void ShowMessageDialog(MetroWindow sender)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Sim",
                NegativeButtonText = "Não",
                ColorScheme = MetroDialogColorScheme.Accented
            };

            MessageDialogResult result = await sender.ShowMessageAsync("Confirmar", "Você deseja realmente salvar a movimentação realizada?",
               MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                var moviment = Activator.CreateInstance<T>();

                MovimentProducts.ToList().ForEach(x => moviment.Products.Add(new ProductMoviment
                {
                    ProductID = x.ID,
                    Quantity = x.Quantity
                }));

                _productService.SaveMoviment(moviment);

                Clean();
            }
        }

        private void Clean()
        {
            MovimentProducts.Clear();
        }
    }
}
