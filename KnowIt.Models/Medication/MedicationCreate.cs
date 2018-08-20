using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Medication
{
    public class MedicationCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 or more characters.")]
        [MaxLength(150, ErrorMessage = "There are to many characters, max of 150 characters allowed.")]
        public string MedicationName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 or more characters.")]
        [MaxLength(150, ErrorMessage = "There are to many characters, max of 150 characters allowed.")]
        public string MedicationClass { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 or more characters.")]
        [MaxLength(150, ErrorMessage = "There are to many characters, max of 150 characters allowed.")]
        public string MedicationUse { get; set; }
    }
}
