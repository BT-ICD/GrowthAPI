using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To add (insert) new Schedule 
    /// </summary>
    public class ScheduleDTOAdd
    {
        public int BatchId { get; set; }
        public int SubjectId { get; set; }
        public DateTime LectureFrom { get; set; }
        public DateTime LectureTo { get; set; }
        public string SessionContent { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
