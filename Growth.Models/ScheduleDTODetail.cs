using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate details of particular schedule (single record)
    /// </summary>
    public class ScheduleDTODetail
    {
        public int ScheduleId { get; set; }
        public int BatchId { get; set; }
        public string Batch { get; set; }
        public int SubjectId { get; set; }
        public string Subject { get; set; }
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
