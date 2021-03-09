using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Models
{
    /// <summary>
    /// To manipuate question and related options for a particular exam and for a particular student
    /// </summary>
    public class ExamStudentDTO
    {
        public int ExamStudentId { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        
    }
    public class ExamQuestionDTO
    {
        public int ExamQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string HtmlText { get; set; }
    }
    
        public class AnswerOptions
    {
        public int QuestionId { get; set; }
        public int AnswerOptionId { get; set; }
        public string HtmlText { get; set; }

    }
    public class QuestionAndOptions
    {
        public int ExamQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string HtmlText { get; set; }
        public List<AnswerOptions> Options{ get; set; }
    }
    public class ExamData
    {
        public int ExamStudentId { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }
        public List<QuestionAndOptions> Questions { get; set; }
    }
}
