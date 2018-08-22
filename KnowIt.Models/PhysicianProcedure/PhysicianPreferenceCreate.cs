using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowIt.Data;

namespace KnowIt.Models.PhysicianProcedure
{
    public class PhysicianPreferenceCreate
    {
        public string PhysicianLastName { get; set; }
        public string PhysicianFirstName { get; set; }
        public string Specialty { get; set; }
        public string ProcedureName { get; set; }
    }
}
