using KnowIt.Models.Equipment;
using KnowIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Services
{
    public class EquipmentService
    {
        private readonly Guid _userId;

        public EquipmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEquipment(EquipmentCreate model)
        {
            var entity =
                new Equipment()
                {
                    OwnerID = _userId,
                    EquipmentName = model.EquipmentName,
                    EquipmentNote = model.EquipmentNote
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EquipmentListItem> GetEquipments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Equipments
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e => new EquipmentListItem
                        {
                            EquipmentId = e.EquipmentID,
                            EquipmentName = e.EquipmentName,
                            EquipmentNote = e.EquipmentNote,
                        }
                      );
                return query.ToArray();
            }
        }

        public EquipmentDetail GetEquipmentById(int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Equipments
                        .Single(e => e.EquipmentID == equipmentId && e.OwnerID == _userId);
                return
                    new EquipmentDetail
                    {
                        EquipmentId = entity.EquipmentID,
                        EquipmentName = entity.EquipmentName,
                        EquipmentNote = entity.EquipmentNote,
                    };
            }
        }

        public bool UpdateEquipment(EquipmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Equipments
                        .Single(e => e.EquipmentID == model.EquipmentId && e.OwnerID == _userId);

                    entity.EquipmentName = model.EquipmentName;
                    entity.EquipmentNote = model.EquipmentNote;
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEquipment(int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Equipments
                        .Single(e => e.EquipmentID == equipmentId && e.OwnerID == _userId);
                ctx.Equipments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
