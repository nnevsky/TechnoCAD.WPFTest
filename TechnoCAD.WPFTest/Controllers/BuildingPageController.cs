using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    class BuildingPageController : DependencyObject
    {
        private BuildingModel model;
        public BuildingPageController(BuildingModel model)
        {
            this.model = model;
        }
    }
}
