using System.Drawing;
using System.Windows.Controls;

namespace TechnoCAD.WPFTest.Interfaces
{
    interface IViewAdapter
    {
        Page View { get; }
        string PicSource { get; }
    }
}
