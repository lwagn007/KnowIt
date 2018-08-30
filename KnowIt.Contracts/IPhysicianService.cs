using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowIt.Models.Physician;

namespace KnowIt.Contracts
{
    public interface IPhysicianService
    {
        bool CreatePhysician(PhysicianCreate model);
        IEnumerable<PhysicianListItem> GetPhysicians();
        PhysicianDetail GetPhysicianById(int physicianId);
        bool UpdatePhysician(PhysicianEdit model);
        bool DeletePhysician(int physicianId);
    }
}
