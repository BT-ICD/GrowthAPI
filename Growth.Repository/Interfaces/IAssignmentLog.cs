using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IAssignmentLog
    {
        List<AssignmentLogDTODetail> GetList(int AssignmentAllocationId);
        AssignmentLogDTODetail GetById(int AssignmentLogId);

        AssignmentLogDTODetail Add(AssignmentLogDTOAdd assignmentLogDTOAdd);

    }
}
