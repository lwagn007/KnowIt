using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public class PhysicianPreference
    {
        public int PhysicianPreferenceID { get; set; }
        public Guid OwnerID { get; set; }
        public int PhysicianID { get; set; }
        public int ProcedureID { get; set; }

        public virtual Physician Physician { get; set; }
        public virtual Procedure Procedure { get; set; }
    }
}
