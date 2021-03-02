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
    public class QuestionBankController : ControllerBase
    {
        private readonly ILogger<QuestionBankController> logger;
        private IQuestionBank questionBank;
        public QuestionBankController(IQuestionBank questionBank, ILogger<QuestionBankController> logger)
        {
            this.questionBank = questionBank;
            this.logger = logger;
        }
        /// <summary>
        /// To add new question with possible answers as a choice
        /// </summary>
        /// <param name="dTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(QuestionDTOAdd dTOAdd)
        {
            logger.LogInformation($"Add new question {dTOAdd.ToString()}");
            var result = questionBank.Add(dTOAdd);
            logger.LogInformation($"Result for add new question {dTOAdd.PlainText} is {result.ToString()}");
            return Ok(result);
        }
    }
}