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
    /// <summary>
    /// To manipulate content of student. Example Student List, Student Lookup, Add new student 
    /// </summary>
    public class StudentRepository:IStudent
    {
        private readonly AppConnectionString appConnectionString;
        public StudentRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public List<StudentDTOLookup> Lookup()
        {
            using(IDbConnection cnn= new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<StudentDTOLookup>("Student_Lookup", null,null,true,null,CommandType.StoredProcedure).ToList();
            }
        }
    }
}
