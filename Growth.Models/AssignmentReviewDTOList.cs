using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate Review List for a particular assginement by faculty/Admin user
    /// </summary>
    public class AssignmentReviewDTOList
    {
        public AssignmentDTODetail assignmentDTODetail { get; set; }
        public List<AssignmentStatusSummary> StatusSummaries{ get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
