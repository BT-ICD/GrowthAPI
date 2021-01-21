using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models.Student
{
    // to get schedule list for a particular studnet who logged in
    public class ScheduleDTOStudent
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
