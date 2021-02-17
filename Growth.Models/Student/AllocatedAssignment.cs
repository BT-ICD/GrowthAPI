using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models.Student
{
    /// <summary>
    /// To get list of allocated assignments to a particular student
    /// </summary>
    public class AllocatedAssignment
    {
        public int AssignmentId { get; set; }
        public string QueTitle { get; set; }
        public string QueHtml { get; set; }
        public int Status { get; set; }
        public DateTime AllocatedOn { get; set; }
            

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
