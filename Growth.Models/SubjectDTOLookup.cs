using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get key and value for subject - to fill dropdown of subject list
    /// </summary>
    public class SubjectDTOLookup
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
