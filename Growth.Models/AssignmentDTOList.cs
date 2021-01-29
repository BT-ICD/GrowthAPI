using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate list of assignments
    /// </summary>
    public class AssignmentDTOList
    {
        public int AssignmentId { get; set; }
        public string QueTitle { get; set; }
        public string QueHtml { get; set; }
        public string Notes{ get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
