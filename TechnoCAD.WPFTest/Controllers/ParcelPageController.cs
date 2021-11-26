using System.Windows;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    class ParcelPageController : DependencyObject
    {
        private ParcelModel model;
        public ParcelPageController(ParcelModel model)
        {
            this.model = model;
        }
    }
}
