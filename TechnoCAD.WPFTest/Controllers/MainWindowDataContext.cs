using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TechnoCAD.WPFTest.Commons;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Models;
using TechnoCAD.WPFTest.Models.Alerts;

namespace TechnoCAD.WPFTest.Controllers
{
    class MainWindowDataContext : DependencyObject, INotifyPropertyChanged, IAlertGenerator
    {
        public ObservableCollection<AbstractModel> ModelsItems { get; set; } = new ObservableCollection<AbstractModel>();
        public ObservableCollection<AlertModel> AllertItems { get; set; } = new ObservableCollection<AlertModel>();

        private void AddModel(AbstractModel abstractModel)
        {
            ModelsItems.Add(abstractModel);

            GenerateAlerts();
        }
        private void DeleteModel(AbstractModel model)
        {
            ModelsItems.Remove(model);

            GenerateAlerts();
        }

        public void GenerateAlerts()
        {
            var allerts = new List<AlertModel>();
            foreach (var item in ModelsItems)
            {
                foreach (var allert in (item as IAlertAdapter).Allerts)
                {
                    allerts.Add(allert);
                }
            }
            AllertItems = new ObservableCollection<AlertModel>(allerts);

            OnPropertyChanged(nameof(AllertItems));
        }

        public AlertModel SelectedAllert 
        { 
            set
            {
                SelectedModel = value != null ? ModelsItems.FirstOrDefault(x => x.Id == value.Id) : null;
                value?.OnSelected();
            }
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand => deleteCommand = 
            deleteCommand ?? new CommandHandler(() => DeleteModel(SelectedModel), () => SelectedModel != null);//

        private ICommand addBuildingCommand;
        public ICommand AddBuildingCommand => addBuildingCommand = 
            addBuildingCommand ?? new CommandHandler(() => AddModel(new BuildingViewAdapter(this) { Id = Guid.NewGuid() }), () => true);

        private ICommand addParcelCommand;
        public ICommand AddParcelCommand => addParcelCommand = 
            addParcelCommand ?? new CommandHandler(() => AddModel(new ParcelViewAdapter(this) { Id = Guid.NewGuid() }), () => true);

        private AbstractModel selectedModel;
        public AbstractModel SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));
                
                if(selectedModel != null)
                    EditPage = (selectedModel as IViewAdapter).View;
            }
        }

        private Page editPage;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propMane)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propMane));
        }

        public Page EditPage
        {
            get => editPage;
            set
            {
                editPage = value;
                OnPropertyChanged(nameof(EditPage));
            }
        }
    }
}
