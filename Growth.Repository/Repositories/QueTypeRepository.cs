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
    public class QueTypeRepository : IQueType
    {
        private readonly AppConnectionString appConnectionString;
        public QueTypeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public List<QueTypeDTOLookup> Lookup()
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<QueTypeDTOLookup>("QueType_Lookup", null,null,true,null,CommandType.StoredProcedure).ToList();
            }
        }
    }
}
