using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Growth.API.AppRepository;
using Growth.API.Models;
using Growth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Growth.API.Controllers.Trans
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ILogger<AppUserController> logger;
        private readonly IAppUser appUser;
        public AppUserController(IAppUser appUser, ILogger<AppUserController> logger)
        {
            this.appUser = appUser;
            this.logger = logger;
        }
        /// <summary>
        /// To create new user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUserAsync(AppUser newUser)
        {
            logger.LogInformation($"Create new user for {newUser.ToString()}");
            var result = await appUser.CreateUserAsync(newUser);
            logger.LogInformation($"Result of new user create for {newUser.ToString()} is {result.ToString()}");
            return Ok(result);
        }
        /// <summary>
        /// To verify user name exist or not.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IsUserNameExist(String userName)
        {
            logger.LogInformation($"User name exist for {userName}");
            var result = appUser.IsUserNameExist(userName);
            logger.LogInformation($"result for username exist for {userName} is {result}");
            return Ok(new { result }); 
        }
        /// <summary>
        /// To get list of users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            var result = appUser.GetList();
            logger.LogInformation($"Number of users {result.Count}");
            return Ok(result);
        }
    }
}