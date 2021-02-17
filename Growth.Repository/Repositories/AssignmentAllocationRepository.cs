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
    /// <summary>
    /// To manipulate content related to assignment allocation
    /// </summary>
    public class AssignmentAllocationRepository:IAssignmentAllocation
    {
        private readonly AppConnectionString appConnectionString;
        public AssignmentAllocationRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
     
        public RecordsAffectedResponse Add(AssignmentAllocationDTOAdd allocationDTOAdd)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))

            {
                if (allocationDTOAdd.StudentIds == "")
                {
                    allocationDTOAdd.StudentIds = null;
                }
                return cnn.Query<RecordsAffectedResponse>("AssignmentAllocation_Insert", allocationDTOAdd, null,false,null,CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<AllocatedAssignment> AssignmentAllocationList(string userName, int? status = null)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<AllocatedAssignment>("AssignmentAllocation_List_Student", new { UserName = userName, Status = status }, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
