using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TechnoCAD.WPFTest.Commons;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    class MainWindowController : DependencyObject, INotifyPropertyChanged
    {
        public ObservableCollection<AbstractModel> ModelsItems { get; set; } = new ObservableCollection<AbstractModel>();
        public ObservableCollection<WrongModel> WrongItems { get; set; } = new ObservableCollection<WrongModel>();

        private void AddModel(AbstractModel abstractModel)
        {
            ModelsItems.Add(abstractModel);
        }

        private ICommand addBuildingCommand;
        public ICommand AddBuildingCommand => addBuildingCommand = 
            addBuildingCommand ?? new CommandHandler(() => AddModel(new BuildingViewAdapter { Id = Guid.NewGuid() }), () => true);

        private ICommand addParcelCommand;
        public ICommand AddParcelCommand => addParcelCommand = 
            addParcelCommand ?? new CommandHandler(() => AddModel(new ParcelViewAdapter { Id = Guid.NewGuid() }), () => true);

        private AbstractModel selectedModel;
        public AbstractModel SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;
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
