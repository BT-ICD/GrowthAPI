using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Growth.Models;
using Growth.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Trans
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ILogger<AttendanceController> logger;
        private readonly IAttendance attendance;
        public AttendanceController(IAttendance attendance, ILogger<AttendanceController> logger)
        {
            this.attendance = attendance;
            this.logger = logger;
        }
        /// <summary>
        /// To get list of students for a particular schedule to submit attendance 
        /// </summary>
        /// <param name="scheduleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{scheduleId:int}")]
        public IActionResult GetList(int scheduleId)
        {
            logger.LogInformation($"Attendance for scheduleId: {scheduleId}");
            var result = attendance.AttendanceList(scheduleId);
            logger.LogInformation($"Students count for attendance : {result.Count}");
            return Ok(result);
        }
        /// <summary>
        /// To submit attendance for a particular schedule
        /// </summary>
        /// <param name="dTOSubmit"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Submit(AttendanceDTOSubmit dTOSubmit)
        {
            logger.LogInformation($"To submit attendance for {dTOSubmit.ToString()}");
            var result = attendance.Submit(dTOSubmit);
            logger.LogInformation($"Attendance submit result for schedule {dTOSubmit.ScheduleId} is {result.ToString()}");
            return Ok(result);
        }
    }
}
