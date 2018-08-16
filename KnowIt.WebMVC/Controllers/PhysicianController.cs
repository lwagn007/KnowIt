using KnowIt.Services;
using KnowIt.Models.Physician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace KnowIt.WebMVC.Controllers
{
    [Authorize]
    public class PhysicianController : Controller
    {
        // GET: Physician
        public ActionResult Index()
        {
            PhysicianService service = NewMethod();
            var model = service.GetPhysicians();
            return View(model);
        }

        private PhysicianService NewMethod()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicianService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhysicianCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePhysicianService();

            if(service.CreatePhysician(model))
            {
                TempData["SaveResult"] = "Your physician entry was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Physician entry could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePhysicianService();
            var model = svc.GetPhysicianById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePhysicianService();
            var detail = service.GetPhysicianById(id);
            var model =
                new PhysicianEdit
                {
                    PhysicianId = detail.PhysicianId,
                    PhysicianFirstName = detail.PhysicianFirstName,
                    PhysicianLastName = detail.PhysicianLastName,
                    Specialty = detail.Specialty
                };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePhysicianService();
            var model = svc.GetPhysicianById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePhysician(int id)
        {
            var service = CreatePhysicianService();

            service.DeletePhysician(id);

            TempData["SaveResult"] = "Physician entry deleted.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PhysicianEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PhysicianId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePhysicianService();

            if(service.UpdatePhysician(model))
            {
                TempData["SaveResult"] = "Your physician entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your physician entry could not be updated.");
            return View(model);
        }

        private PhysicianService CreatePhysicianService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicianService(userId);
            return service;
        }
    }
}