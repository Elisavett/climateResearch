using climateResearch.Models.Entities;
using climateResearch.Repos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace climateResearch.Models.ViewModels
{
    public class JsonViewModel
    {
        public string Json { get; set; }
        public List<PhysicalQuantity> PhysicalQuantities { get; set; }
    }
    public class ObservationPointOnMap
    {
        public ObservationPointOnMap(ObservationPoint observationPoint)
        {
            Latitude = observationPoint.Latitude;
            Longtitude = observationPoint.Longtitude;
            Name = observationPoint.Name;
        }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public string Name { get; set; }
        public string MeasuredValue { get; set; }
    }
    public class ViewModels
    {
        public static SelectList GetSelectList<T>() where T : EntityBase, new()
        {
            using (BaseRepo<T> someRepo = new BaseRepo<T>())
            {
                return new SelectList(someRepo.GetAll(), "Id", "Name");
            }
        }
    }
    
}