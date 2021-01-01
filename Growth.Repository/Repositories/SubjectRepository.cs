using Growth.Models;
using Growth.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using Growth.DAL;
using System.Data;
using System.Linq;

namespace Growth.Repository.Repositories
{
    /// <summary>
    /// To manipulate content of Subject
    /// </summary>
    public class SubjectRepository : ISubject
    {
        private readonly AppConnectionString appConnectionString;
        public SubjectRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public List<SubjectDTOList> GetList()
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<SubjectDTOList>("Subject_List", null, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }

        public SubjectDTODetail GetById(int id)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<SubjectDTODetail>("Subject_GetById", new { SubjectId = id }, null, false, null, CommandType.StoredProcedure).ToList().FirstOrDefault();
            }
        }

        public SubjectDTODetail Add(SubjectDTOAdd subjectDTOAdd)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<SubjectDTODetail>("Subject_Insert", new { subjectDTOAdd.Name, subjectDTOAdd.Notes, subjectDTOAdd.Prerequisite }, null, false, null, CommandType.StoredProcedure).ToList().FirstOrDefault();
            }
        }

        public SubjectDTODetail Edit(SubjectDTODetail subjectDTODetail)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<SubjectDTODetail>("Subject_Edit", new { subjectDTODetail.SubjectId, subjectDTODetail.Name, subjectDTODetail.Notes, subjectDTODetail.Prerequisite }, null, false, null, CommandType.StoredProcedure).ToList().FirstOrDefault();
            }
        }

        public DeleteResponse Delete(int subjectId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DeleteResponse>("Subject_Delete", new { SubjectId = subjectId }, null, false, null, CommandType.StoredProcedure).ToList().FirstOrDefault();
            }
        }

        public List<SubjectDTOLookup> Lookup()
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<SubjectDTOLookup>("Subject_Lookup", null, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
