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
        [HttpGet]
        [Route("{ExamId:int}/{StudentId:int}")]
        public IActionResult GetExam(int ExamId, int StudentId)
        {
            logger.LogInformation($"Get exam for Exam Id {ExamId} and Student Id {StudentId}");
            var result = examStudent.GetQuestions(ExamId, StudentId);
            logger.LogInformation("");
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
    }
}