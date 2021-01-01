using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To edit particular record of schedule
    /// </summary>
    public class ScheduleDTOEdit: ScheduleDTOAdd
    {
        public int ScheduleId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
