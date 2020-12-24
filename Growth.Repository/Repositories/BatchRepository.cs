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
    /// To manage - manipulate content of Batch from related data store
    /// </summary>
    public class BatchRepository: IBatch
    {
        private readonly AppConnectionString appConnectionString;
        public BatchRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public BatchDTODetail GetById(int batchId)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<BatchDTODetail>("Batch_GetById", new { BatchId = batchId },null,false,null,CommandType.StoredProcedure ).FirstOrDefault();
            }
        }

        public List<BatchDTOList> GetList()
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<BatchDTOList>("Batch_List", null, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
