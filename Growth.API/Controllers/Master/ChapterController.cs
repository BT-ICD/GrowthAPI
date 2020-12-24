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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapter chapter;
        private readonly ILogger<ChapterController> logger;

        public ChapterController(IChapter chapter, ILogger<ChapterController> logger)
        {
            this.chapter = chapter;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of chapters for particular subject.
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{subjectId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetList(int subjectId)
        {
            logger.LogInformation($"Chapters for subject id: {subjectId}");
            var result = chapter.GetList(subjectId);
            logger.LogInformation($"Chapter count: {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To get details of particular chapter
        /// </summary>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{chapterId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int chapterId)
        {
            logger.LogInformation($"chapter id: {chapterId}");
            var result = chapter.GetById(chapterId);
            if (result == null)
                return NotFound();
            logger.LogInformation($"Result for {chapterId} is {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To add new chapter
        /// </summary>
        /// <param name="chapterDTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(ChapterDTOAdd chapterDTOAdd)
        {
            logger.LogInformation($"Add new chapter {chapterDTOAdd.ToString()}");
            var result = chapter.Add(chapterDTOAdd);
            logger.LogInformation($"Inserted new chapter {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To update (edit) chapter detail
        /// </summary>
        /// <param name="chapterDTOEdit"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Edit(ChapterDTOEdit chapterDTOEdit)
        {
            logger.LogInformation($"Edit chapter {chapterDTOEdit.ToString()}");
            var result = chapter.Edit(chapterDTOEdit);
            logger.LogInformation($"Updated chapter {result.ToString()}");
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int chapterId)
        {
            logger.LogInformation($"Delete chapter for chapter id: {chapterId}");
            var result = chapter.Delete(chapterId);
            logger.LogInformation($"Delete chapter result {result.ToString()}");
            return Ok(result);
        }

    }
}