using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Growth.API.AuthData
{
    public class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //To store password as a plain text
            userManager.PasswordHasher = new CustomPasswordHasher();
            context.Database.EnsureCreated();

            //  if (!context.Users.Any())
            {
                //ApplicationUser user = new ApplicationUser()
                //{
                //    Email = "btrivedi1@gmail.com",
                //    SecurityStamp = Guid.NewGuid().ToString(),
                //    UserName = "BtManager@12"
                //};
                //userManager.CreateAsync(user, "password@Welcome20");

                ApplicationUser user = new ApplicationUser()
                {
                    Email = "student@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Student@1"
                };
                userManager.CreateAsync(user, "Student@1");
            }
            //To interact with Role Manager 
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //To access List of roles
            //var roles = roleManager.Roles.ToList();
            //var cnt = roles.Count;
            //To create role - Still need to identify - how to create instance of ApplicationUserRole and then insert new record
            //var roleResult = roleManager.CreateAsync(new IdentityRole("Manager"));
            //var roleResult1 = roleManager.CreateAsync(new IdentityRole("Student"));

            //To add User into a role

            //var userRecord = await userManager.FindByEmailAsync ("BTRIVEDI@GMAIL.COM");


        }
    }
}
