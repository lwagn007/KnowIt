using KnowIt.Models.Equipment;
using KnowIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowIt.WebMVC.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index()
        {
            EquipmentService service = NewMethod();
            var model = service.GetEquipments();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EquipmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEquipmentService();

            if (service.CreateEquipment(model))
            {
                TempData["SaveResult"] = "Your equipment entry was saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Equipment entry could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEquipmentService();
            var detail = service.GetEquipmentById(id);
            var model =
                new EquipmentEdit
                {
                    EquipmentId = detail.EquipmentId,
                    EquipmentName = detail.EquipmentName,
                    EquipmentNote = detail.EquipmentNote
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EquipmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EquipmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEquipmentService();

            if (service.UpdateEquipment(model))
            {
                TempData["SaveResult"] = "Your equipment entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your equipment entry could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEquipment(int id)
        {
            var service = CreateEquipmentService();

            service.DeleteEquipment(id);

            TempData["SaveResult"] = "Equipment entry deleted.";

            return RedirectToAction("Index");
        }

        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;
        }

        private EquipmentService NewMethod()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;
        }
    }
}