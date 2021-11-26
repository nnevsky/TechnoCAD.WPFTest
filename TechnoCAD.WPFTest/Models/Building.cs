using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Views.Pages;

namespace TechnoCAD.WPFTest.Models
{
    class Building : AbstractModel
    {
        public override string Title => "Building";

        public override Page View => view;
        private Page view = new BuildingPage();
    }
}
