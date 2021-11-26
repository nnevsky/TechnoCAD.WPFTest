using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TechnoCAD.WPFTest.Commons;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    public class MainWindowController : DependencyObject, INotifyPropertyChanged
    {
        public ObservableCollection<AbstractModel> ModelsItems { get; set; } = new ObservableCollection<AbstractModel>();

        private void AddModel(AbstractModel abstractModel)
        {
            ModelsItems.Add(abstractModel);
        }

        private ICommand addBuildingCommand;
        public ICommand AddBuildingCommand => addBuildingCommand = 
            addBuildingCommand ?? new CommandHandler(() => AddModel(new BuildingModel { Id = Guid.NewGuid() }), () => true);

        private ICommand addParcelCommand;
        public ICommand AddParcelCommand => addParcelCommand = 
            addParcelCommand ?? new CommandHandler(() => AddModel(new ParcelModel { Id = Guid.NewGuid() }), () => true);

        //private ICommand editPage;
        //public ICommand EditPageCommand => editPage =
        //    editPage ?? new CommandHandler(() => EditPage = SelectedModel.View, () => SelectedModel != null);

        private AbstractModel selectedModel;
        public AbstractModel SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;
                EditPage = selectedModel.View;
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
