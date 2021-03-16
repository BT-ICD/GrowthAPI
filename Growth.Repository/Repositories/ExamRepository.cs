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
    public class ExamRepository:IExam
    {
        private readonly AppConnectionString appConnectionString;
        public ExamRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public DataUpdateResponseDTO Add(ExamDTOAdd examDTOAdd)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("Exam_Insert", examDTOAdd, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<ExamDTOList> GetList(int? SubjectId)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ExamDTOList>("Exam_List", new { SubjectId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
