using System.Windows;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    class BuildingViewDataContext : DependencyObject
    {
        private BuildingModel model;
        private IAlertGenerator allertGenerator;

        public BuildingViewDataContext(BuildingModel model, IAlertGenerator allertGenerator)
        {
            this.model = model;
            this.allertGenerator = allertGenerator;
        }

        public int? FloorCount
        {
            get => model.FloorCount;
            set
            {
                model.FloorCount = value;
                allertGenerator.GenerateAlerts();
            }
        }
        public string Address
        {
            get => model.Address;
            set
            {
                model.Address = value;
                allertGenerator.GenerateAlerts();
            }
        }
        public bool? IsLiving
        {
            get => model.IsLiving;
            set
            {
                model.IsLiving = value;
                allertGenerator.GenerateAlerts();
            }
        }

    }
}
