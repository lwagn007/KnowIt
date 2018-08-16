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

        public bool CreateEquipment (EquipmentCreate model)
        {
            var entity =
                new Equipment()
                {
                    OwnerID = _userId,
                    EquipmentNote = model.EquipmentNote,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //public IEnumerable<EquipmentListItem> GetEquipment()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .Equipments
        //                .Where(e => e.OwnerID == _userId)
        //                .Select(
        //                e => new EquipmentListItem
        //                {
        //                    EquipmentID = e.EquipmentID,
        //                    EquipmentNote = e.EquipmentNote,
        //                    CreatedUtc = e.CreatedUtc
        //                }
        //             );
        //        return query.ToArray();
        //    }
        //}

        //public bool UpdateEquipment(EquipmentEdit model)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Equipments
        //                .Single(e => e.EquipmentID == model.EquipmentID && e.OwnerID == _userId);

        //        entity.EquipmentNote = model.EquipmentNote;
        //        entity.ModifiedUtc = DateTimeOffset.Now;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
        
        //public bool DeleteEquipment(int equipmentId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Equipments
        //                .Single(e => e.EquipmentID == equipmentId && e.OwnerID == _userId);
        //        ctx.Equipments.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
