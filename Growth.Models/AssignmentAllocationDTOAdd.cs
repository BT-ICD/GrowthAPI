using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To submit assignment allocation details. To allocate one assignment to all the students of a batch or some of the students of a batch
    /// </summary>
    public class AssignmentAllocationDTOAdd
    {
        [Range(minimum:1,maximum:Int32.MaxValue,ErrorMessage ="Batch Id must be positive integer")]
        public int BatchId { get; set; }
        [Range(minimum: 1, maximum: Int32.MaxValue, ErrorMessage = "Assignment Id must be positive integer")]

        public int AssignmentId { get; set; }
        public string? StudentIds { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
