using System.ComponentModel;
using System.Windows;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Models;

namespace TechnoCAD.WPFTest.Controllers
{
    class ParcelViewDataContext : DependencyObject
    {
        private ParcelModel model;
        private IAlertGenerator allertGenerator;
        public ParcelViewDataContext(ParcelModel model, IAlertGenerator allertGenerator)
        {
            this.model = model;
            this.allertGenerator = allertGenerator;
        }

        public string Number 
        {
            get => model.Number;
            set
            {
                model.Number = value;
                allertGenerator.GenerateAlerts();
            }
        }
        public string Location 
        {
            get => model.Location;
            set
            {
                model.Location = value;
                allertGenerator.GenerateAlerts();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propMane)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propMane));
        }
    }
}
