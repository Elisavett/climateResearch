using climateResearch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using climateResearch.Models.Entities;
using climateResearch.Models.ViewModels;
using climateResearch.Repos;
using climateResearch.ExternalDatabase;

namespace climateResearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(long physicalQuantityId = 1)
        {
            JsonViewModel viewModel = new JsonViewModel();
            using (BaseRepo<PhysicalQuantity> physicalQuantityRepo = new BaseRepo<PhysicalQuantity>())
            {
                PhysicalQuantity physicalQuantity = physicalQuantityRepo.GetOne(physicalQuantityId);
                //Элементы выпадающего списка физ. величин
                viewModel.PhysicalQuantities = physicalQuantityRepo.GetAll();
                //Для отображения точек и измеренных значений на карте
                viewModel.Json = DBManager.getDbJsonData(physicalQuantity);
            }
            return View(viewModel);
        }

        public ActionResult ObservationPoints()
        {
            List<ObservationPoint> observationPointList = new List<ObservationPoint>();
            using (BaseRepo<ObservationPoint> observationPointRepo = new BaseRepo<ObservationPoint>())
            {
                observationPointList = observationPointRepo.GetAll();
            }
            return View(observationPointList);
        }

        public ActionResult PhysicalQuantities()
        {
            List<PhysicalQuantity> physicalQuantityList = new List<PhysicalQuantity>();
            using (BaseRepo<PhysicalQuantity> physicalQuantityRepo = new BaseRepo<PhysicalQuantity>())
            {
                physicalQuantityList = physicalQuantityRepo.GetAll();
            }
            return View(physicalQuantityList);
        }
    }
}