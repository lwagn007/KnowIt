using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public class PhysicianPreference
    {
        public int PhysicianPreferenceID { get; set; }
        public Guid OwnerID { get; set; }
        public int PhysicianID { get; set; }
        public int ProcedureID { get; set; }
        public int MedicationID { get; set; }
        public int EquipmentID { get; set; }
        public string PreferenceNote { get; set; }
        public virtual Physician Physician { get; set; }
        public virtual Procedure Procedure { get; set; }
        public virtual Medication Medication { get; set; }
        public virtual Equipment Equipment { get; set; }

        //TODO 2 Turn On to pull multiple medications
        public virtual ICollection<PhysicianPreference> PhysicianPreferences { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
