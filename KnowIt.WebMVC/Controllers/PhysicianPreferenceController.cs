using KnowIt.Data;
using KnowIt.Models.PhysicianProcedure;
using KnowIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowIt.WebMVC.Controllers
{
    public class PhysicianPreferenceController : Controller
    {
        // GET: PhysicianPreference
        public ActionResult Index()
        {
            PhysicianPreferenceService service = NewMethod();
            var model = service.GetPhysicianPreferences();
            return View(model);
        }

        public ActionResult Create()
        {
            var physicianService = CreatePhysicianService();
            var procedureService = CreateProcedureService();

            ViewBag.PhysicianID = new SelectList(physicianService.GetPhysicians(), "PhysicianID", "PhysicianLastName");
            ViewBag.ProcedureID = new SelectList(procedureService.GetProcedures(), "ProcedureID", "ProcedureName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhysicianPreferenceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePhysicianPreferenceService();
            var physicianService = CreatePhysicianService();
            var procedureService = CreateProcedureService();

            physicianService.GetPhysicianById(model.PhysicianId);
            procedureService.GetProcedureById(model.ProcedureId);

            ViewBag.PhysicianID = new SelectList(physicianService.GetPhysicians(), "PhysicianID", "PhysicianLastName", model.PhysicianId);
            ViewBag.ProcedureID = new SelectList(procedureService.GetProcedures(), "ProcedureID", "ProcedureName", model.ProcedureId);

            if (service.CreatePhysicianPreference(model))
            {
                TempData["SaveResult"] = "Your physician preference entry was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Physician preference entry could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePhysicianPreferenceService();
            var model = svc.GetPhysicianPreferenceById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreatePhysicianPreferenceService();
            var detail = service.GetPhysicianPreferenceById(id);
            var model =
                new PhysicianPreferenceEdit
                {
                    PhysicianPreferenceId = detail.PhysicianPreferenceId,
                    PhysicianId = detail.PhysicianId,
                    ProcedureId = detail.ProcedureId,
                    PhysicianFirstName = detail.PhysicianFirstName,
                    PhysicianLastName = detail.PhysicianLastName,
                    Specialty = detail.Specialty,
                    ProcedureName = detail.ProcedureName,
                    ProcedureNote = detail.ProcedureNote,
                    ProcedureRoute = detail.ProcedureRoute
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PhysicianPreferenceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PhysicianPreferenceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePhysicianPreferenceService();

            if (service.UpdatePhysicianPreference(model))
            {
                TempData["SaveResult"] = "Your physician preference entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your physician preference entry could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePhysicianPreferenceService();
            var model = svc.GetPhysicianPreferenceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhysicianPreference(int id)
        {
            var service = CreatePhysicianPreferenceService();

            service.DeletePhysicianPreference(id);

            TempData["SaveResult"] = "Physician Preference entry deleted.";

            return RedirectToAction("Index");
        }

        private ProcedureService CreateProcedureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProcedureService(userId);
            return service;
        }
        private PhysicianService CreatePhysicianService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicianService(userId);
            return service;
        }

        private PhysicianPreferenceService CreatePhysicianPreferenceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicianPreferenceService(userId);
            return service;
        }

        private PhysicianPreferenceService NewMethod()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicianPreferenceService(userId);
            return service;
        }
    }
}