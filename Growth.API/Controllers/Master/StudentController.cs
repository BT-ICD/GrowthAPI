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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent student;
        private readonly ILogger<StudentController> logger;
        public StudentController(IStudent student, ILogger<StudentController> logger)
        {
            this.student = student;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Lookup()
        {
            logger.LogInformation($"Student Lookup: ");
            var result = student.Lookup();
            logger.LogInformation($"Student lookup list count: {result.Count} ");
            return Ok(result);
        }
    }
}