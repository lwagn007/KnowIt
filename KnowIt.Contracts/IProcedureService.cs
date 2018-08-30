using KnowIt.Models.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Contracts
{
    public interface IProcedureService
    {
        bool CreateProcedure(ProcedureCreate model);
        IEnumerable<ProcedureListItem> GetProcedures();
        ProcedureDetail GetProcedureById(int procedureId);
        bool UpdateProcedure(ProcedureEdit model);
        bool DeleteProcedure(int procedureId);
    }
}
