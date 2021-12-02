using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Controllers;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Models.Alerts;
using TechnoCAD.WPFTest.Views.Pages;

namespace TechnoCAD.WPFTest.Models
{
    class ParcelModel : AbstractModel
    {
        public override string Title => "Parcel";

        public string Number { get; set; }
        public string Location { get; set; }

        public override bool IsWrong => string.IsNullOrEmpty(Number) || string.IsNullOrEmpty(Location);

    }

    class ParcelViewAdapter : ParcelModel, IViewAdapter, IAlertAdapter, INotifyPropertyChanged
    {
        public ParcelViewAdapter(IAlertGenerator allertGenerator)
        { 
            view = new ParcelView { DataContext = new ParcelViewDataContext(this, allertGenerator) };
        }
        public Page View => view;
        private ParcelView view;

        public string PicSource => IsWrong ? @"pack://application:,,,/Assets\wrong.png" 
                                    : @"pack://application:,,,/Assets\parcel.png";

        public IEnumerable<AlertModel> Allerts
        {
            get
            {
                List<AlertModel> allerts = new List<AlertModel>();
                if(string.IsNullOrEmpty(Number))
                {
                    allerts.Add(new AlertParcelNumber(view) { Id = base.Id, Field = nameof(Number) });
                }
                if(string.IsNullOrEmpty(Location))
                {
                    allerts.Add(new AlertParcelLocation(view) { Id = base.Id, Field = nameof(Location) });
                }

                OnPropertyChanged(nameof(PicSource));

                return allerts;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propMane)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propMane));
        }
    }

}
