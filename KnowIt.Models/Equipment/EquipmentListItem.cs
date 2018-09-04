using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Equipment
{
    public class EquipmentListItem
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentNote { get; set; }

        public bool Assigned { get; set; }
        public virtual ICollection<EquipmentListItem> Equipments { get; set; }
    }
}
