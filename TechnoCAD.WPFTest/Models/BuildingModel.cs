using System;
using System.Drawing;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Controllers;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Views.Pages;

namespace TechnoCAD.WPFTest.Models
{
    class BuildingModel : AbstractModel
    {
        public override string Title => "Building";
       

        public int? FloorCount { get; set; }
        public string Address { get; set; }
        public bool IsLiving { get; set; }

        public override bool IsWrong => !FloorCount.HasValue || string.IsNullOrEmpty(Address);
    }

    class BuildingViewAdapter : BuildingModel, IViewAdapter
    {
        public BuildingViewAdapter()
        {
            view = new Lazy<BuildingPage>(() => new BuildingPage { DataContext = new BuildingPageController(this) });
        }
        public Page View => view.Value;
        private Lazy<BuildingPage> view;

        public Bitmap Pic => Properties.Resources.wrong;// IsWrong ? Properties.Resources.wrong : null;

    }
}
