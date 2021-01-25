using Dapper;
using Growth.DAL;
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
    public class DashboardRepository : IDashboard
    {
        private readonly AppConnectionString appConnectionString;
        public DashboardRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        DashboardDTOStudent IDashboard.DashBoardStudent(string userName)
        {
            DashboardDTOStudent dashboardDTOStudent = new DashboardDTOStudent();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result =  cnn.Query<DashboardSessionSummary>("Dashboard_Student", new { UserName = userName }, null, true, null, CommandType.StoredProcedure).ToList();
                dashboardDTOStudent.SessionSummary = result;
            }
            return dashboardDTOStudent;
        }
    }
}
