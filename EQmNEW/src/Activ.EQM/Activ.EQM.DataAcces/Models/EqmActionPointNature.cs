using System;
using System.Collections.Generic;

namespace Activ.EQM.DataAcces.Models
{
    public partial class EqmActionPointNature
    {
        public EqmActionPointNature()
        {
            EqmActionPoints = new HashSet<EqmActionPoint>();
        }

        public int NatureId { get; set; }
        public string Title { get; set; }
        public string CreateBy { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<EqmActionPoint> EqmActionPoints { get; set; }
    }
}
