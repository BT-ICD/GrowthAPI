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
    public class AssignmentDocumentController : ControllerBase
    {
        /// <summary>
        /// To manage documents related to particular assignment. One assignment has many documents
        /// </summary>
        private readonly ILogger<AssignmentDocumentController> logger;
        private readonly IAssignmentDocument assignmentDocument;
        private readonly MyAppSettingsOptions myAppSettingsOptions;
        public AssignmentDocumentController(IAssignmentDocument assignmentDocument, ILogger<AssignmentDocumentController> logger, IOptions<MyAppSettingsOptions> myAppSettingsOptions)
        {
            this.assignmentDocument = assignmentDocument;
            this.logger = logger;
            this.myAppSettingsOptions = myAppSettingsOptions.Value;
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
       /// <param name="dTOUpload"></param>
       /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromForm] AssignmentDocumentDTOUploadAdd dTOUpload)
        {
            if (dTOUpload.file == null)
            {
                return BadRequest("Invalid File, it must not null");
            }
            
            long size = dTOUpload.file.Length;
            if (size == 0)
            {
                return BadRequest("Invalid File");
            }

            var documentFolderName = myAppSettingsOptions.AssignmentDocuments;
            var fileName = dTOUpload.file.FileName;

            AssignmentDocumentDTOAdd dTOAdd = new AssignmentDocumentDTOAdd();
            dTOAdd.AssignmentId = dTOUpload.AssignmentId;
            dTOAdd.DocumentTypeId = dTOUpload.DocumentTypeId;
            dTOAdd.Notes = dTOUpload.Notes;
            dTOAdd.ActualFileName = fileName;

            logger.LogInformation($"Add new assignment document {dTOAdd.ToString()}");

            var result = assignmentDocument.Add(dTOAdd);
            
            var filePathDocument = AppContext.BaseDirectory + documentFolderName + "\\" + result.StoreAsFileName;
            using (var stream = System.IO.File.Create(filePathDocument))
            {
                await dTOUpload.file.CopyToAsync(stream);
            }

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
        public async Task<IActionResult> Edit([FromForm] AssignmentDocumentDTOUploadEdit dTOUpload)
        {
            if (dTOUpload.file != null)
            {
                if (dTOUpload.file.Length == 0)
                {
                    return BadRequest("Invalid File");
                }
            }
            AssignmentDocumentDTOEdit dTOEdit = new AssignmentDocumentDTOEdit();
            dTOEdit.AssignmentDocumentId = dTOUpload.AssignmentDocumentId;
            dTOEdit.AssignmentId = dTOUpload.AssignmentId;
            dTOEdit.DocumentTypeId = dTOUpload.DocumentTypeId;
            dTOEdit.Notes = dTOUpload.Notes;

            if(dTOUpload.file != null)
            {
                dTOEdit.ActualFileName = dTOUpload.file.FileName;
            }
            logger.LogInformation($"Edit assignment document {dTOEdit.ToString()}");
            var result = assignmentDocument.Edit(dTOEdit);
            logger.LogInformation($"Assignment document edited {dTOEdit.ToString()}");

            if (dTOUpload.file != null)
            {
                var documentFolderName = myAppSettingsOptions.AssignmentDocuments;
                var fileName = dTOUpload.file.FileName;
                var filePathDocument = AppContext.BaseDirectory + documentFolderName + "\\" + result.StoreAsFileName;
                using (var stream = System.IO.File.Create(filePathDocument))
                {
                    await dTOUpload.file.CopyToAsync(stream);
                }
            }
            
            
            
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
        /// <summary>
        /// To download particular assignment document 
        /// </summary>
        /// <param name="assignmentDocumentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{assignmentDocumentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Download(int assignmentDocumentId)
        {
            var result = assignmentDocument.GetById(assignmentDocumentId);
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