using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public class Procedure
    {
        public int ProcedureID { get; set; }
        public Guid OwnerID { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureNote { get; set; }
        public string ProcedureRoute { get; set; }
    }
}
