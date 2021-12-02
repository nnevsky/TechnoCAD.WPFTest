using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using TechnoCAD.WPFTest.Controllers;
using TechnoCAD.WPFTest.Interfaces;
using TechnoCAD.WPFTest.Models.Alerts;
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

    class BuildingViewAdapter : BuildingModel, IViewAdapter, IAlertAdapter, INotifyPropertyChanged
    {
        public BuildingViewAdapter(IAlertGenerator allertGenerator)
        {
            view = new BuildingView { DataContext = new BuildingViewDataContext(this, allertGenerator) };
        }
        public Page View => view;
        private BuildingView view;

        public string PicSource => IsWrong ? @"pack://application:,,,/Assets\wrong.png" 
                                          : @"pack://application:,,,/Assets\building.png";

        public IEnumerable<AlertModel> Allerts
        {
            get
            {
                List<AlertModel> allerts = new List<AlertModel>();
                if (!FloorCount.HasValue)
                {
                    allerts.Add(new AlertBuildingFloorCount(view) { Id = Id, Field = nameof(FloorCount) });
                }
                if (string.IsNullOrEmpty(Address))
                {
                    allerts.Add(new AlertBuildingAddress(view) { Id = Id, Field = nameof(Address) });
                }
                if (!IsLiving.HasValue)
                {
                    allerts.Add(new AlertBuildingIsLiving(view) { Id = Id, Field = nameof(IsLiving) });
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
