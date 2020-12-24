using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add new Batch Detail
    /// </summary>
    class BatchDTOAdd: BatchDTOEdit
    {
        public int BatchId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
