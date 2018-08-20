using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Equipment
{
    public class EquipmentCreate
    {

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage = "There are to many characters, please include less then 1000 characters.")]
        public string EquipmentName { get; set; }

        [Required]
        [MinLength(2,ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage ="There are to many characters, please include less then 1000 characters.")]
        public string EquipmentNote { get; set; }
    }
}
