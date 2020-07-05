using Elazone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopElazone.UI.Infrastructure
{
    public class DatabaseInitializer
    {
        public static void Seed(IServiceScope scope)
        {
            using (var context = scope.ServiceProvider.GetRequiredService<GeneralDbContext>())
            {
               var manager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if(!manager.Users.Any())
                {
                   var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                   
                    AppUser appUser = new AppUser
                    {
                        Email = configuration["User:email"],
                        UserName = configuration["User:username"]
                    };
                    manager.CreateAsync(appUser, configuration["User:password"])
                                  .GetAwaiter()
                                    .GetResult();


                   var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                    List<IdentityRole<int>> roleList = new List<IdentityRole<int>>();
                    if(!roleManager.Roles.Any())
                    {
                        string[] roles = configuration.GetSection("Roles").Value.Split(',');
                        foreach (var role in roles)
                        {
                            var r = new IdentityRole<int>
                            {
                                Name = role
                            };
                           roleList.Add(r);
                            roleManager.CreateAsync(r).GetAwaiter()
                                  .GetResult();
                        }
                    }

                    manager.AddToRoleAsync(appUser, roleList[0].Name).GetAwaiter().GetResult();
                    

                }
                
            }
        }
    }
}
