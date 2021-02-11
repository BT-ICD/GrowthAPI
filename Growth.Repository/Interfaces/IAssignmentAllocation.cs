using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IAssignmentAllocation
    {
        RecordsAffectedResponse Add(AssignmentAllocationDTOAdd allocationDTOAdd);
    }
}
