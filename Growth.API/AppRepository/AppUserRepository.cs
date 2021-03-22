using Growth.API.AuthData;
using Growth.API.Models;
using Growth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Growth.API.AppRepository
{
    public class AppUserRepository : IAppUser
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public AppUserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<DataUpdateResponseDTO> CreateUserAsync(AppUser appUser)
        {
            
            //To store password as a plain text
            userManager.PasswordHasher = new CustomPasswordHasher();
            ApplicationUser user = new ApplicationUser()
            {
                Email = appUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = appUser.UserName
            };
            var result = await userManager.CreateAsync(user, appUser.UserPassword);
            if (result.Succeeded)
            {
                return new DataUpdateResponseDTO() { Status = "PASS", Description = $"User Created {appUser.UserName}", RecordCount = 1 };
            }
            
            return new DataUpdateResponseDTO() { Status = "FAIL", Description = $"Fail to create user {appUser.UserName}", RecordCount = 0 }; 
            
        }
        public bool IsUserNameExist(String userName)
        {
            var result = userManager.Users.Where(obj => obj.UserName.Equals(userName)).FirstOrDefault();
            return !(result == null);
        }
    }
}
