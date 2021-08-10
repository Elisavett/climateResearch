using System.Net;
using System.Web.Mvc;
using climateResearch.Models.Entities;
using climateResearch.Models.ViewModels;
using climateResearch.Repos;

namespace climateResearch.Controllers
{
    public class SensorsController : Controller
    {
        private readonly BaseRepo<Sensor> repo = new BaseRepo<Sensor>();

        public ActionResult Index()
        {
            return View(repo.GetAllAndInclude(new string[] { "MeasuringInstrument", "PhysicalQuantity" }));
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = repo.GetOne(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        public ActionResult Create()
        {
            ViewBag.MeasuringInstrumentId = ViewModels.GetSelectList<MeasuringInstrument>();
            ViewBag.PhysicalQuantityId = ViewModels.GetSelectList<PhysicalQuantity>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MeasurementMode,Designation,DbName,DbTable,MeasuringInstrumentId,PhysicalQuantityId,Name")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                repo.Add(sensor);
                return RedirectToAction("Index");
            }

            ViewBag.MeasuringInstrumentId = ViewModels.GetSelectList<MeasuringInstrument>();
            ViewBag.PhysicalQuantityId = ViewModels.GetSelectList<PhysicalQuantity>();
            return View(sensor);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = repo.GetOne(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeasuringInstrumentId = ViewModels.GetSelectList<MeasuringInstrument>();
            ViewBag.PhysicalQuantityId = ViewModels.GetSelectList<PhysicalQuantity>();
            return View(sensor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MeasurementMode,Designation,DbName,DbTable,MeasuringInstrumentId,PhysicalQuantityId,Name")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                repo.Save(sensor);
                return RedirectToAction("Index");
            }
            ViewBag.MeasuringInstrumentId = ViewModels.GetSelectList<MeasuringInstrument>();
            ViewBag.PhysicalQuantityId = ViewModels.GetSelectList<PhysicalQuantity>();
            return View(sensor);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = repo.GetOne(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
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
