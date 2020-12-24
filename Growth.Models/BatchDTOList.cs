using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate list of batches
    /// </summary>
    public class BatchDTOList
    {
        public int BatchId { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedToComplete { get; set; }
        public string Notes { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
