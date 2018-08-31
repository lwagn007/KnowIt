using KnowIt.Contracts;
using KnowIt.Data;
using KnowIt.Models.PhysicianProcedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Services
{
    public class PhysicianPreferenceService : IPhysicianPreferenceService
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private readonly Guid _userId;

        public PhysicianPreferenceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePhysicianPreference(PhysicianPreferenceCreate model)
        {
            var entity =
                new PhysicianPreference()
                {
                    OwnerID = _userId,
                    PhysicianID = model.PhysicianId,
                    ProcedureID = model.ProcedureId,
                    EquipmentID = model.EquipmentId,
                    MedicationID = model.MedicationId,
                    PreferenceNote = model.PreferenceNote
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PhysicianPreferences.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }

        public IEnumerable<PhysicianPreferenceListItem> GetPhysicianPreferences()
        {
            System.Diagnostics.Debugger.NotifyOfCrossThreadDependency();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PhysicianPreferences
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e => new PhysicianPreferenceListItem
                        {
                            PhysicianPreferenceId = e.PhysicianPreferenceID,
                            PhysicianId = e.Physician.PhysicianID,
                            ProcedureId = e.Procedure.ProcedureID,
                            MedicationId = e.Medication.MedicationID,
                            EquipmentId = e.Equipment.EquipmentID,
                            PhysicianLastName = e.Physician.PhysicianLastName,
                            ProcedureName = e.Procedure.ProcedureName
                        }
                      );
                return query.ToArray();
            }
        }

        public PhysicianPreferenceDetail GetPhysicianPreferenceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PhysicianPreferences
                        .Single(e => e.PhysicianPreferenceID == id && e.OwnerID == _userId);
                return
                    new PhysicianPreferenceDetail
                    {
                        PhysicianPreferenceId = entity.PhysicianPreferenceID,
                        PhysicianId = entity.Physician.PhysicianID,
                        ProcedureId = entity.Procedure.ProcedureID,
                        MedicationId = entity.Medication.MedicationID,
                        EquipmentId = entity.Equipment.EquipmentID,
                        PhysicianLastName = entity.Physician.PhysicianLastName,
                        PhysicianFirstName = entity.Physician.PhysicianFirstName,
                        Specialty = entity.Physician.Specialty,
                        ProcedureName = entity.Procedure.ProcedureName,
                        ProcedureNote = entity.Procedure.ProcedureNote,
                        ProcedureRoute = entity.Procedure.ProcedureRoute,
                        MedicationName = entity.Medication.MedicationName,
                        EquipmentName = entity.Equipment.EquipmentName,
                        PreferenceNote = entity.PreferenceNote
                    };
            }
        }

        public bool UpdatePhysicianPreference(PhysicianPreferenceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PhysicianPreferences
                        .Single(e => e.PhysicianPreferenceID == model.PhysicianPreferenceId && e.OwnerID == _userId);

                entity.Physician.PhysicianFirstName = model.PhysicianFirstName;
                entity.Physician.PhysicianLastName = model.PhysicianLastName;
                entity.Physician.Specialty = model.Specialty;
                entity.Procedure.ProcedureName = model.ProcedureName;
                entity.Procedure.ProcedureNote = model.ProcedureNote;
                entity.Procedure.ProcedureRoute = model.ProcedureRoute;
                entity.Medication.MedicationName = model.MedicationName;
                entity.Equipment.EquipmentName = model.EquipmentName;
                entity.PreferenceNote = model.PreferenceNote;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePhysicianPreference(int physicianPreferenceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PhysicianPreferences
                        .Single(e => e.PhysicianPreferenceID == physicianPreferenceId && e.OwnerID == _userId);
                ctx.PhysicianPreferences.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
