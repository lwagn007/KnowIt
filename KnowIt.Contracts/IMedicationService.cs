using KnowIt.Models.Medication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Contracts
{
    public interface IMedicationService
    {
        bool CreateMedication(MedicationCreate model);
        IEnumerable<MedicationListItem> GetMedications();
        MedicationDetail GetMedicationById(int medicationId);
        bool UpdateMedication(MedicationEdit model);
        bool DeleteMedication(int medicationId);
    }
}
