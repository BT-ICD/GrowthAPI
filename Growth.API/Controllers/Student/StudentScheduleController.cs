using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Student
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StudentScheduleController : ControllerBase
    {
        private readonly ISchedule schedule;
        private ILogger<StudentScheduleController> logger;
        public StudentScheduleController(ISchedule schedule, ILogger<StudentScheduleController> logger)
        {
            this.schedule = schedule;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of sessions (schedule) for a logged in student
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetList(string userName)
        {
            logger.LogInformation($"Schedule list for user {userName}");
            var result = schedule.GetListForStudent(userName);
            logger.LogInformation($"Schedule list count: {result.Count}");
            return Ok(result);
        }
    }
}