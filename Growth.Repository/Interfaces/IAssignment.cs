using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IAssignment
    {
        List<AssignmentDTOList> GetList();
        AssignmentDTODetail GetById(int assignmentId);

        AssignmentDTODetail Add(AssignmentDTOAdd dTOAdd);

        AssignmentDTODetail Edit(AssignmentDTOEdit dTOEdit);

        DeleteResponse Delete(int assignmentId);
    }
}
