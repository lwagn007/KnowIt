using KnowIt.Models.Physician;
using KnowIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowIt.Contracts;

namespace KnowIt.Services
{
    public class PhysicianService : IPhysicianService
    {
        private readonly Guid _userId;

        public PhysicianService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePhysician(PhysicianCreate model)
        {
            var entity =
                new Physician()
                {
                    OwnerID = _userId,
                    PhysicianFirstName = model.PhysicianFirstName,
                    PhysicianLastName = model.PhysicianLastName,
                    Specialty = model.Specialty
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Physicians.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PhysicianListItem> GetPhysicians()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Physicians
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e => new PhysicianListItem
                        {
                            PhysicianId = e.PhysicianID,
                            PhysicianFirstName = e.PhysicianFirstName,
                            PhysicianLastName = e.PhysicianLastName,
                            Specialty = e.Specialty
                        }
                      );
                return query.ToArray();
            }
        }

        public PhysicianDetail GetPhysicianById(int physicianId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Physicians
                        .Single(e => e.PhysicianID == physicianId && e.OwnerID == _userId);
                return
                    new PhysicianDetail
                    {
                        PhysicianId = entity.PhysicianID,
                        PhysicianFirstName = entity.PhysicianFirstName,
                        PhysicianLastName = entity.PhysicianLastName,
                        Specialty = entity.Specialty
                    };
            }
        }

        public bool UpdatePhysician(PhysicianEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Physicians
                        .Single(e => e.PhysicianID == model.PhysicianId && e.OwnerID == _userId);

                entity.PhysicianFirstName = model.PhysicianFirstName;
                entity.PhysicianLastName = model.PhysicianLastName;
                entity.Specialty = model.Specialty;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePhysician(int physicianId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Physicians
                        .Single(e => e.PhysicianID == physicianId && e.OwnerID == _userId);
                ctx.Physicians.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
