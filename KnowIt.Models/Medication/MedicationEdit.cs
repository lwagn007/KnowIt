﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Medication
{
    public class MedicationEdit
    {
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string MedicationClass { get; set; }
        public string MedicationUse { get; set; }
    }
}
