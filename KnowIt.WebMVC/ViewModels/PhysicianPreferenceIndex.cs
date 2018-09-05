using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnowIt.Models;

namespace KnowIt.WebMVC.ViewModels
{
    public class PhysicianPreferenceIndex
    {
        public IEnumerable<KnowIt.Models.Physician.PhysicianListItem> Physicians { get; set; }
        public IEnumerable<KnowIt.Models.Medication.MedicationListItem> Medications { get; set; }
        public IEnumerable<KnowIt.Models.Equipment.EquipmentListItem> Equipments { get; set; }
        public IEnumerable<KnowIt.Models.Procedure.ProcedureListItem> Procedures { get; set; }
    }
}