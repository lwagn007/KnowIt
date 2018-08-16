using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public int PhysicianID { get; set; }
        public int EquipmentID { get; set; }
        public int MedicationID { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureFocus { get; set; }
        public string ProcedureRoute { get; set; }

        public virtual ICollection<Physician> Physicians { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
    }
}
