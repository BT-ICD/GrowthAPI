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
    public class AssignmentDocumentRepository: IAssignmentDocument
    {
        private readonly AppConnectionString appConnectionString;
        public AssignmentDocumentRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public AssignmentDocumentDTODetail Add(AssignmentDocumentDTOAdd dTOAdd)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDocumentDTODetail>("AssignmentDocument_Insert", dTOAdd, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DeleteResponse Delete(int assignmentDocumentId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DeleteResponse>("AssignmentDocument_Delete", new { AssignmentDocumentId= assignmentDocumentId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public AssignmentDocumentDTODetail Edit(AssignmentDocumentDTOEdit dTOEdit)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDocumentDTODetail>("AssignmentDocument_Edit", dTOEdit, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public AssignmentDocumentDTODetail GetById(int assignmentDocumentId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDocumentDTODetail>("AssignmentDocument_GetById", new { AssignmentDocumentId = assignmentDocumentId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<AssignmentDocumentDTOList> GetList(int assignmentId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AssignmentDocumentDTOList>("AssignmentDocument_List", new { AssignmentId = assignmentId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
