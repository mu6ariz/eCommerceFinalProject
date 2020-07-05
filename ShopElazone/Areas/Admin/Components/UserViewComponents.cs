using Elazone.Models;
using Elazone.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.UI.Areas.Admin.Components
{
    public class UserViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _usermanager;
        public UserViewComponent(UserManager<AppUser> userManager)
        {
            _usermanager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          
          var users = await _usermanager.Users.Select(x => new UserModel 
            {
                AccessDeniedCount = x.AccessFailedCount,
                Email = x.Email,
                IsLocked = ( (x.LockoutEnd != null) && (x.LockoutEnd.Value.CompareTo(DateTime.UtcNow)==1))?true:false,
                UserName = x.UserName
            }).ToListAsync();

            return View(users);
        }
    }
}
