using System;
using System.Collections.Generic;

namespace Activ.EQM.DataAcces.Models
{
    public partial class EqmProcess
    {
        public EqmProcess()
        {
            EqmAudits = new HashSet<EqmAudit>();
        }

        public long ProcessId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? TurnaroundTimes { get; set; }
        public string Participants { get; set; }
        public string ThirdPartyProcesses { get; set; }
        public string Manager { get; set; }
        public string CreateBy { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<EqmAudit> EqmAudits { get; set; }
    }
}
