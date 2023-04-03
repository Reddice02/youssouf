using System;
using System.Collections.Generic;

namespace Activ.EQM.DataAcces.M
{
    public partial class EqmAudit
    {
        public EqmAudit()
        {
            EqmActionPoints = new HashSet<EqmActionPoint>();
        }

        public long AuditId { get; set; }
        public long ProcessId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateExpected { get; set; }
        public DateTime? EndDateExpected { get; set; }
        public DateTime? StartDateEffective { get; set; }
        public DateTime? EndDateEffective { get; set; }
        public string Report { get; set; }
        public string Reference { get; set; }
        public string CreateBy { get; set; }
        public DateTime Created { get; set; }

        public virtual EqmProcess Process { get; set; }
        public virtual ICollection<EqmActionPoint> EqmActionPoints { get; set; }
    }
}
