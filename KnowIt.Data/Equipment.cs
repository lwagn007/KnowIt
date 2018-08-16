using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Data
{
    public class Equipment
    {
        [Key]
        public int EquipmentID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }
        
        //[Required]
        //public string EquipmentName { get; set; }

        [Required]
        public string EquipmentNote { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
