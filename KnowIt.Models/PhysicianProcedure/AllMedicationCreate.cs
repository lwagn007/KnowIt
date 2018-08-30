using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.PhysicianProcedure
{
    public class AllMedicationCreate
    {
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public bool Assigned { get; set; }
        public virtual ICollection<AllMedicationCreate> Medications { get; set; }
    }
}
