using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Controllers;
using TechnoCAD.WPFTest.Interfaces;
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

    class ParcelViewAdapter : ParcelModel, IViewAdapter, IAllertAdapter, INotifyPropertyChanged
    {
        public ParcelViewAdapter(IAllertGenerator allertGenerator)
        { 
            view = new Lazy<ParcelPage>(() => new ParcelPage { DataContext = new ParcelPageController(this, allertGenerator) });
        }
        public Page View => view.Value;
        private Lazy<ParcelPage> view;

        public string PicSource => IsWrong ? @"pack://application:,,,/Assets\wrong.png" 
                                    : @"pack://application:,,,/Assets\parcel.png";

        public IEnumerable<AllertModel> Allerts
        {
            get
            {
                List<AllertModel> allerts = new List<AllertModel>();
                if(string.IsNullOrEmpty(Number))
                {
                    allerts.Add(new AllertModel { Id = base.Id, Field = nameof(Number), Message = "Задайте номер участка" });
                }
                if(string.IsNullOrEmpty(Location))
                {
                    allerts.Add(new AllertModel { Id = base.Id, Field = nameof(Location), Message = "Задайте расположение участка" });
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
