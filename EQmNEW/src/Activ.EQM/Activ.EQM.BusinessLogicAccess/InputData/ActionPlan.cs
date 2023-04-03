using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.EQM.BusinessLogicAccess.InputData
{
    public class ActionPlan
    { 
        public long? ActionPointId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }
        public byte? ActionPlanOrder { get; set; }
        public byte? ActionPlanPriority { get; set; }
        public byte? Statuts { get; set; }
        public DateTime? StartDateExpected { get; set; }
        public DateTime? EndDateExpected { get; set; }
        public DateTime? StartDateEffective { get; set; }
        public DateTime? EndDateEffective { get; set; }
        public string CreateBy { get; set; } 
    }
}
