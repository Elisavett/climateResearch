using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using climateResearch.Models;
using climateResearch.Models.Entities;
using climateResearch.Repos;

namespace climateResearch.Controllers
{
    /*
     * CRUD для пунтков наблюдения
     */
    public class ObservationPointsController : Controller
    {
        private readonly BaseRepo<ObservationPoint> repo = new BaseRepo<ObservationPoint>();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObservationPoint observationPoint = repo.GetOne(id);
            if (observationPoint == null)
            {
                return HttpNotFound();
            }
            return View(observationPoint);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Latitude,Longtitude,Name")] ObservationPoint observationPoint)
        {
            if (ModelState.IsValid)
            {
                repo.Add(observationPoint);
                return RedirectToAction("Index");
            }

            return View(observationPoint);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObservationPoint observationPoint = repo.GetOne(id);
            if (observationPoint == null)
            {
                return HttpNotFound();
            }
            return View(observationPoint);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Latitude,Longtitude,Name")] ObservationPoint observationPoint)
        {
            if (ModelState.IsValid)
            {
                repo.Save(observationPoint);
                return RedirectToAction("Index");
            }
            return View(observationPoint);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObservationPoint observationPoint = repo.GetOne(id);
            if (observationPoint == null)
            {
                return HttpNotFound();
            }
            return View(observationPoint);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddMeasuringInstrument(long obsPointId)
        {
            ObservationPoint observationPoint = repo.GetOne(obsPointId);
            ViewBag.ObservationPointId = observationPoint.Id;
            ViewBag.ObservationPointName = observationPoint.Name;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMeasuringInstrument([Bind(Include = "Id,Description,ObservationPointId,Name")] MeasuringInstrument measuringInstrument)
        {
            if (ModelState.IsValid)
            {
                using(BaseRepo<MeasuringInstrument> measuringInstrumentRepo = new BaseRepo<MeasuringInstrument>())
                {
                    measuringInstrumentRepo.Add(measuringInstrument);
                }
                
                return RedirectToAction("Details/" + measuringInstrument.ObservationPointId);
            }
            ObservationPoint observationPoint = repo.GetOne(measuringInstrument.ObservationPointId);
            ViewBag.ObservationPointId = observationPoint.Id;
            ViewBag.ObservationPointName = observationPoint.Name;
            return View(measuringInstrument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
