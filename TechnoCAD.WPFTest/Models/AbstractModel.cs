using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TechnoCAD.WPFTest.Models
{
    public abstract class AbstractModel
    {
        public abstract string Title { get; }

        public Guid Id { get; set; }

        public abstract Page View { get; }
    }
}
