using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public enum MedicalSpecialty { Cardiology, Vascular, Neurology, Electrophysiology }
    public class Physician
    {
        public int PhysicianID { get; set; }
        public Guid OwnerID { get; set; }
        public string PhysicianFirstName { get; set; }
        public string PhysicianLastName { get; set; }
        public MedicalSpecialty Specialty { get; set; }
    }
}
