using Dapper;
using Growth.DAL;
using Growth.Models;
using Growth.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UtilityLibrary;

namespace Growth.Repository.Repositories
{
    public class AttendanceRepository: IAttendance
    {
        private readonly AppConnectionString appConnectionString;
        public AttendanceRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public List<AttendanceDTOList> AttendanceList(int scheduleId)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AttendanceDTOList>("Attendance_List", new { ScheduleId = scheduleId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
        public RecordsAffectedResponse Submit(AttendanceDTOSubmit dTOSubmit)
        {
            string attendanceXML = XmlUtil.GetXMLString(dTOSubmit.students);
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<RecordsAffectedResponse>("Attendance_Insert", new { ScheduleId = dTOSubmit.ScheduleId, AttendanceXML = attendanceXML }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
