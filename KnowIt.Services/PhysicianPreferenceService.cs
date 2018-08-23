using KnowIt.Data;
using KnowIt.Models.PhysicianProcedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Services
{
    public class PhysicianPreferenceService
    {
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
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PhysicianPreferences.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PhysicianPreferenceListItem> GetPhysicianPreferences()
        {
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
                            PhysicianId = e.PhysicianID,
                            ProcedureId = e.ProcedureID,
                            PhysicianLastName = e.Physician.PhysicianLastName,
                            ProcedureName = e.Procedure.ProcedureName,
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
                        PhysicianId = entity.PhysicianID,
                        ProcedureId = entity.ProcedureID,
                        PhysicianLastName = entity.Physician.PhysicianLastName,
                        PhysicianFirstName = entity.Physician.PhysicianFirstName,
                        Specialty = entity.Physician.Specialty,
                        ProcedureName = entity.Procedure.ProcedureName,
                        ProcedureNote = entity.Procedure.ProcedureNote
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
