using Growth.Models.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IDashboard
    {
        DashboardDTOStudent DashBoardStudent(string userName);
    }
}
