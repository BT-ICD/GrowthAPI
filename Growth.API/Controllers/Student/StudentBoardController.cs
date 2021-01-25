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
    public class StudentBoardController : ControllerBase
    {
        private readonly IDashboard dashboard ;
        private ILogger<StudentBoardController> logger;
        public StudentBoardController(IDashboard dashboard, ILogger<StudentBoardController> logger)
        {
            this.dashboard = dashboard;
            this.logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudentBoard()
        {
            var userName = this.User.Identity.Name;
            logger.LogInformation($"Student Dashboard: {userName}");
            var result = dashboard.DashBoardStudent(userName);
            logger.LogInformation($"Dashboard result summary count: {result.SessionSummary.Count}");
            return Ok(result);

        }
    }
}