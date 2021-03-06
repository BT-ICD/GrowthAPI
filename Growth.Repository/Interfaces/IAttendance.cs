﻿using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IAttendance
    {
        List<AttendanceDTOList> AttendanceList(int scheduleId);
        RecordsAffectedResponse Submit(AttendanceDTOSubmit dTOSubmit);
    }
}
