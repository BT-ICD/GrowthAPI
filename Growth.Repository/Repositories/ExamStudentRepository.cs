﻿using Dapper;
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
    public class ExamStudentRepository:IExamStudent
    {
        private readonly AppConnectionString appConnectionString;
        public ExamStudentRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        /// <summary>
        /// To create new exam into ExamStudent Return ExamStudentId
        /// </summary>
        /// <param name="ExamId"></param>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public DataUpdateResponseDTO CreateExam(int ExamId, int StudentId)
        {
            using(IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("ExamCreateForStudent", new { ExamId, StudentId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public DataUpdateResponseDTO FinishExam(int ExamStudentId, int ExamId, int StudentId)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<DataUpdateResponseDTO>("ExamStudentFinish", new { ExamStudentId, ExamId, StudentId }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ExamData GetQuestions(int ExamStudentId, int ExamId, int StudentId)
        {
            ExamData examData = new ExamData();
            ExamStudentDTO examStudentDTO=null;
            List<ExamQuestionDTO> examQuestionDTO=null;
            List<AnswerOptions> resultOptions = null;
           

            //Fetch Exam Based on Exam Student Id

            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("ExamQuestionsForStudent", new { ExamStudentId,ExamId, StudentId },null,null,CommandType.StoredProcedure);
                //Read First ResultSet
                if (!result.IsConsumed)
                {
                    examStudentDTO = result.Read<ExamStudentDTO>().FirstOrDefault();
                }
                if (!result.IsConsumed)
                {
                    examQuestionDTO = result.Read<ExamQuestionDTO>().ToList();
                }
                if (!result.IsConsumed)
                {
                    resultOptions= result.Read<AnswerOptions>().ToList();
                }
            }
            examData.ExamStudentId = examStudentDTO.ExamStudentId;
            examData.ExamId = examStudentDTO.ExamId;
            examData.StudentId = examStudentDTO.StudentId;
            examData.Questions = new List<QuestionAndOptions>();
            foreach (var question in examQuestionDTO)
            {
                examData.Questions.Add(new QuestionAndOptions()
                {
                    ExamQuestionId = question.ExamQuestionId,
                    QuestionId = question.QuestionId,
                    HtmlText = question.HtmlText,
                    Title = question.Title,
                    AnswerOptionId = question.AnswerOptionId,
                    QuestionStatus= question.QuestionStatus,
                    Options = resultOptions.Where(C => C.QuestionId == question.QuestionId).ToList()

                });
            }
            return examData;
        }
        /// <summary>
        /// To update submitted answer by a particular student for a particular question of an exam
        /// </summary>
        /// <param name="answerDTOUpdate"></param>
        /// <returns></returns>
        public ExamAnswerDTOUpdate SubmitAnswer(ExamAnswerDTOUpdate answerDTOUpdate)
        {
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<ExamAnswerDTOUpdate>("ExamAnswerSubmitStudent", answerDTOUpdate, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
   
    
}
