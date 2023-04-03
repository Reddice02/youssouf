using System;
using System.Collections.Generic;

namespace Activ.EQM.DataAcces.Models
{
    public partial class EqmActionPoint
    {
        public EqmActionPoint()
        {
            EqmActionPlans = new HashSet<EqmActionPlan>();
        }

        public long ActionPointId { get; set; }
        public int? NatureId { get; set; }
        public long? AuditId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? ActionPointLevel { get; set; }
        public byte? ActionPointPriority { get; set; }
        public string ThirdPartyProcessStep { get; set; }
        public string CreateBy { get; set; }
        public DateTime Created { get; set; }

        public virtual EqmAudit Audit { get; set; }
        public virtual EqmActionPointNature Nature { get; set; }
        public virtual ICollection<EqmActionPlan> EqmActionPlans { get; set; }
    }
}
