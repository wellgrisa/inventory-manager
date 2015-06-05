using AutoMapper;
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
    public abstract class RecordTestBaseViewModel<T, TEntity> where TEntity : Entity where T : PropertyValidateModel
    {
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public ObservableCollection<T> Entities { get; set; }

        private T _selectedEntity;

        public T SelectedEntity { get { return _selectedEntity; } set { _selectedEntity = value; } }

        protected EntityService _entityService;

        public RecordTestBaseViewModel()
        {
            _entityService = new EntityService();

            Entities = PopulateEntities();

            RemoveCommand = new RelayCommand(RemoveCommandExecute, o => SelectedEntity != null);

            SaveCommand = new RelayCommand(SaveCommandExecute, o => CanSave());

            AddCommand = new RelayCommand(AddCommandExecute);

            RefreshCommand = new RelayCommand(RefreshExecute);
        }

        public virtual ObservableCollection<T> PopulateEntities()
        {
            var entities = _entityService.GetAll<TEntity>("Category", "UnitOfMeasure");

            var entitiesViewModel = Mapper.Map<IEnumerable<TEntity>, IEnumerable<T>>(entities);

            return new ObservableCollection<T>(entitiesViewModel);
        }

        private void RemoveCommandExecute(object obj)
        {
            Entities.Remove(SelectedEntity);
        }

        public void Refresh()
        {
            Entities.Clear();

            //_entityService.GetAll().ToList().ForEach(x => Entities.Add(x));
        }

        public abstract void AddCommandExecute(object obj);

        public virtual void OnSave()
        {
            var entities = Mapper.Map<IEnumerable<T>, IEnumerable<TEntity>>(Entities);
            
            _entityService.SaveEntities(entities.ToArray());
        }

        public bool CanSave()
        {            
            return Entities.All(x => x.Validate(x));
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

            MessageDialogResult result = await sender.ShowMessageAsync("Confirmar", "Você deseja realmente salvar?",
               MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                OnSave();
            }
        }
    }
}
