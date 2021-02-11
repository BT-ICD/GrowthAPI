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
        private readonly ILogger<AssignmentAllocationController> logger;
        public AssignmentAllocationController(IAssignmentAllocation assignmentAllocation, ILogger<AssignmentAllocationController> logger)
        {
            this.assignmentAllocation = assignmentAllocation;
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
    }
}