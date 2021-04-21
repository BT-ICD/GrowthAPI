using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get summary of assignment by status.
    /// </summary>
    public class AssignmentStatusSummary
    {
        public int Status { get; set; }
        public string StatusDesc { get; set; }
        public int NumberofStudents { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
