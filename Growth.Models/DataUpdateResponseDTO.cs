using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// Common Response to deteremine Success/Failure of Request
    /// </summary>
    public class DataUpdateResponseDTO
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public int RecordCount { get; set; }
    }
}
