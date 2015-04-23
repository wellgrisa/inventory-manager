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
    public abstract class RecordBaseViewModel<T> where T : Entity
    {
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RefreshCommand { get; set; }    

        public ObservableCollection<T> Entities { get; set; }

        public T SelectedEntity{ get; set; }

        protected ProductService<T> _productService;

        public RecordBaseViewModel()
        {
            _productService = new ProductService<T>();

            Entities = new ObservableCollection<T>(_productService.GetAll());

            RemoveCommand = new RelayCommand(RemoveCommandExecute, o => SelectedEntity!= null);

            SaveCommand = new RelayCommand(SaveCommandExecute);

            AddCommand = new RelayCommand(AddCommandExecute);

            RefreshCommand = new RelayCommand(RefreshExecute);
        }

        private void RemoveCommandExecute(object obj)
        {
            Entities.Remove(SelectedEntity);
        }

        public void Refresh()
        {
            Entities.Clear();

            _productService.GetAll().ToList().ForEach(x => Entities.Add(x));
        }

        public abstract void AddCommandExecute(object obj);

        public virtual void OnSave()
        {
            _productService.Save(Entities.ToArray());
        }

        private void RefreshExecute(object obj)
        {
            Refresh();
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
                OnSave();
            }
        }     
    }
}
