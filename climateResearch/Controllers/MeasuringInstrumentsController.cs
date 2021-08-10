using System.Net;
using System.Web.Mvc;
using climateResearch.Models.Entities;
using climateResearch.Models.ViewModels;
using climateResearch.Repos;

namespace climateResearch.Controllers
{
    /*
     * CRUD для измерительных приборов
     */
    public class MeasuringInstrumentsController : Controller
    {
        private readonly BaseRepo<MeasuringInstrument> repo = new BaseRepo<MeasuringInstrument>();

        public ActionResult Index()
        {
            return View(repo.GetAllAndInclude(new string[] {"ObservationPoint"}));
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasuringInstrument measuringInstrument = repo.GetOne(id);
            if (measuringInstrument == null)
            {
                return HttpNotFound();
            }
            return View(measuringInstrument);
        }

        public ActionResult Create()
        {
            ViewBag.ObservationPointId = ViewModels.GetSelectList<ObservationPoint>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,ObservationPointId,Name")] MeasuringInstrument measuringInstrument)
        {
            if (ModelState.IsValid)
            {
                repo.Add(measuringInstrument);
                return RedirectToAction("Index");
            }
            ViewBag.ObservationPointId = ViewModels.GetSelectList<ObservationPoint>();
            return View(measuringInstrument);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasuringInstrument measuringInstrument = repo.GetOne(id);
            if (measuringInstrument == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObservationPointId = ViewModels.GetSelectList<ObservationPoint>();
            return View(measuringInstrument);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,ObservationPointId,Name")] MeasuringInstrument measuringInstrument)
        {
            if (ModelState.IsValid)
            {
                repo.Save(measuringInstrument);
                return RedirectToAction("Index");
            }
            ViewBag.ObservationPointId = ViewModels.GetSelectList<ObservationPoint>();
            return View(measuringInstrument);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasuringInstrument measuringInstrument = repo.GetOne(id);
            if (measuringInstrument == null)
            {
                return HttpNotFound();
            }
            return View(measuringInstrument);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddSensor(long measInstrId)
        {
            MeasuringInstrument measuringInstrument = repo.GetOne(measInstrId);
            ViewBag.MeasuringInstrumentId = measuringInstrument.Id;
            ViewBag.MeasuringInstrumentName = measuringInstrument.Name;
            ViewBag.PhysicalQuantityId = ViewModels.GetSelectList<PhysicalQuantity>();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MeasurementMode,Designation,DbName,DbTable,MeasuringInstrumentId,PhysicalQuantityId,Name")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                using (BaseRepo<Sensor> sensorRepo = new BaseRepo<Sensor>())
                {
                    sensorRepo.Add(sensor);
                }

                return RedirectToAction("Details/" + sensor.MeasuringInstrumentId);
            }
            MeasuringInstrument measuringInstrument = repo.GetOne(sensor.MeasuringInstrumentId);
            ViewBag.MeasuringInstrumentId = measuringInstrument.Id;
            ViewBag.MeasuringInstrumentName = measuringInstrument.Name;
            ViewBag.PhysicalQuantityId = ViewModels.GetSelectList<PhysicalQuantity>();
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
