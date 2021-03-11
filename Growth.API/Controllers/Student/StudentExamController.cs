using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.Models;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Student
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly ILogger<StudentExamController> logger;
        private readonly IExamStudent examStudent;
        public StudentExamController(IExamStudent examStudent, ILogger<StudentExamController> logger)
        {
            this.examStudent = examStudent;
            this.logger = logger;
        }
        [HttpPost]
        [Route("{ExamId:int}/{StudentId:int}")]
        public IActionResult StartExam(int ExamId, int StudentId)
        {
            logger.LogInformation($"Start exam for Exam Id {ExamId} and Student Id {StudentId}");
            var result = examStudent.CreateExam(ExamId, StudentId);
            logger.LogInformation($"Result for Start exam for Exam Id {ExamId} and Student Id {StudentId} is {result.ToString()}");
            return Ok(result);
        }
        [HttpGet]
        [Route("{ExamStudentId}/{ExamId:int}/{StudentId:int}")]
        public IActionResult GetExam(int ExamStudentId, int ExamId, int StudentId)
        {
            logger.LogInformation($"Get exam for Exam Studnet Id: {ExamStudentId} Exam Id {ExamId} and Student Id {StudentId}");
            var result = examStudent.GetQuestions(ExamStudentId, ExamId, StudentId);
            logger.LogInformation($"Retrieved exam for Exam Student Id {result.ExamStudentId}");
            return Ok(result);
        }
        /// <summary>
        /// To submit answer for a particular question for a particular exam by student
        /// </summary>
        /// <param name="answerDTOUpdate"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubmitAnswer(ExamAnswerDTOUpdate answerDTOUpdate)
        {
            logger.LogInformation($"Submit Answer for {answerDTOUpdate.ToString()}");
            var result = examStudent.SubmitAnswer(answerDTOUpdate);
            logger.LogInformation($"Submit Answer Result for {answerDTOUpdate.ToString()} is {result.ToString()}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{ExamStudentId}/{ExamId}/{StudentId}")]
        public IActionResult FinishExam(int ExamStudentId, int ExamId, int StudentId)
        {
            logger.LogInformation($"Finish Exam For ExamStudentId: {ExamStudentId} ExamId: {ExamId} and StudentId: {StudentId}");
            var result = examStudent.FinishExam(ExamStudentId, ExamId, StudentId);
            logger.LogInformation($"Finish Exam Result For ExamStudentId: {ExamStudentId} ExamId: {ExamId} and StudentId: {StudentId} is {result.ToString()}");
            return Ok(result);
        }
    }
}