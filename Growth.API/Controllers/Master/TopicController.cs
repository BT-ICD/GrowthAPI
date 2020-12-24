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
    /// To manipulate content of topic 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ILogger<TopicController> logger;
        private readonly ITopic topic;
        public TopicController(ITopic topic, ILogger<TopicController> logger)
        {
            this.topic = topic;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of topics for particular chapter
        /// </summary>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetList(int chapterId)
        {
            logger.LogInformation($"chapterId : {chapterId}");
            var result = topic.GetList(chapterId);
            logger.LogInformation($"Count of chapters {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To get details of particular topic
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{topicId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int topicId)
        {
            logger.LogInformation($"topicId: {topicId}");
            var result = topic.GetById(topicId);
            if (result == null)
                return NotFound();
            logger.LogInformation($"topic details for {topicId} is {result.ToString()} ");
            return Ok(result);
        }
        /// <summary>
        /// To add new topic
        /// </summary>
        /// <param name="dTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(TopicDTOAdd dTOAdd)
        {
            logger.LogInformation($"Add new topic: {dTOAdd.ToString()}");
            var result = topic.Add(dTOAdd);
            logger.LogInformation($"Topic insert result {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To edit (update) topic details
        /// </summary>
        /// <param name="dTOEdit"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Edit(TopicDTOEdit dTOEdit)
        {
            logger.LogInformation($"Edit topic details for {dTOEdit.ToString()}");
            var result = topic.Edit(dTOEdit);
            logger.LogInformation($"Edit topic result: {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To delete details of particular topic
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int topicId)
        {
            logger.LogInformation($"Delete topic details of {topicId}");
            var result = topic.Delete(topicId);
            logger.LogInformation($"Delete topic result: {result.ToString()}");
            return Ok(result);
        }
    }
}