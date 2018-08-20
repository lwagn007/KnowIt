using KnowIt.Models.Procedure;
using KnowIt.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowIt.WebMVC.Controllers
{
    [Authorize]
    public class ProcedureController : Controller
    {
        public ActionResult Index()
        {
            ProcedureService service = NewMethod();
            var model = service.GetProcedures();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcedureCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProcedureService();

            if (service.CreateProcedure(model))
            {
                TempData["SaveResult"] = "Your procedure entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Procedure entry could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProcedureService();
            var model = svc.GetProcedureById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProcedureService();
            var detail = service.GetProcedureById(id);
            var model =
                new ProcedureEdit
                {
                    ProcedureId = detail.ProcedureId,
                    ProcedureName = detail.ProcedureName,
                    ProcedureNote = detail.ProcedureNote,
                    ProcedureRoute = detail.ProcedureRoute
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProcedureEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ProcedureId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProcedureService();

            if(service.UpdateProcedure(model))
            {
                TempData["SaveResult"] = "Your procedure entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your procedure entry could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProcedureService();
            var model = svc.GetProcedureById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProcedure(int id)
        {
            var service = CreateProcedureService();

            service.DeleteProcedure(id);

            TempData["SaveResult"] = "Procedure entry deleted.";

            return RedirectToAction("Index");
        }

        private ProcedureService CreateProcedureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProcedureService(userId);
            return service;
        }

        private ProcedureService NewMethod()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProcedureService(userId);
            return service;
        }
    }
}