using System;
using TechnoCAD.WPFTest.Interfaces;

namespace TechnoCAD.WPFTest.Models.Alerts
{
    abstract class AlertModel
    {
        public Guid Id { get; set; }
        public string Field { get; set; }
        public abstract string Message { get; }

        public abstract void OnSelected();
       
    }

    class AlertBuildingAddress : AlertModel
    {
        readonly IBuildingFocus focus;
        public AlertBuildingAddress(IBuildingFocus focus)
        {
            this.focus = focus;
        }
        public override string Message => "Задайте адрес расположение здания";

        public override void OnSelected() => focus.AddressFocus();
        
    }
    class AlertBuildingFloorCount : AlertModel
    {
        readonly IBuildingFocus focus;
        public AlertBuildingFloorCount(IBuildingFocus focus)
        {
            this.focus = focus;
        }
        public override string Message => "Задайте количество этажей здания";

        public override void OnSelected() => focus.FloorCountFocus();
        
    }
    class AlertBuildingIsLiving : AlertModel
    {
        readonly IBuildingFocus focus;
        public AlertBuildingIsLiving(IBuildingFocus focus)
        {
            this.focus = focus;
        }
        public override string Message => "Укажите жилое или не жилое помещение";

        public override void OnSelected() => focus.IsLivingFocus();
        
    }

    class AlertParcelNumber : AlertModel
    {
        readonly IParcelFocus focus;
        public AlertParcelNumber(IParcelFocus focus) => this.focus = focus;
        
        public override string Message => "Задайте номер участка";

        public override void OnSelected() => focus.ParcelNamberFocus();
    }

    class AlertParcelLocation : AlertModel
    {
        readonly IParcelFocus focus;
        public AlertParcelLocation(IParcelFocus focus) => this.focus = focus;
        public override string Message => "Задайте расположение участка";

        public override void OnSelected() => focus.ParcelLocationFocus();
    }
}
