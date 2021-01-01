using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface ISubject
    {
        public List<SubjectDTOList> GetList();
        public SubjectDTODetail GetById(int id);
        public SubjectDTODetail Add(SubjectDTOAdd subjectDTOAdd);
        public SubjectDTODetail Edit(SubjectDTODetail subjectDTODetail);

        public DeleteResponse Delete(int subjectId);

        List<SubjectDTOLookup> Lookup();
    }
}
