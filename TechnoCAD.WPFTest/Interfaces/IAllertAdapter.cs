using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Interfaces
{
    interface IAllertAdapter
    {
        IEnumerable<AllertModel> Allerts { get; }
    }
}
