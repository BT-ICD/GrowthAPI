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
    public class BatchController : ControllerBase
    {
        private readonly IBatch batch;
        private readonly ILogger<BatchController> logger;
        public BatchController(IBatch batch, ILogger<BatchController> logger)
        {
            this.batch = batch;
            this.logger = logger;
        }

        /// <summary>
        /// To get list of batches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetList()
        {
            logger.LogInformation("Batch List");
            var result = batch.GetList();
            logger.LogInformation($"Number of Batches: {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To get detail of particular batch
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{batchId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int batchId)
        {
            logger.LogInformation($"Batch Id: {batchId}");
            var result = batch.GetById(batchId);
            if (result == null)
                return NotFound();
            logger.LogInformation($"Batch details: {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To get list of batch. Batch Id and Code to fill dropdown (lookup values)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Lookup()
        {
            var result = batch.Lookup();
            logger.LogInformation($"Batch count: {result.Count}");
            return Ok(result);
        }
    }
}