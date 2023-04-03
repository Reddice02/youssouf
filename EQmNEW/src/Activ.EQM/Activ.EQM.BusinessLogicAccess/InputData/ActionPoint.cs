using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.EQM.BusinessLogicAccess.InputData
{
    public class ActionPoint
    {
         
        public int? NatureId { get; set; }
        public long? AuditId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? ActionPointLevel { get; set; }
        public byte? ActionPointPriority { get; set; }
        public string ThirdPartyProcessStep { get; set; }
        public string CreateBy { get; set; }
         
    }
}
