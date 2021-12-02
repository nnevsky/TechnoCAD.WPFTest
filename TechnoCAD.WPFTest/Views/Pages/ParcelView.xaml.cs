using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechnoCAD.WPFTest.Interfaces;

namespace TechnoCAD.WPFTest.Views.Pages
{
    /// <summary>
    /// Interaction logic for ParcelPage.xaml
    /// </summary>
    public partial class ParcelView : Page, IParcelFocus
    {
        public ParcelView()
        {
            InitializeComponent();
        }

        public void ParcelNamberFocus()
        {
            ParcelNumber.Focus();
        }
        public void ParcelLocationFocus()
        {
            ParcelLocation.Focus();
        }
    }
}
