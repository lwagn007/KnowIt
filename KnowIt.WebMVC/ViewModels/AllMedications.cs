using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowIt.WebMVC.ViewModels
{
    public class AllMedications
    {
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public bool Assigned { get; set; }
        public virtual ICollection<AllMedications> Medications { get; set; }
    }
}