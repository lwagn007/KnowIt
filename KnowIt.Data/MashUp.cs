using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public class MashUp
    {
        [Key]
        public int MashUpID { get; set; }
        public Guid OwnerID { get; set; }
        public int PhysicianID { get; set; }
        public int ProcedureID { get; set; }
        public int EquipmentID { get; set; }
        public int MedicationID { get; set; }
        public string MashUpNote { get; set; }

        public virtual IEnumerable<MashUp> MashUps { get; set; }
        public virtual ICollection<Physician> Physicians { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Medication> Medications { get; set; }
    }
}
