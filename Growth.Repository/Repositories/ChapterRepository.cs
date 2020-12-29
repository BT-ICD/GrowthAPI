using Growth.DAL;
using Growth.Models;
using Growth.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Growth.Repository.Repositories
{
    /// <summary>
    /// To manipulate chapter content from Databasae
    /// </summary>
    public class ChapterRepository: IChapter
    {
        private readonly AppConnectionString appConnectionString;
        public ChapterRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public ChapterDTODetail Add(ChapterDTOAdd chapterDTOAdd)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ChapterDTODetail>("Chapter_Insert", new { chapterDTOAdd.ChapterSrNo, chapterDTOAdd.Name, chapterDTOAdd.SubjectId, chapterDTOAdd.Notes }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DeleteResponse Delete(int id)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DeleteResponse>("Chapter_Delete", new { ChapterId=id }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ChapterDTODetail Edit(ChapterDTOEdit chapterDTOEdit)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ChapterDTODetail>("Chapter_Edit", new { chapterDTOEdit.ChapterId, chapterDTOEdit.ChapterSrNo, chapterDTOEdit.Name, chapterDTOEdit.SubjectId, chapterDTOEdit.Notes }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ChapterDTODetail GetById(int id)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ChapterDTODetail>("Chapter_GetById", new { ChapterId = id }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<ChapterDTOList> GetList(int SubjectId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ChapterDTOList>("Chapter_List", new { SubjectId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
