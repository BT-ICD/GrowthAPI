using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface ISchedule
    {
        List<ScheduleDTOList> GetList();
        ScheduleDTODetail GetById(int scheduleId);

        ScheduleDTODetail Add(ScheduleDTOAdd dTOAdd);
        ScheduleDTODetail Edit(ScheduleDTOEdit dTOEdit);

        DeleteResponse Delete(int scheduleId);

    }
}
