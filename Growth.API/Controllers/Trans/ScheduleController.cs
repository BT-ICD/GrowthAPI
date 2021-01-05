using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Growth.Repository.Interfaces;
using Growth.Models;

namespace Growth.API.Controllers.Trans
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        /// <summary>
        /// To interact with schedule (List/Add/Edit/Delete Schedule)
        /// </summary>
        private readonly ISchedule schedule;
        private ILogger<ScheduleController> logger;
        public ScheduleController(ISchedule schedule, ILogger<ScheduleController> logger)
        {
            this.schedule = schedule;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of schedules
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetList()
        {
            var result = schedule.GetList();
            logger.LogInformation($"Schedule list count: {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To get particular schedule by Id 
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{scheduleId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int scheduleId)
        {
            logger.LogInformation($"Schedule for Id: {scheduleId}");
            var result = schedule.GetById(scheduleId);
            if (result == null)
                return NotFound();
            logger.LogInformation($"Result for schedule id {scheduleId} is {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To add new Schedule record
        /// </summary>
        /// <param name="dTOAdd"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Add(ScheduleDTOAdd dTOAdd)
        {
            //Convert Date to - TolocalTime
            dTOAdd.LectureFrom = dTOAdd.LectureFrom.ToLocalTime();
            dTOAdd.LectureTo = dTOAdd.LectureTo.ToLocalTime();

            logger.LogInformation($"Add new schedule {dTOAdd.ToString()}");
            var result = schedule.Add(dTOAdd);
            logger.LogInformation($"Schedule Add Result is {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To edit existing schedule record
        /// </summary>
        /// <param name="dTOEdit"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Edit(ScheduleDTOEdit dTOEdit)
        {
            //Convert Date to - TolocalTime
            dTOEdit.LectureFrom = dTOEdit.LectureFrom.ToLocalTime();
            dTOEdit.LectureTo = dTOEdit.LectureTo.ToLocalTime();
            logger.LogInformation($"Edit schedule {dTOEdit.ToString()}");
            var result = schedule.Edit(dTOEdit);
            logger.LogInformation($"Schedule Edit Result is {result.ToString()}");
            return Ok(result);
        }
        [HttpPost]
        [Route("{scheduleId:int}")]
        public IActionResult Delete(int scheduleId)
        {
            logger.LogInformation($"Delete schedule for schedule id: {scheduleId}");
            var result = schedule.Delete(scheduleId);
            logger.LogInformation($"Delete schedule result : {result.ToString()}");
            return Ok(result);
        }
    }
}