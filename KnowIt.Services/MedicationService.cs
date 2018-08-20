using KnowIt.Data;
using KnowIt.Models.Medication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Services
{
    public class MedicationService
    {
        private readonly Guid _userId;

        public MedicationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMedication(MedicationCreate model)
        {
            var entity =
                new Medication()
                {
                    OwnerID = _userId,
                    MedicationName = model.MedicationName,
                    MedicationClass = model.MedicationClass,
                    MedicationUse = model.MedicationUse
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Medications.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MedicationListItem> GetMedications()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Medications
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e => new MedicationListItem
                        {
                            MedicationId = e.MedicationID,
                            MedicationName = e.MedicationName,
                            MedicationClass = e.MedicationClass,
                            MedicationUse = e.MedicationUse
                        }
                      );
                return query.ToArray();
            }
        }

        public MedicationDetail GetMedicationById(int medicationId)
        {
            using (var ctx = new ApplicationDbContext())
            { 
                var entity =
                    ctx
                        .Medications
                        .Single(e => e.MedicationID == medicationId && e.OwnerID == _userId);
                return
                    new MedicationDetail
                    {
                        MedicationId = entity.MedicationID,
                        MedicationName = entity.MedicationName,
                        MedicationClass = entity.MedicationClass,
                        MedicationUse = entity.MedicationUse
                    };
            }
        }

        public bool UpdateMedication(MedicationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Medications
                        .Single(e => e.MedicationID == model.MedicationId && e.OwnerID == _userId);

                entity.MedicationName = model.MedicationName;
                entity.MedicationClass = model.MedicationClass;
                entity.MedicationUse = model.MedicationUse;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMedication(int medicationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Medications
                        .Single(e => e.MedicationID == medicationId && e.OwnerID == _userId);
                ctx.Medications.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
