using KnowIt.Models.Medication;
using KnowIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowIt.WebMVC.Controllers
{
    public class MedicationController : Controller
    {
        // GET: Medication
        public ActionResult Index()
        {
            MedicationService service = NewMethod();
            var model = service.GetMedications();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMedicationService();

            if(service.CreateMedication(model))
            {
                TempData["SaveResult"] = "Your medication entry was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Medication entry could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMedicationService();
            var model = svc.GetMedicationById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMedicationService();
            var detail = service.GetMedicationById(id);
            var model =
                new MedicationEdit
                {
                    MedicationId = detail.MedicationId,
                    MedicationName = detail.MedicationName,
                    MedicationClass = detail.MedicationClass,
                    MedicationUse = detail.MedicationUse
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.MedicationId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMedicationService();

            if(service.UpdateMedication(model))
            {
                TempData["SaveResult"] = "Your medication entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your medication entry could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMedicationService();
            var model = svc.GetMedicationById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMedication(int id)
        {
            var service = CreateMedicationService();

            service.DeleteMedication(id);

            TempData["SaveResult"] = "Medication entry deleted.";

            return RedirectToAction("Index");
        }


        private MedicationService CreateMedicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MedicationService(userId);
            return service;
        }

        private MedicationService NewMethod()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MedicationService(userId);
            return service;
        }
    }
}