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

namespace Growth.API.Controllers.Student
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAssignmentController : ControllerBase
    {
        private readonly IAssignmentAllocation assignmentAllocation;
        private readonly IAssignmentDocument assignmentDocument;
        private readonly IAssignmentLog assignmentLog;
        private readonly MyAppSettingsOptions myAppSettingsOptions;
        private readonly ILogger<StudentAssignmentController> logger;

        public StudentAssignmentController(IAssignmentAllocation assignmentAllocation, IAssignmentDocument assignmentDocument, IAssignmentLog assignmentLog, IOptions<MyAppSettingsOptions> myAppSettingsOptions, ILogger<StudentAssignmentController>  logger)
        {
            this.assignmentAllocation = assignmentAllocation;
            this.assignmentLog = assignmentLog;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
            this.assignmentDocument = assignmentDocument;
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
        /// <summary>
        /// To get details of particular assgiment allocated to a particular student
        /// </summary>
        /// <param name="AssignmentAllocationId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{AssignmentAllocationId:int}")]
        public IActionResult GetById(int AssignmentAllocationId)
        {
           
            logger.LogInformation($"Assigment Details for {AssignmentAllocationId} ");
            var result = assignmentAllocation.GetById(AssignmentAllocationId);
            logger.LogInformation($"Assigment Details for {AssignmentAllocationId} is {result}");
            return Ok(result);
        }
        /// <summary>
        /// To submit assignment
        /// </summary>
        /// <param name="assignmentDTOSubmit"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SubmitAssignmentAsync( [FromForm] AssignmentDTOSubmit assignmentDTOSubmit)
        {
            string actualFileName = "";
            if (assignmentDTOSubmit.file != null)
            {
                actualFileName = assignmentDTOSubmit.file.FileName;
            }
            AssignmentLogDTOAdd assignmentLogDTO = new AssignmentLogDTOAdd()
            {
                AssignmentAllocationId = assignmentDTOSubmit.AssignmentAllocationId,
                Status = 2,
                UserName = User.Identity.Name,
                ActualFileName = actualFileName,
                Comments = assignmentDTOSubmit.Comments
            };
            logger.LogInformation($"Update status of assignment allocation: {assignmentLogDTO}");
            var result = assignmentLog.Add(assignmentLogDTO);
            logger.LogInformation($"Assignment status of allocation {assignmentLogDTO} is updated with result {result}");

            //Upload file
            if (actualFileName != "")
            {
                var documentFolderName = myAppSettingsOptions.StudentAssignments;
                var filePathDocument = AppContext.BaseDirectory + documentFolderName + "\\" + result.StoredAsFilename;
                using(var stream = System.IO.File.Create(filePathDocument))
                {
                    await assignmentDTOSubmit.file.CopyToAsync(stream);
                }
            }
            return Ok(result);
        }
        /// <summary>
        /// To download particular assignment document 
        /// </summary>
        /// <param name="AssignmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{AssignmentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Download(int AssignmentId)
        {
            var result = assignmentDocument.GetByAssignmentId(AssignmentId);
            if (result == null)
                return NotFound();
            string fileName = result.StoreAsFileName;
            var documentFolderName = myAppSettingsOptions.AssignmentDocuments;
            var path = Path.Combine(AppContext.BaseDirectory, documentFolderName, fileName);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", fileName);
        }
    }
}
