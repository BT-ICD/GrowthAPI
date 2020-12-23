using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.Models;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Master
{
    /// <summary>
    /// To access subject details
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject subject;
        private readonly ILogger<SubjectController> logger;
        public SubjectController(ISubject subject, ILogger<SubjectController> logger)
        {
            this.subject = subject;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of subjects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            var list =subject.GetList();
            logger.LogInformation($"Count of subjects: {list.Count}");
            return Ok(list);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            logger.LogInformation($"Subject id: {id}");
            var result = subject.GetById(id);
            if (result == null)
                return NotFound();
            logger.LogInformation($"Result: {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To add new subject
        /// </summary>
        /// <param name="subjectDTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(SubjectDTOAdd subjectDTOAdd)
        {
            logger.LogInformation($"Add New Subject: {subjectDTOAdd.ToString()}");
            var result = subject.Add(subjectDTOAdd);
            logger.LogInformation($"Add new subject result {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To edit existing subject details 
        /// </summary>
        /// <param name="subjectDTODetail"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Edit(SubjectDTODetail subjectDTODetail)
        {
            logger.LogInformation($"Edit subject : {subjectDTODetail.ToString()}");
            
            var result = subject.Edit(subjectDTODetail);
            logger.LogInformation($"Edited subject: {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To delete particular subject detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            logger.LogInformation($"Delete subject with id {id}");
            var result = subject.Delete(id);
            logger.LogInformation($"Delted Subject Response: {result.ToString()}");
            return Ok(result);
        }
    }
}