using Growth.Models;
using Growth.Models.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IAssignmentAllocation
    {
        RecordsAffectedResponse Add(AssignmentAllocationDTOAdd allocationDTOAdd);
        List<AllocatedAssignment> AssignmentAllocationList(string userName, int? status=null);
        AllocatedAssignment GetById(int AssignmentAllocationId);

    }
}
