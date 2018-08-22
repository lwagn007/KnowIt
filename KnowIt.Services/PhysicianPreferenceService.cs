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
                    PhysicianLastName = model.PhysicianLastName,
                    PhysicianFirstName = model.PhysicianFirstName,
                    Specialty = model.Specialty,
                    ProcedureName = model.ProcedureName
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
                            PhysicianLastName = e.PhysicianLastName,
                            PhysicianFirstName = e.PhysicianFirstName,
                            ProcedureName = e.ProcedureName
                        }
                      );
                return query.ToArray();
            }
        }

        public PhysicianPreferenceDetail GetPhysicianPreferenceById(int physicianPreferenceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PhysicianPreferences
                        .Single(e => e.PhysicianPreferenceID == physicianPreferenceId && e.OwnerID == _userId);
                return
                    new PhysicianPreferenceDetail
                    {
                        PhysicianPreferenceId = entity.PhysicianPreferenceID,
                        PhysicianId = entity.PhysicianID,
                        ProcedureId = entity.ProcedureID,
                        PhysicianLastName = entity.PhysicianLastName,
                        PhysicianFirstName = entity.PhysicianFirstName,
                        Specialty = entity.Specialty,
                        ProcedureName = entity.ProcedureName
                    };
            }
        }

        //public bool UpdatePhysician(PhysicianPreferenceEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .PhysicianPreferences
        //                .Single(e => e.PhysicianPreferenceID == model.PhysicianPreferenceId && e.OwnerID == _userId);

        //        entity.PhysicianFirstName = model.PhysicianFirstName;
        //        entity.PhysicianLastName = model.PhysicianLastName;
        //        entity.Specialty = model.Specialty;
        //        entity.ProcedureName = model.ProcedureName;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

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
