using KnowIt.Data;
using KnowIt.Models.Equipment;
using KnowIt.Models.Medication;
using KnowIt.Models.PhysicianProcedure;
using KnowIt.Models.Procedure;
using KnowIt.Services;
using KnowIt.WebMVC.ViewModels;
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
        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult Create()
        {
            var physicianService = CreatePhysicianService();
            var procedureService = CreateProcedureService();
            var medicationService = CreateMedicationService();
            var equipmentService = CreateEquipmentService();

            var physicians = physicianService.GetPhysicians();
            var procedures = procedureService.GetProcedures();
            var medications = medicationService.GetMedications();
            var equipments = equipmentService.GetEquipments();


            ViewBag.PhysicianID = new SelectList(physicians, "PhysicianID", "PhysicianLastName");
            //ViewBag.ProcedureID = new SelectList(procedures, "ProcedureID", "ProcedureName");
            //ViewBag.EquipmentID = new SelectList(equipments, "EquipmentID", "EquipmentName");
            //ViewBag.MedicationId = new SelectList(medications, "MedicationId", "MedicationName");

            var medication = new MedicationListItem();
            medication.Medications = new List<MedicationListItem>();
            PopulateAssignedMedicationData(medication);

            var equipment = new EquipmentListItem();
            equipment.Equipments = new List<EquipmentListItem>();
            PopulateAssignedEquipmentData(equipment);

            var procedure = new ProcedureListItem();
            procedure.Procedures = new List<ProcedureListItem>();
            PopulateAssignedProcedureData(procedure);

            return View();
        }


        //TODO 1 
        private void PopulateAssignedMedicationData(MedicationListItem allMedication)
        {
            var medService = CreateMedicationService();
            var allMeds = medService.GetMedications();

            var viewModel = new List<MedicationListItem>();

            foreach (var med in allMeds)
            {
                viewModel.Add(new MedicationListItem
                {
                    MedicationId = med.MedicationId,
                    Assigned = med.Assigned,
                    MedicationName = med.MedicationName
                });
            }

            ViewBag.AllMedicationsInBag = viewModel;
        }

        private void PopulateAssignedEquipmentData(EquipmentListItem allEquipment)
        {
            var equipService = CreateEquipmentService();
            var allEquips = equipService.GetEquipments();

            var viewModel = new List<EquipmentListItem>();

            foreach (var equip in allEquips)
            {
                viewModel.Add(new EquipmentListItem
                {
                    EquipmentId = equip.EquipmentId,
                    Assigned = equip.Assigned,
                    EquipmentName = equip.EquipmentName
                });
            }

            ViewBag.AllEquipmentsInBag = viewModel;
        }

        private void PopulateAssignedProcedureData(ProcedureListItem allProcedure)
        {
            var procedService = CreateProcedureService();
            var allProceds = procedService.GetProcedures();

            var viewModel = new List<ProcedureListItem>();

            foreach (var proced in allProceds)
            {
                viewModel.Add(new ProcedureListItem
                {
                    ProcedureId = proced.ProcedureId,
                    Assigned = proced.Assigned,
                    ProcedureName = proced.ProcedureName
                });
            }

            ViewBag.AllProceduresInBag = viewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhysicianPreferenceCreate model, string[] selectedMedications, string[] selectedEquipments, string[] selectedProcedures)
        {
            if (selectedMedications != null && selectedEquipments !=null && selectedProcedures != null)
            {
                foreach (var medication in selectedMedications)
                {
                    var physPrefService = CreatePhysicianPreferenceService();
                    var medId = int.Parse(medication);
                    model.MedicationId = medId;
                    physPrefService.CreatePhysicianPreference(model);
                    
                }
                foreach (var equipment in selectedEquipments)
                {
                    var physPrefService = CreatePhysicianPreferenceService();
                    var equipId = int.Parse(equipment);
                    model.EquipmentId = equipId;
                    physPrefService.CreatePhysicianPreference(model);
                }
                foreach (var procedure in selectedProcedures)
                {
                    var physPrefService = CreatePhysicianPreferenceService();
                    var procedId = int.Parse(procedure);
                    model.ProcedureId = procedId;
                    physPrefService.CreatePhysicianPreference(model);
                }
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
    
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
        //            PhysicianPreferenceId = detail.PhysicianPreferenceId,
        //            PhysicianId = detail.PhysicianId,
        //            ProcedureId = detail.ProcedureId,
        //            MedicationId = detail.MedicationId,
        //            EquipmentId = detail.EquipmentId,
        //            PhysicianFirstName = detail.PhysicianFirstName,
        //            PhysicianLastName = detail.PhysicianLastName,
        //            Specialty = detail.Specialty,
        //            ProcedureName = detail.ProcedureName,
        //            ProcedureNote = detail.ProcedureNote,
        //            ProcedureRoute = detail.ProcedureRoute,
        //            MedicationName = detail.MedicationName,
        //            EquipmentName = detail.EquipmentName,
        //            PreferenceNote = detail.PreferenceNote
        //        };
        //    return View(model);
        //}

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

        private MedicationService CreateMedicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MedicationService(userId);
            return service;
        }

        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
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