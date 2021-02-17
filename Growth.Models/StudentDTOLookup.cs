using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get lookup values for student. Student list with their respective batch details
    /// </summary>
    public class StudentDTOLookup
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int BatchId { get; set; }
        public string BatchCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
