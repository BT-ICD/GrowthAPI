using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IExamStudent
    {
        ExamData GetQuestions(int ExamId, int StudentId);
        ExamAnswerDTOUpdate SubmitAnswer(ExamAnswerDTOUpdate answerDTOUpdate);
    }
}
