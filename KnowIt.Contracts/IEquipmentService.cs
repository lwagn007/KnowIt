using KnowIt.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Contracts
{
    public interface IEquipmentService
    {
        bool CreateEquipment(EquipmentCreate model);
        IEnumerable<EquipmentListItem> GetEquipments();
        EquipmentDetail GetEquipmentById(int equipmentId);
        bool UpdateEquipment(EquipmentEdit model);
        bool DeleteEquipment(int equipmentId);
    }
}
