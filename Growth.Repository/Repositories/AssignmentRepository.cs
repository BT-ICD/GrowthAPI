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
    public class AssignmentRepository: IAssignment
    {
        private readonly AppConnectionString appConnectionString;
        public AssignmentRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public AssignmentDTODetail Add(AssignmentDTOAdd dTOAdd)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDTODetail>("Assignment_Insert", dTOAdd, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DeleteResponse Delete(int assignmentId)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DeleteResponse>("Assignment_Delete", new { AssignmentId = assignmentId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public AssignmentDTODetail Edit(AssignmentDTOEdit dTOEdit)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDTODetail>("Assignment_Edit", dTOEdit, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public AssignmentDTODetail GetById(int assignmentId)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDTODetail>("Assignment_GetById", new { AssignmentId = assignmentId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<AssignmentDTOList> GetList()
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDTOList>("Assignment_List", null, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
