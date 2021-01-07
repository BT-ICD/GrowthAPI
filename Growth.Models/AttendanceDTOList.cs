using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To get list of students to fill/update attendance for particular schedule
    /// </summary>
    public class AttendanceDTOList
    {
        public int ScheduleId { get; set; }
        public int StudentId { get; set; }
        
        //Name of Student
        public string Name { get; set; }

        //Attendance status such as True/False - Attended/Not Attended
        public bool Status { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
