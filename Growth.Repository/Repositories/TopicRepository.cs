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
    /// To manipulate with data store (Database) for Topic
    /// </summary>
    public class TopicRepository:ITopic
    {
        private readonly AppConnectionString appConnectionString;
        public TopicRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public TopicDTOEdit Add(TopicDTOAdd topicDTOAdd)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<TopicDTOEdit>("Topic_Insert", new { topicDTOAdd.TopicSrNo, topicDTOAdd.Name, topicDTOAdd.ChapterId, topicDTOAdd.Notes }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DeleteResponse Delete(int topicId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DeleteResponse>("Topic_Delete", new {TopicId = topicId}, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public TopicDTOEdit Edit(TopicDTOEdit topicDTOEdit)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<TopicDTOEdit>("Topic_Edit", new { topicDTOEdit.TopicId, topicDTOEdit.TopicSrNo, topicDTOEdit.Name, topicDTOEdit.ChapterId, topicDTOEdit.Notes }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public TopicDTOEdit GetById(int topicId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<TopicDTOEdit>("Topic_GetById", new { TopicId = topicId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<TopicDTOList> GetList(int chapterId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<TopicDTOList>("Topic_List", new { ChapterId = chapterId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
