using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Student
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAssignmentController : ControllerBase
    {
        private readonly IAssignmentAllocation assignmentAllocation;
        private readonly ILogger<StudentAssignmentController> logger;
        public StudentAssignmentController(IAssignmentAllocation assignmentAllocation, ILogger<StudentAssignmentController>  logger)
        {
            this.assignmentAllocation = assignmentAllocation;
            this.logger = logger;
        }
        //Todo: How to define optional route parameter
        /// <summary>
        /// To get list of assignment allocated to a particular student
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult MyAssignments( ) 
        {
            var userName = this.User.Identity.Name;
            logger.LogInformation($"Assigment list for {userName} with status all ");
            var result = assignmentAllocation.AssignmentAllocationList(userName, null);
            logger.LogInformation($"Available Assignment for {userName} with status all is {result.Count}");
            return Ok(result);
        }
    }
}