using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICommand AddBuilding => new CommandHandler(() => AddModel(new Building { Id = Guid.NewGuid() }), () => true);
        public ICommand AddParcel => new CommandHandler(() => AddModel(new Parcel { Id = Guid.NewGuid() }), () => true);
    }
}
