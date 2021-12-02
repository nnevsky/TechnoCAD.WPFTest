using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoCAD.WPFTest.Models;
using TechnoCAD.WPFTest.Models.Alerts;

namespace TechnoCAD.WPFTest.Interfaces
{
    interface IAlertAdapter
    {
        IEnumerable<AlertModel> Allerts { get; }
    }
}
