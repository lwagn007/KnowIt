using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.PhysicianProcedure
{
    public class PhysicianPreferenceDetail
    {
        public int PhysicianPreferenceId { get; set; }
        public int PhysicianId { get; set; }
        public int ProcedureId { get; set; }
        public int MedicationId { get; set; }
        public int EquipmentId { get; set; }
        public string PhysicianLastName { get; set; }
        public string PhysicianFirstName { get; set; }
        public string Specialty { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureNote { get; set; }
        public string ProcedureRoute { get; set; }
        public string MedicationName { get; set; }
        public string EquipmentName { get; set; }
    }
}
