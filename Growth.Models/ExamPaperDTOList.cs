using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipulate list of question with respective answer options
    /// </summary>
    public class ExamPaperDTOList
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string HtmlText { get; set; }
        public List<QueAnswerOptions> Options { get; set; }

    }
    public class QueAnswerOptions
    {
        public int AnswerOptionId { get; set; }
        public string HtmlText { get; set; }
    }
}
