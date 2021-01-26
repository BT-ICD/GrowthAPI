using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To edit details of particular assignment
    /// </summary>
    public class AssignmentDTOEdit:AssignmentDTOAdd
    {
        public int AssignmentId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
