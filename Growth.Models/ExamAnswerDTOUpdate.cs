using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// Allow student to submit/update answer for a particular question of an exam
    /// </summary>
    public class ExamAnswerDTOUpdate
    {
        public int ExamStudentId { get; set; }
        public int ExamQuestionId { get; set; }
        public int AnswerOptionId { get; set; }
        //QuestionStatus--> 1 - Submitted 2-Skipped
        public int QuestionStatus { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
