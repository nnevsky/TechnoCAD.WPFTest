using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Views.Pages;

namespace TechnoCAD.WPFTest.Models
{
    class BuildingModel : AbstractModel
    {
        public override string Title => "Building";

        public override Page View => view.Value;
        private Lazy<BuildingPage> view = new Lazy<BuildingPage>();

        public int? FloorCount { get; set; }
        public string Address { get; set; }
        public bool IsLiving { get; set; }

        public override bool IsWrong => !FloorCount.HasValue || string.IsNullOrEmpty(Address);
    }
}
