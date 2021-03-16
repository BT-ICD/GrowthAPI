using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To create new exam for a particular subject
    /// </summary>
    public class ExamDTOAdd
    {
        public int SubjectId { get; set; }
        public int TotalQuestions { get; set; }
        public string Notes { get; set; }
        public string QuestionIds { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
