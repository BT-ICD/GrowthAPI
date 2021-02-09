using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentType documentType;
        private readonly ILogger<DocumentTypeController> logger;
        public DocumentTypeController(IDocumentType documentType, ILogger<DocumentTypeController> logger)
        {
            this.documentType = documentType;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of document types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Lookup()
        {
            logger.LogInformation($"Document type lookup");
            var result = documentType.Lookup();
            logger.LogInformation($"Document type list count: {result.Count}");
            return Ok(result);
        }
    }
}