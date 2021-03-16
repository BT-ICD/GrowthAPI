using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IExam
    {
        List<ExamDTOList> GetList(int? SubjectId);
        DataUpdateResponseDTO Add(ExamDTOAdd examDTOAdd);
    }
}
