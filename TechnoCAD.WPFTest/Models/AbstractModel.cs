using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoCAD.WPFTest.Models
{
    public abstract class AbstractModel
    {
        public abstract string Title { get; }

        public Guid Id { get; set; }
    }
}
