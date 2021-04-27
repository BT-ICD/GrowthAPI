using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Growth.API.Models;
using Growth.Models;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Growth.API.Controllers.Trans
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssignmentAllocationController : ControllerBase
    {
        private readonly IAssignmentAllocation assignmentAllocation;
        private readonly IAssignmentLog assignmentLog;
        private readonly ILogger<AssignmentAllocationController> logger;
        private readonly MyAppSettingsOptions myAppSettingOptions;
        public AssignmentAllocationController(IAssignmentAllocation assignmentAllocation, IAssignmentLog assignmentLog,  ILogger<AssignmentAllocationController> logger, IOptions<MyAppSettingsOptions> myAppSettingOptions)
        {
            this.assignmentAllocation = assignmentAllocation;
            this.assignmentLog = assignmentLog;
            this.logger = logger;
            this.myAppSettingOptions = myAppSettingOptions.Value;
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
        /// <summary>
        /// To update review notes and status from faculty
        /// </summary>
        /// <param name="assignmentLogDTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SubmitReview(AssignmentLogDTOAdd assignmentLogDTOAdd)
        {
            assignmentLogDTOAdd.UserName = User.Identity.Name;
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
        /// <summary>
        /// To get list of students for which we have to review a particular assignment for a particular status
        /// This allows faculty to review particular assignment submission for a particular student
        /// </summary>
        /// <param name="AssignmentId"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{AssignmentId:int}/{Status:int}/{StudentId:int?}")]
        public IActionResult ReviewListStudentByStatus(int AssignmentId, int Status, int? StudentId=-1)
        {
            if (StudentId == -1)
            {
                StudentId = null;
            }
            logger.LogInformation($"Get log list for assignment log summary with AssignmentId: {AssignmentId} and Status {Status}");
            var result = assignmentLog.ReviewListStudentByStatus(AssignmentId,Status, StudentId);
            logger.LogInformation($"List of log count for assignment allocation by status with AssignmentId: {AssignmentId} is {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To download document submitted by student for a particular assignment submission
        /// </summary>
        /// <param name="AssignmentLogId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{AssignmentLogId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DownloadSubmittedDocumentAsync(int AssignmentLogId)
        {
            logger.LogInformation($"Download Submitted Document for AssignmentLogId: {AssignmentLogId}");
            var result = assignmentLog.GetById(AssignmentLogId);
            if (result == null)
            {
                return NotFound();
            }
            if ((result.StoredAsFilename + "") == "")
            {
                return NotFound();
            }
            var documentFolderName = myAppSettingOptions.StudentAssignments;
            var path = Path.Combine(AppContext.BaseDirectory, documentFolderName, result.StoredAsFilename);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", result.StoredAsFilename);
        }

    }
}