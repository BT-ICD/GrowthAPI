using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To access details of particular batch
    /// </summary>
    public class BatchDTODetail
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
