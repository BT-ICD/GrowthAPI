using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IAssignmentDocument
    {
        List<AssignmentDocumentDTOList> GetList(int assignmentId);
        AssignmentDocumentDTODetail GetById(int assignmentDocumentId);

        AssignmentDocumentDTODetail Add(AssignmentDocumentDTOAdd dTOAdd);
        AssignmentDocumentDTODetail Edit(AssignmentDocumentDTOEdit dTOEdit);

        DeleteResponse Delete(int assignmentDocumentId);


    }
}
