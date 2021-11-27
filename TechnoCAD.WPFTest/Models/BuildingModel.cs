using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Controllers;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Views.Pages;

namespace TechnoCAD.WPFTest.Models
{
    class BuildingModel : AbstractModel
    {
        private string address;
        private int? floorCount;
        private bool? isLiving;

        public override string Title => "Building";


        public int? FloorCount
        {
            get => floorCount;
            set
            {
                floorCount = value;
            }
        }
        public string Address 
        { 
            get => address;
            set
            {
                address = value;
            }
        }
        public bool? IsLiving 
        { 
            get => isLiving;
            set
            {
                isLiving = value;
            }
        }

        public override bool IsWrong => !FloorCount.HasValue || string.IsNullOrEmpty(Address) || !IsLiving.HasValue;
    }

    class BuildingViewAdapter : BuildingModel, IViewAdapter, IAllertAdapter, INotifyPropertyChanged
    {
        public BuildingViewAdapter(IAllertGenerator allertGenerator)
        {
            view = new Lazy<BuildingView>(() => new BuildingView { DataContext = new BuildingViewDataContext(this, allertGenerator) });
        }
        public Page View => view.Value;
        private Lazy<BuildingView> view;

        public string PicSource => IsWrong ? @"pack://application:,,,/Assets\wrong.png" 
                                          : @"pack://application:,,,/Assets\building.png";

        public IEnumerable<AllertModel> Allerts
        {
            get
            {
                List<AllertModel> allerts = new List<AllertModel>();
                if (!FloorCount.HasValue)
                {
                    allerts.Add(new AllertModel { Id = base.Id, Field = nameof(FloorCount), Message = "Задайте количество этажей здания" });
                }
                if (string.IsNullOrEmpty(Address))
                {
                    allerts.Add(new AllertModel { Id = base.Id, Field = nameof(Address), Message = "Задайте адрес расположение здания" });
                }
                if (!IsLiving.HasValue)
                {
                    allerts.Add(new AllertModel { Id = base.Id, Field = nameof(IsLiving), Message = "Укажите жилое или нежилое помещение" });
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
