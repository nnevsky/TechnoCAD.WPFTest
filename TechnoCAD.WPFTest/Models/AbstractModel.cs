using System;
using System.Drawing;

namespace TechnoCAD.WPFTest.Models
{
    public abstract class AbstractModel
    {
        public abstract string Title { get; }

        public Guid Id { get; set; }
      

        public abstract bool IsWrong { get; }

    }
}
