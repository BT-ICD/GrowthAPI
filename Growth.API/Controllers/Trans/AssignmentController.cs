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
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignment assignment;
        private readonly ILogger<AssignmentController> logger;
        public AssignmentController(IAssignment assignment, ILogger<AssignmentController> logger)
        {
            this.assignment = assignment;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of assignments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            logger.LogInformation($"Assignment list");
            var result = assignment.GetList();
            logger.LogInformation($"Assignment list count  {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To get details of particular assignment
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{assignmentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int assignmentId)
        {
            logger.LogInformation($"Assignment details for {assignmentId}");
            var result = assignment.GetById(assignmentId);
            if (result == null)
                return NotFound();
            logger.LogInformation($"Assignment for {assignmentId} is {result.ToString()}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Add(AssignmentDTOAdd dTOAdd)
        {
            logger.LogInformation($"Add new assigment {dTOAdd.ToString()}");
            var result = assignment.Add(dTOAdd);
            logger.LogInformation($"Assignment added result: {result.ToString()}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Edit(AssignmentDTOEdit dTOEdit)
        {
            logger.LogInformation($"Edit assigment {dTOEdit.ToString()}");
            var result = assignment.Edit(dTOEdit);
            logger.LogInformation($"Assignment edit result: {result.ToString()}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{assignmentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int assignmentId)
        {
            logger.LogInformation($"Delete assigment {assignmentId}");
            var result = assignment.Delete(assignmentId);
            logger.LogInformation($"Assignment delete result for assignment id {assignmentId}: {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To assignment submission details for a particular assignment by status
        /// </summary>
        /// <param name="AssignmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{AssignmentId:int}")]
        public IActionResult ReviewList(int AssignmentId)
        {
            logger.LogInformation($"Assignment Review List for {AssignmentId}");
            var result = assignment.GetReviewList(AssignmentId);
            //logger.LogInformation($"Assignment review list  result for assignment id {AssignmentId}: {result.assignmentDTODetail.ToString()} and summary count {}");
            return Ok(result);
        }

    }
}