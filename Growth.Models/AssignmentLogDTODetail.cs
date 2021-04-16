using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get details related list of log for a paraticualr assignment allocation
    /// </summary>
    public class AssignmentLogDTODetail
    {
        public int AssignmentLogId { get; set; }
        public int AssignmentAllocationId { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string StoredAsFilename { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
