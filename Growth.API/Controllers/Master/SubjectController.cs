using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Master
{
    /// <summary>
    /// To access subject details
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject subject;
        private readonly ILogger<SubjectController> logger;
        public SubjectController(ISubject subject, ILogger<SubjectController> logger)
        {
            this.subject = subject;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var list =subject.GetList();
            logger.LogInformation($"Count of subjects: {list.Count}");
            return Ok(list);
        }
    }
}