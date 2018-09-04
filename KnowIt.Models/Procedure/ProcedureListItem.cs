﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Models.Procedure
{
    public class ProcedureListItem
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureNote { get; set; }
        public string ProcedureRoute { get; set; }
        public bool Assigned { get; set; }

        public virtual ICollection<ProcedureListItem> Procedures { get; set; }
    }
}
