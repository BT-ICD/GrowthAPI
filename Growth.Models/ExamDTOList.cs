using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate list of exams to admin user
    /// </summary>
    public class ExamDTOList
    {
        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int TotalQuestions { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
