using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.PhysicianProcedure
{
    public class PhysicianPreferenceEdit
    {
        public int PhysicianPreferenceId { get; set; }
        public int PhysicianId { get; set; }
        public int ProcedureId { get; set; }
        public string PhysicianLastName { get; set; }
        public string PhysicianFirstName { get; set; }
        public string Specialty { get; set; }
        public string ProcedureName { get; set; }
    }
}
