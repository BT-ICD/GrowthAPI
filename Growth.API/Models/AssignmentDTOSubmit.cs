using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Growth.API.Models
{
    /// <summary>
    /// Allow student to submit assignment details with notes
    /// </summary>
    public class AssignmentDTOSubmit
    {
        public int AssignmentAllocationId { get; set; }
        public string Comments { get; set; }
        public IFormFile file { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
