using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IQuestionBank
    {
        RecordsAffectedResponse Add(QuestionDTOAdd dTOAdd);
        List<QuestionDTOList> GetList(int subjectId, int? chapterId);
    }
}
