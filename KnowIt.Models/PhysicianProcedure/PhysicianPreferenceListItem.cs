using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowIt.Data;

namespace KnowIt.Models.PhysicianProcedure
{
    public class PhysicianPreferenceListItem
    {
        public int PhysicianPreferenceId { get; set; }
        public int PhysicianId { get; set; }
        public int ProcedureId { get; set; }
        public int MedicationId { get; set; }
        public int EquipmentId { get; set; }
        public string PhysicianLastName { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureNote { get; set; }
        public string ProcedureRoute { get; set; }
        public string MedicationName { get; set; }
        public string EquipmentName { get; set; }
        public string PreferenceNote { get; set; }
        //public bool Assigned { get; set; }
        //public virtual ICollection<Data.Medication> Medications { get; set; }
        //public virtual IEnumerable<Data.Medication> Medication { get; set; }
        //public virtual ICollection<Data.Equipment> Equipments { get; set; }
        //public virtual ICollection<Data.Procedure> Procedures { get; set; }
        //public virtual ICollection<PhysicianPreference> PhysicianPreferences { get; set; }

    }
}
