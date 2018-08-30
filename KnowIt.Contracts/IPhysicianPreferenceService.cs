using KnowIt.Models.PhysicianProcedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Contracts
{
    public interface IPhysicianPreferenceService
    {
        bool CreatePhysicianPreference(PhysicianPreferenceCreate model);
        IEnumerable<PhysicianPreferenceListItem> GetPhysicianPreferences();
        PhysicianPreferenceDetail GetPhysicianPreferenceById(int id);
        bool UpdatePhysicianPreference(PhysicianPreferenceEdit model);
        bool DeletePhysicianPreference(int physicianPreferenceId);
    }
}
