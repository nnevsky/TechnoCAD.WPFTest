using System.Windows;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    class BuildingPageController : DependencyObject
    {
        private BuildingModel model;
        private IAllertGenerator allertGenerator;

        public BuildingPageController(BuildingModel model, IAllertGenerator allertGenerator)
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
                allertGenerator.GenerateAllerts();
            }
        }
        public string Address
        {
            get => model.Address;
            set
            {
                model.Address = value;
                allertGenerator.GenerateAllerts();
            }
        }
        public bool? IsLiving
        {
            get => model.IsLiving;
            set
            {
                model.IsLiving = value;
                allertGenerator.GenerateAllerts();
            }
        }

    }
}
