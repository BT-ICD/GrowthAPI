using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.Models;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Trans
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamAdminController : ControllerBase
    {
        private readonly IExam exam;
        private readonly ILogger<ExamAdminController> logger;
        public ExamAdminController(IExam exam, ILogger<ExamAdminController> logger)
        {
            this.exam = exam;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of exam. Optional argument subject id, to get list of exams for a particular subject
        /// </summary>
        /// <param name="SubjectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{SubjectId:int=-1}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetList(int? SubjectId=-1)
        {
            List<ExamDTOList> list;
            logger.LogInformation($"Exam List for Subject id {SubjectId}");
            if (SubjectId == -1)
            {
                list = exam.GetList(null);
            }
            else
            {
                list= exam.GetList(SubjectId);
            }
                
            logger.LogInformation($"Number of exams for Subject id {SubjectId} is {list.Count}");
            return Ok(list);
        }
        /// <summary>
        /// To create new exam with list of questions. QuestionsId need to pass as commma separated values
        /// </summary>
        /// <param name="examDTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Add(ExamDTOAdd examDTOAdd)
        {
            logger.LogInformation($"Add new exam: {examDTOAdd.ToString()}");
            var result = exam.Add(examDTOAdd);
            logger.LogInformation($"Result of Add new exam: {examDTOAdd.ToString()} is {result.ToString()}");
            return Ok(result);
        }
    }
}