using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get list of students for which we have to review a particular assignment for a particular status
    /// </summary>
    public class AssignmentLogDTOReviewListStudent
    {
        public int AssignmentId { get; set; }
        public int Status { get; set; }
        public string StatusDesc { get; set; }
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public int AssignmentAllocationId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public int AssignmentLogId { get; set; }
        public string Comments { get; set; }
        public string StoredAsFilename { get; set; }
    public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }
}
