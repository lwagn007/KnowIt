using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Services
{
    public class MashUpService
    {
        private Guid _ownerId;

        private PhysicianService physicianService;

        public MashUpService(Guid ownerId)
        {
            _ownerId = ownerId;
            physicianService = new PhysicianService(ownerId);
        }





    }
}
