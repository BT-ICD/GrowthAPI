using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add new assignment log
    /// </summary>
    public class AssignmentLogDTOAdd
    {
        public int AssignmentAllocationId { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
        public string ActualFileName { get; set; }
        public string UserName { get; set; }
    }
   
}
