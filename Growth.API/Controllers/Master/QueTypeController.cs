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
    public class QueTypeController : ControllerBase
    {
        private ILogger<QueTypeController> logger;
        private readonly IQueType queType;
        public QueTypeController(IQueType queType, ILogger<QueTypeController> logger)
        {
            this.queType = queType;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of question types. To fill dropdown (lookup values)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Lookup()
        {
            logger.LogInformation($"Lookup values for Question Types");
            var result = queType.Lookup();
            logger.LogInformation($"Question type count: {result.Count}");
            return Ok(result);
        }
    }
}