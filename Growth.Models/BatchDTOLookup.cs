using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get key and value for Batch - to fill dropdown of subject list
    /// </summary>
    public class BatchDTOLookup
    {
        public int BatchId { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
