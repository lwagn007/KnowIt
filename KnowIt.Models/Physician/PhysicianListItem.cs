using KnowIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Physician
{
    public class PhysicianListItem
    {
        public int PhysicianId { get; set; }
        public string PhysicianFirstName { get; set; }
        public string PhysicianLastName { get; set; }
        public MedicalSpecialty Specialty { get; set; }
    }
}
