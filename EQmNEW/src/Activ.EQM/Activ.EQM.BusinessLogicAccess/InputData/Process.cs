using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.EQM.BusinessLogicAccess.InputData
{
    public class Process
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? TurnaroundTimes { get; set; }
        public string Participants { get; set; }
        public string ThirdPartyProcesses { get; set; }
        public string Manager { get; set; }
        public string CreateBy { get; set; } 
    }
}
