using System;
using System.Collections.Generic;
using System.Data;
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
    public class PhysicalQuantitiesController : Controller
    {
        private readonly BaseRepo<PhysicalQuantity> repo = new BaseRepo<PhysicalQuantity>();

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
            PhysicalQuantity physicalQuantity = repo.GetOne(id);
            if (physicalQuantity == null)
            {
                return HttpNotFound();
            }
            return View(physicalQuantity);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Designation,Unit,Name")] PhysicalQuantity physicalQuantity)
        {
            if (ModelState.IsValid)
            {
                repo.Add(physicalQuantity);
                return RedirectToAction("Index");
            }

            return View(physicalQuantity);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalQuantity physicalQuantity = repo.GetOne(id);
            if (physicalQuantity == null)
            {
                return HttpNotFound();
            }
            return View(physicalQuantity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Designation,Unit,Name")] PhysicalQuantity physicalQuantity)
        {
            if (ModelState.IsValid)
            {
                repo.Save(physicalQuantity);
                return RedirectToAction("Index");
            }
            return View(physicalQuantity);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhysicalQuantity physicalQuantity = repo.GetOne(id);
            if (physicalQuantity == null)
            {
                return HttpNotFound();
            }
            return View(physicalQuantity);
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
