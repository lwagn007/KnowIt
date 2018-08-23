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
        public int PhysicianId { get; set; }
        public int ProcedureId { get; set; }
    }
}
