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
                return View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhysicianPreferenceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePhysicianPreferenceService();

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

        //public ActionResult Edit(int id)
        //{
        //    var service = CreatePhysicianPreferenceService();
        //    var detail = service.GetPhysicianPreferenceById(id);
        //    var model =
        //        new PhysicianPreferenceEdit
        //        {

        //            PhysicianFirstName = detail.PhysicianFirstName,
        //            PhysicianLastName = detail.PhysicianLastName,
        //            Specialty = detail.Specialty
        //        };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, PhysicianPreferenceEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.PhysicianPreferenceId != id)
        //    {
        //        ModelState.AddModelError("", "Id Mismatch");
        //        return View(model);
        //    }

        //    var service = CreatePhysicianPreferenceService();

        //    if (service.UpdatePhysicianPreference(model))
        //    {
        //        TempData["SaveResult"] = "Your physician preference entry was updated.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Your physician preference entry could not be updated.");
        //    return View(model);
        //}

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