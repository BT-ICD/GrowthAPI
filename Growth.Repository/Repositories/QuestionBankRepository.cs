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
    public class QuestionBankRepository:IQuestionBank
    {
        private readonly AppConnectionString appConnectionString;
        public QuestionBankRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public RecordsAffectedResponse Add(QuestionDTOAdd dTOAdd)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                //to create XML string from answers collection
                string AnswerXML = UtilityLibrary.XmlUtil.GetXMLString(dTOAdd.AnswerOptions);
                return cnn.Query<RecordsAffectedResponse>("Question_Insert", new { dTOAdd.Title, dTOAdd.HtmlText, dTOAdd.PlainText, dTOAdd.ChapterId, dTOAdd.QueTypeId, dTOAdd.Notes, AnswerXML }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        
        public List<QuestionDTOList> GetList(int subjectId, int? chapterId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<QuestionDTOList>("Question_List", new { SubjectId= subjectId ,ChapterId = chapterId }, null, false, null, CommandType.StoredProcedure).ToList();
            }
        }
    }
}
