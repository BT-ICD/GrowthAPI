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
        public List<SubjectListDTO> GetList()
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<SubjectListDTO>("Subject_List", null, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
