using System;
using System.Drawing;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Controllers;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Views.Pages;

namespace TechnoCAD.WPFTest.Models
{
    class ParcelModel : AbstractModel
    {
        public override string Title => "Parcel";

        public string Number { get; set; }
        public string Location { get; set; }

        public override bool IsWrong => string.IsNullOrEmpty(Number) || string.IsNullOrEmpty(Location);

    }

    class ParcelViewAdapter : ParcelModel, IViewAdapter
    {
        public ParcelViewAdapter()
        { 
            view = new Lazy<ParcelPage>(() => new ParcelPage { DataContext = new ParcelPageController(this) });
        }
        public Page View => view.Value;
        private Lazy<ParcelPage> view;

        public Bitmap Pic => Properties.Resources.wrong;// IsWrong ? Properties.Resources.wrong : null;
    }

}
