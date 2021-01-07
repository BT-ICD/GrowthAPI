using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To submit attendance for list of students for a particular schedule
    /// </summary>
    public class AttendanceDTOSubmit
    {
        public int ScheduleId { get; set; }
        public List<AttendanceDTOAdd> students{ get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject($"Schedule id: {this.ScheduleId}, students count: {this.students.Count}");
        }
    }
}
