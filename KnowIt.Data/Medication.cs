using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public class Medication
    {
        public int MedicationID { get; set; }
        public Guid OwnerID { get; set; }
        public string MedicationName { get; set; }
        public string MedicationClass { get; set; }
        public string MedicationUse { get; set; }
        public bool Assigned { get; set; }
    }
}
