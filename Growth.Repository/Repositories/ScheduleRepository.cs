using Dapper;
using Growth.DAL;
using Growth.Models;
using Growth.Models.Student;
using Growth.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Growth.Repository.Repositories
{
    public class ScheduleRepository: ISchedule
    {
        private readonly AppConnectionString appConnectionString;
        public ScheduleRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ScheduleDTODetail Add(ScheduleDTOAdd dTOAdd)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ScheduleDTODetail>("Schedule_Insert", dTOAdd, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DeleteResponse Delete(int scheduleId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DeleteResponse>("Schedule_Delete", new { ScheduleId= scheduleId}, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ScheduleDTODetail Edit(ScheduleDTOEdit dTOEdit)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ScheduleDTODetail>("Schedule_Edit", dTOEdit, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ScheduleDTODetail GetById(int scheduleId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ScheduleDTODetail>("Schedule_GetById", new {ScheduleId=scheduleId }, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<ScheduleDTOList> GetList()
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ScheduleDTOList>("Schedule_List", null, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }

        public List<ScheduleDTOStudent> GetListForStudent(string userName)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ScheduleDTOStudent>("Schedule_List_Student", new { UserName=userName }, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
