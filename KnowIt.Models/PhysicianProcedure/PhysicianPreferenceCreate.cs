using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowIt.Data;
using KnowIt.Models.Equipment;
using KnowIt.Models.Medication;
using KnowIt.Models.Procedure;

namespace KnowIt.Models.PhysicianProcedure
{
    public class PhysicianPreferenceCreate
    {
        public int PhysicianId { get; set; }
        public int ProcedureId { get; set; }
        public int MedicationId { get; set; }
        public int EquipmentId { get; set; }
        public string PreferenceNote { get; set; }

        public bool Assigned { get; set; }

        public virtual ICollection<MedicationListItem> Medications { get; set; }
        public virtual ICollection<EquipmentListItem> Equipments { get; set; }
        public virtual ICollection<ProcedureListItem> Procedures { get; set; }
        //public virtual ICollection<PhysicianPreference> PhysicianPreferences { get; set; }
    }
}
