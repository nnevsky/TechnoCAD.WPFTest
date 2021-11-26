using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Views.Pages;

namespace TechnoCAD.WPFTest.Models
{
    class ParcelModel : AbstractModel
    {
        public override string Title => "Parcel";

        public override Page View => view.Value;
        private Lazy<ParcelPage> view = new Lazy<ParcelPage>();

        public string Number { get; set; }
        public string Location { get; set; }

        public override bool IsWrong => string.IsNullOrEmpty(Number) || string.IsNullOrEmpty(Location);
    }

   

}
