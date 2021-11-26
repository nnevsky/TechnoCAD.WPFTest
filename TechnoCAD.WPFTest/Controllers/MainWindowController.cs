using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TechnoCAD.WPFTest.Commons;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    public class MainWindowController : DependencyObject
    {
        public ObservableCollection<AbstractModel> ModelsItems { get; set; } = new ObservableCollection<AbstractModel>();

        private void AddModel(AbstractModel abstractModel)
        {
            ModelsItems.Add(abstractModel);
        }

        private ICommand addBuildingCommand;
        public ICommand AddBuildingCommand => addBuildingCommand = 
            addBuildingCommand ?? new CommandHandler(() => AddModel(new Building { Id = Guid.NewGuid() }), () => true);

        private ICommand addParcelCommand;
        public ICommand AddParcelCommand => addParcelCommand = 
            addParcelCommand ?? new CommandHandler(() => AddModel(new Parcel { Id = Guid.NewGuid() }), () => true);
    }
}
