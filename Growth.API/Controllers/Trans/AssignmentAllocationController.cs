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
    public class AssignmentAllocationController : ControllerBase
    {
        private readonly IAssignmentAllocation assignmentAllocation;
        private readonly IAssignmentLog assignmentLog;
        private readonly ILogger<AssignmentAllocationController> logger;
        public AssignmentAllocationController(IAssignmentAllocation assignmentAllocation, IAssignmentLog assignmentLog,  ILogger<AssignmentAllocationController> logger)
        {
            this.assignmentAllocation = assignmentAllocation;
            this.assignmentLog = assignmentLog;
            this.logger = logger;
        }
        /// <summary>
        /// To allocate assignment to all the students of a batch or some of the students of a batch
        /// </summary>
        /// <param name="allocationDTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(AssignmentAllocationDTOAdd allocationDTOAdd)
        {
            logger.LogInformation($"Allocate assignment to {allocationDTOAdd.ToString()}");
            var result = assignmentAllocation.Add(allocationDTOAdd);
            logger.LogInformation($"Assignment {allocationDTOAdd.AssignmentId} is allocated to : {result} students ");
            return Ok(result);

        }
        /// <summary>
        /// To update Status of an assignment with comments for a particular allocated assignment 
        /// </summary>
        /// <param name="assignmentLogDTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateAssignmentStatus(AssignmentLogDTOAdd assignmentLogDTOAdd)
        {
            //To do - TO provide user name from current logged in session
            //To allow file upload 
            logger.LogInformation($"Update status of assignment allocation: {assignmentLogDTOAdd}");
            var result = assignmentLog.Add(assignmentLogDTOAdd);
            logger.LogInformation($"Assignment status of allocation {assignmentLogDTOAdd} is updated with result {result}");
            return Ok(result);
            
        }
        [HttpGet]
        [Route("{AssignmentAllocationId:int}")]
        public IActionResult LogList(int AssignmentAllocationId)
        {
            logger.LogInformation($"Get log list for assignment allocation with Id: {AssignmentAllocationId}");
            var result = assignmentLog.GetList(AssignmentAllocationId);
            logger.LogInformation($"List of log count for assignment allocation with Id: {AssignmentAllocationId} is {result.Count}");
            return Ok(result);
        }
       
    }
}