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
    public class AssignmentDocumentController : ControllerBase
    {
        /// <summary>
        /// To manage documents related to particular assignment. One assignment has many documents
        /// </summary>
        private readonly ILogger<AssignmentDocumentController> logger;
        private readonly IAssignmentDocument assignmentDocument;
        public AssignmentDocumentController(IAssignmentDocument assignmentDocument, ILogger<AssignmentDocumentController> logger)
        {
            this.assignmentDocument = assignmentDocument;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of documents for a particular assignment
        /// </summary>
        /// <param name="assignmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{assignmentId:int}")]
        public IActionResult GetList(int assignmentId)
        {
            logger.LogInformation($"Assignment Document  list for {assignmentId}");
            var result = assignmentDocument.GetList(assignmentId);
            logger.LogInformation($"Assignment Document list count for assingnment id {assignmentId} is {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To get detail of particular document of an assignment
        /// </summary>
        /// <param name="assignmentDocumentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{assignmentDocumentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int assignmentDocumentId)
        {
            logger.LogInformation($"Assignment Document for AssignmentDocumentId {assignmentDocumentId}");
            var result = assignmentDocument.GetById(assignmentDocumentId);
            if (result == null)
                return NotFound();
            logger.LogInformation($"Assignment Document for AssignmentDocumentId {assignmentDocumentId} is {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To add new document for a particular assignment
        /// </summary>
        /// <param name="dTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Add(AssignmentDocumentDTOAdd dTOAdd)
        {
            logger.LogInformation($"Add new assignment document {dTOAdd.ToString()}");
            var result = assignmentDocument.Add(dTOAdd);
            logger.LogInformation($"New Assignment document created {dTOAdd.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To edit details of a particular document of a particular assignment
        /// </summary>
        /// <param name="dTOEdit"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Edit(AssignmentDocumentDTOEdit dTOEdit)
        {
            logger.LogInformation($"Edit assignment document {dTOEdit.ToString()}");
            var result = assignmentDocument.Edit(dTOEdit);
            logger.LogInformation($"New Assignment document created {dTOEdit.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To delete particular document of an assignment
        /// </summary>
        /// <param name="assignmentDocumentId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{assignmentDocumentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int assignmentDocumentId)
        {
            logger.LogInformation($"Delete assignment document for AssignmentDocumentId {assignmentDocumentId}");
            var result = assignmentDocument.Delete(assignmentDocumentId);
            logger.LogInformation($"Delete result of AssignmentDocumentId {assignmentDocumentId} is {result.ToString()}");
            return Ok(result);
        }
    }
}