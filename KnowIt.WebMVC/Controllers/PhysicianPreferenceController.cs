using KnowIt.Data;
using KnowIt.Models.Medication;
using KnowIt.Models.PhysicianProcedure;
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
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: PhysicianPreference //TODO uncomment int?s if populating multiple meds.  
        public ActionResult Index() //int? id, int? medicationId
        {
            var viewModel = new PhysicianPreference();
            PhysicianPreferenceService service = NewMethod();
            var model = service.GetPhysicianPreferences();

            //TODO 3 uncomment to show multiple medications
            //if (id != null)
            //{
            //    ViewBag.MedicationId = id.Value;
            //    viewModel.Medications = viewModel.PhysicianPreferences.Where(
            //        p => p.PhysicianPreferenceID == id.Value).Single().Medications;
            //}

            //if (medicationId != null)
            //{
            //    ViewBag.MedicationID = id.Value;
            //    viewModel.Medications = viewModel.PhysicianPreferences.Where(
            //        p => p.PhysicianPreferenceID == id.Value).Single().Medications;
            //}

            return View(model);
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
            ViewBag.ProcedureID = new SelectList(procedures, "ProcedureID", "ProcedureName");
            ViewBag.EquipmentID = new SelectList(equipments, "EquipmentID", "EquipmentName");
            //ViewBag.MedicationId = new SelectList(medications, "MedicationId", "MedicationName");

            var medication = new MedicationListItem();
            medication.Medications = new List<MedicationListItem>();
            PopulateAssignedMedicationData(medication);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        //PhysicianPreference was PhysicianPreferenceCreate
        public ActionResult Create(PhysicianPreferenceCreate model, string[] selectedMedications)
        {
            if (selectedMedications != null)
            {
                //model.Medications = new List<MedicationListItem>();

                foreach (var medication in selectedMedications)
                {
                    var physPrefService = CreatePhysicianPreferenceService();
                    var medId = int.Parse(medication);
                    model.MedicationId = medId;
                    physPrefService.CreatePhysicianPreference(model);
                    
                }
            }
            if (ModelState.IsValid)
            {
                //db.PhysicianPreferences.Add(model);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //PopulateAssignedCourseData(model);
            // We need to get the Med id

            //add the method        
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


        public ActionResult Edit(int id)
        {
            var service = CreatePhysicianPreferenceService();
            var detail = service.GetPhysicianPreferenceById(id);
            var model =
                new PhysicianPreferenceEdit
                {
                    //PhysicianPreferenceId = detail.PhysicianPreferenceId,
                    //PhysicianId = detail.PhysicianId,
                    //ProcedureId = detail.ProcedureId,
                    //MedicationId = detail.MedicationId,
                    //EquipmentId = detail.EquipmentId,
                    PhysicianFirstName = detail.PhysicianFirstName,
                    PhysicianLastName = detail.PhysicianLastName,
                    Specialty = detail.Specialty,
                    ProcedureName = detail.ProcedureName,
                    ProcedureNote = detail.ProcedureNote,
                    ProcedureRoute = detail.ProcedureRoute,
                    MedicationName = detail.MedicationName,
                    EquipmentName = detail.EquipmentName,
                    PreferenceNote = detail.PreferenceNote
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