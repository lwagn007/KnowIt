using System;
using KnowIt.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Physician
{
    public class PhysicianCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(150, ErrorMessage ="There are to many characters. Only 150 characters are allowed.")]
        public string PhysicianFirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(150, ErrorMessage = "There are to many characters. Only 150 characters are allowed.")]
        public string PhysicianLastName { get; set; }

        [Required]
        public string Specialty { get; set; }
    }
}
