using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Procedure
{
    public class ProcedureCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 or more characters.")]
        [MaxLength(150, ErrorMessage = "There are to many characters, max of 150 characters allowed.")]
        public string ProcedureName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 or more characters.")]
        [MaxLength(150, ErrorMessage = "There are to many characters, max of 150 characters allowed.")]
        public string ProcedureFocus { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 or more characters.")]
        [MaxLength(150, ErrorMessage = "There are to many characters, max of 150 characters allowed.")]
        public string ProcedureRoute { get; set; }
    }
}
