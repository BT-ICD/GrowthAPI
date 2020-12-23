using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To retain delete operation response. To identify number of records affected
    /// </summary>
    public class DeleteResponse
    {
        public int RowsAffected { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
