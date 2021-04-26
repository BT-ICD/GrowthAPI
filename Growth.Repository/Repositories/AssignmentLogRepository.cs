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

namespace Growth.Repository.Repositories
{
    class AssignmentLogRepository : IAssignmentLog
    {
        private readonly AppConnectionString appConnectionString;
        public AssignmentLogRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public AssignmentLogDTODetail Add(AssignmentLogDTOAdd assignmentLogDTOAdd)
        {
            using(IDbConnection cnn = new SqlConnection(this.appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentLogDTODetail>("AssignmentLog_Insert", assignmentLogDTOAdd, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public AssignmentLogDTODetail GetById(int AssignmentLogId)
        {
            using (IDbConnection cnn = new SqlConnection(this.appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentLogDTODetail>("AssignmentLog_GetById", new { AssignmentLogId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }

        }

        public List<AssignmentLogDTODetail> GetList(int AssignmentAllocationId)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentLogDTODetail>("AssignmentLog_List", new { AssignmentAllocationId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
        public List<AssignmentLogDTOReviewListStudent> ReviewListStudentByStatus(int AssignmentId, int Status, int? StudentId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentLogDTOReviewListStudent>("AssignmentLog_ReviewList_Student", new { AssignmentId, Status, StudentId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }

        

    }
}
