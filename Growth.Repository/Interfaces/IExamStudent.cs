using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IExamStudent
    {
        ExamData GetQuestions(int ExamStudentId, int ExamId, int StudentId);
        ExamAnswerDTOUpdate SubmitAnswer(ExamAnswerDTOUpdate answerDTOUpdate);

        DataUpdateResponseDTO CreateExam(int ExamId, int StudentId);
        DataUpdateResponseDTO FinishExam(int ExamStudentId, int ExamId, int StudentId);

    }
}
