using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    //public enum MedicationUse { Code, Pain, Sedation, SedationAdjunct }

    public class Medication
    {
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public string MedicationList { get; set; }
        //public string MedicationClass { get; set; }
        //public MedicationUse MedicationUse { get; set; }
    }
}
